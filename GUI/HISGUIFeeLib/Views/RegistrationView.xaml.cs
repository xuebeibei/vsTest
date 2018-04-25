using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUIFeeLib.ViewModels;
using System.Data;
using Microsoft.VisualBasic;

namespace HISGUIFeeLib.Views
{
    public class SignalSourceMsg
    {
        public SignalSourceMsg()
        {
            weekStringList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                weekStringList.Add("");
            }
        }

        public SignalSourceMsg(CommContracts.SignalTime signalTimeEnum)
        {
            ClinicVistTime = signalTimeEnum;

            weekStringList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                weekStringList.Add("");
            }
        }

        public CommContracts.SignalTime ClinicVistTime { get; set; }

        public List<string> weekStringList { get; set; }
    }

    public class SignalSourceNums
    {
        public int hasUnUsedNum { get; set; }

        public CommContracts.SignalType SignalType { get; set; }
        public CommContracts.WorkPlan SignalSource { get; set; }
    }

    [Export]
    [Export("RegistrationView", typeof(RegistrationView))]
    public partial class RegistrationView : HISGUIViewBase
    {
        private CommContracts.Registration currentRegistration;

        public RegistrationView()
        {
            InitializeComponent();

            this.Loaded += RegistrationView_Loaded;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void RegistrationView_Loaded(object sender, RoutedEventArgs e)
        {
            currentRegistration = new CommContracts.Registration();
            updateSignalSourceMsg();
            InitCombo();

            var vm = this.DataContext as HISGUIFeeVM;
            this.departmentList.ItemsSource = vm?.getAllDepartment();//数据绑定
        }

        private void InitCombo()
        {
            this.FeeTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.FeeTypeEnum));
            this.FeeTypeCombo.SelectedIndex = 0;

            this.ZJCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.ZhengJianEnum));
            this.ZJCombo.SelectedIndex = 0;

            this.CardTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PatientCardEnum));
            this.CardTypeCombo.SelectedIndex = 0;
        }

        private void updatePatientsMsg(String strPatientCardNum)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Patient patient = new CommContracts.Patient();
            string strAge = "";
            if (string.IsNullOrEmpty(strPatientCardNum))
            {
                vm.CurrentPatient = patient;
                this.AgeBox.Text = strAge;
                return;
            }

            CommClient.Patient patientClient = new CommClient.Patient();

            string ErrorMsg = "";
            patient = patientClient.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);

            if (patient == null)
            {
                MessageBox.Show(ErrorMsg);
            }
            else
            {
                vm.CurrentPatient = patient;

                strAge = IDCardHellper.GetAge(patient.BirthDay.Value.Year, patient.BirthDay.Value.Month, patient.BirthDay.Value.Day);
                this.AgeBox.Text = strAge;
            }
        }

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            String strPatientCardNum = Interaction.InputBox("请输入就诊卡卡号", "读卡", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;

            updatePatientsMsg(strPatientCardNum);
        }

        private void updateSignalSourceMsg()
        {
            initSignalSourceGrid();
            this.SignalSourceGrid.ItemsSource = updateSignalSourceGrid();
        }

        private List<SignalSourceMsg> updateSignalSourceGrid()
        {
            List<SignalSourceMsg> nullData = new List<SignalSourceMsg>();

            var department = this.departmentList.SelectedItem as CommContracts.Department;
            if (department == null)
                return nullData;

            CommClient.WorkPlan workPlanClient = new CommClient.WorkPlan();
            List<CommContracts.WorkPlanToSignalSource> myList = workPlanClient.GetAllWorkPlan111(department.ID, DateTime.Now.Date, DateTime.Now.AddDays(6).Date);


            int n = myList.Count();



            CommClient.SignalTime clinicVistClient = new CommClient.SignalTime();
            List<CommContracts.SignalTime> vistTimeList = new List<CommContracts.SignalTime>();
            vistTimeList = clinicVistClient.GetAllClinicVistTime();

            if (vistTimeList == null)
                return null;
            else
            {
                foreach (CommContracts.SignalTime tem in vistTimeList)
                {
                    nullData.Add(new SignalSourceMsg(tem));
                }
            }

            var vm = this.DataContext as HISGUIFeeVM;

            List<SignalSourceMsg> data = new List<SignalSourceMsg>();

            bool bIsHasRegistration = false;
            List<CommContracts.Registration> registrationList = vm?.GetDepartmentRegistrationList(department.ID, DateTime.Now.Date, DateTime.Now.AddDays(6).Date);
            if (!(registrationList == null || registrationList.Count <= 0))
            {
                bIsHasRegistration = true;
            }

            foreach (CommContracts.SignalTime tim in vistTimeList)
            {
                SignalSourceMsg msg = new SignalSourceMsg(tim);
                foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                {
                    var query = from u in myList
                                where u.WorkPlan.WorkPlanDate.Value.DayOfWeek == day && u.WorkPlan.ShiftID == tim.ShiftID
                                select u.WorkPlan.MaxNum;
                    int HaveNum = query.Sum(); int UsedNum = 0;
                    if (bIsHasRegistration)
                    {
                        var regisQuery = from e in registrationList
                                         where e.SignalDate.DayOfWeek == day &&
                                         e.SignalTime.ShiftID == tim.ShiftID
                                         select e;
                        UsedNum = regisQuery.Count();
                    }

                    string str = HaveNum - UsedNum == 0 ? "" : (HaveNum - UsedNum).ToString();
                    msg.weekStringList[(int)day] = str;
                }
                data.Add(msg);
            }
            return data;
        }

        private void initSignalSourceGrid()
        {
            this.SignalSourceGrid.Columns.Clear();

            DataGridLength length = new DataGridLength(1, DataGridLengthUnitType.Star);

            this.SignalSourceGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "时段\\日期",
                Binding = new Binding("ClinicVistTime.Shift.Name"),
                Width = 63,
                IsReadOnly = true
                //,
                //Foreground = Brushes.Blue // 设置该列字体颜色
            });

            for (int i = 0; i < 7; i++)
            {
                DateTime tempDate = DateTime.Now.AddDays(i);
                this.SignalSourceGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = tempDate.ToString("yyyy-MM-dd dddd"),
                    Binding = new Binding("weekStringList[" + (int)tempDate.DayOfWeek + "]"),
                    Width = length,
                    IsReadOnly = (tempDate.Date >= DateTime.Now.Date ? false : true)
                });
            }

        }

        private void SignalSourceGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            updateSignalList();
        }

        private void updateSignalList()
        {
            SignalList.ItemsSource = null;
            if (SignalSourceGrid.SelectedCells == null || SignalSourceGrid.SelectedCells.Count <= 0)
                return;

            string data = SignalSourceGrid.SelectedCells[0].Column.Header.ToString();
            int rowIdnex = SignalSourceGrid.Items.IndexOf(SignalSourceGrid.SelectedCells[0].Item);   // 行坐标

            DateTime dt = new DateTime();
            try
            {
                dt = DateTime.ParseExact(data, "yyyy-MM-dd dddd", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return;
            }

            if (dt == null)
                return;

            List<SignalSourceMsg> list = SignalSourceGrid.ItemsSource as List<SignalSourceMsg>;

            if (list != null)
            {
                CommContracts.SignalTime timeEnum = list.ElementAt(rowIdnex).ClinicVistTime;

                var department = this.departmentList.SelectedItem as CommContracts.Department;
                if (department == null)
                    return;

                var vm = this.DataContext as HISGUIFeeVM;
                CommClient.WorkPlan workPlanClient = new CommClient.WorkPlan();
                List<CommContracts.WorkPlanToSignalSource> myList = workPlanClient.GetAllWorkPlan111(department.ID, dt, dt);

                var query = from u in myList
                            where u.WorkPlan.ShiftID == timeEnum.ShiftID
                            select u;

                List<CommContracts.Registration> registrationList = vm?.GetDepartmentRegistrationList(department.ID, dt, dt);

                List<SignalSourceNums> numsList = new List<SignalSourceNums>();

                foreach (var tem in query)
                {
                    SignalSourceNums nums = new SignalSourceNums();

                    if (!(registrationList == null || registrationList.Count <= 0))
                    {
                        int hasNum = 0;
                        var query1 = from u in registrationList
                                     where u.SignalTime.ShiftID == timeEnum.ShiftID
                                     && u.SignalTypeID == tem.SignalType.ID
                                     select u;
                        hasNum = query1.Count();
                        nums.hasUnUsedNum = tem.WorkPlan.MaxNum - hasNum;
                    }
                    else
                        nums.hasUnUsedNum = tem.WorkPlan.MaxNum;
                    nums.SignalSource = tem.WorkPlan;
                    nums.SignalType = tem.SignalType;
                    numsList.Add(nums);
                }


                SignalList.ItemsSource = numsList;
            }
        }
        private void clearAllDate()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Patient patient = new CommContracts.Patient();
            vm.CurrentPatient = patient;

            currentRegistration = new CommContracts.Registration();

            departmentList.SelectedItem = null;
            SignalSourceGrid.SelectedItem = null;
            SignalList.SelectedItem = null;

            updateSignalList();
            updateSignalSourceMsg();
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;

            if (vm.CurrentPatient == null)
                return;
            if (vm.CurrentUser == null)
                return;
            var signal = this.SignalList.SelectedItem as SignalSourceNums;
            if (signal == null)
                return;
            if (signal.SignalSource == null)
                return;

            CommContracts.Registration registration = new CommContracts.Registration();
            registration.PatientID = vm.CurrentPatient.ID;

            PayView payView = new PayView(0.0.ToString(), signal.SignalType.DoctorClinicFee.ToString());
            var window = new Window();

            window.Content = payView;
            window.Width = 500;
            window.Height = 300;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                registration.PayWayEnum = payView.PayWayEnum;
                registration.RegisterFee = payView.MoneyNum;
                registration.RegisterTime = DateTime.Now;
                registration.RegisterUserID = vm.CurrentUser.ID;
                registration.DepartmentID = signal.SignalSource.DepartmentID;
                registration.SignalDate = signal.SignalSource.WorkPlanDate.Value;
                CommClient.SignalTime signaltimeClient = new CommClient.SignalTime();
                List<CommContracts.SignalTime> sigTimeList = signaltimeClient.GetAllClinicVistTime();
                var query = from a in sigTimeList
                            where a.ShiftID == signal.SignalSource.ShiftID
                            select a;

                if (query.Count() == 1)
                {
                    foreach (var aa in query)
                    {
                        registration.SignalTimeID = aa.ID;
                    }
                }



                registration.RegisterFee = signal.SignalType.DoctorClinicFee;
                registration.SignalTypeID = signal.SignalType.ID;

                bool? result = vm.SaveRegistration(registration);
                if (result.HasValue)
                {
                    if (result.Value)
                    {
                        MessageBox.Show("挂号成功！");
                        clearAllDate();
                        return;
                    }
                }
            }
            MessageBox.Show("挂号失败！");
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            CommContracts.Registration registration = new CommContracts.Registration();
            registration = this.GuaHaoJiLuList.SelectedItem as CommContracts.Registration;
            if (registration == null)
                return;

            //if(registration.SignalSource.WorkPlanDate.Value.Date < DateTime.Now.Date)
            //{
            //    MessageBox.Show("超出就诊日期，不能退号！");
            //    return;
            //}
            //else if(registration.SignalSource.WorkPlanDate.Value.Date == DateTime.Now.Date)
            //{
            //    if(DateTime.Now.TimeOfDay > DateTime.Parse(registration.SignalSource.Shift.LastSellTime).TimeOfDay)
            //    {
            //        MessageBox.Show("超出退号时间，不能退号！");
            //        return;
            //    }
            //}


            var vm = this.DataContext as HISGUIFeeVM;
            CommClient.CancelRegistration cancelRegistrationClient = new CommClient.CancelRegistration();
            CommContracts.CancelRegistration cancelRegistration = new CommContracts.CancelRegistration();

            cancelRegistration.RegistrationID = registration.ID;
            cancelRegistration.CancelTime = DateTime.Now;

            if (cancelRegistrationClient.SaveCancelRegistration(cancelRegistration))
            {
                MessageBox.Show("退号成功！");
                return;
            }

            MessageBox.Show("退号失败！");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.GuaHaoJiLuGrid.Visibility != Visibility.Visible)
            {
                this.GuaHaoGrid.Visibility = Visibility.Collapsed;
                this.GuaHaoJiLuGrid.Visibility = Visibility.Visible;
            }

            var vm = this.DataContext as HISGUIFeeVM;
            if (vm.CurrentPatient == null)
                return;
            CommClient.Registration registrationClient = new CommClient.Registration();

            List<CommContracts.Registration> list = registrationClient.GetPatientRegistrations(vm.CurrentPatient.ID);
            GuaHaoJiLuList.ItemsSource = list;
        }

        private void RePrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            this.GuaHaoGrid.Visibility = Visibility.Visible;
            this.GuaHaoJiLuGrid.Visibility = Visibility.Collapsed;
        }

        private void departmentList_Selected(object sender, SelectionChangedEventArgs e)
        {
            var department = this.departmentList.SelectedItem as CommContracts.Department;
            if (department == null)
                return;

            updateSignalSourceMsg();
            updateSignalList();
        }
    }
}
