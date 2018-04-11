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
        }

        public SignalSourceMsg(CommContracts.ClinicVistTime signalTimeEnum)
        {
            ClinicVistTime = signalTimeEnum;
        }

        public CommContracts.ClinicVistTime ClinicVistTime { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }

    public class SignalSourceNums
    {
        public int HasUsedNum { get; set; }
        public CommContracts.WorkPlan SignalSource { get; set; }
    }

    [Export]
    [Export("RegistrationView", typeof(RegistrationView))]
    public partial class RegistrationView : HISGUIViewBase
    {
        private CommContracts.Registration currentRegistration;
        private decimal? myCurrentBalance;
        private int myCurrentPatientID;
        public RegistrationView()
        {
            InitializeComponent();
            myCurrentBalance = 0.0m;
            currentRegistration = new CommContracts.Registration();
            myCurrentPatientID = 0;
            updateSignalSourceMsg();
            this.PayWayCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PayWayEnum));
            this.ReturnWayCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PayWayEnum));
            this.Loaded += RegistrationView_Loaded;
        }

        private void RegistrationView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            this.departmentList.ItemsSource = vm?.getAllDepartment();//数据绑定
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
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

            //myCurrentPatientID = 1;// 默认值
            //var vm = this.DataContext as HISGUIFeeVM;
            //PatientMsg.Inlines.Clear();
            //myCurrentBalance = vm?.GetCurrentPatientBalance(myCurrentPatientID);
            //if (this.AddCheck.IsChecked.Value)
            //{
            //    CommContracts.Patient patient = vm?.ReadCurrentPatient(myCurrentPatientID);
            //    if (patient == null)
            //        return;

            //    string str =
            //        "姓名：" + patient.Name + "     " +
            //        "性别：" + patient.Gender + "     " +
            //        "生日：" + patient.BirthDay + "     " +
            //        "身份证号：" + patient.ZhengJianNum + "     " +
            //        "民族：" + patient.Volk + "     " +
            //        "籍贯：" + patient.JiGuan_Sheng + "     " +
            //        "电话：" + patient.Tel + "     "
            //        ;
            //    PatientMsg.Inlines.Add(new Run(str));
            //    PatientMsg.Inlines.Add(new Run("账户余额：" + myCurrentBalance.Value + "元\n")
            //    {
            //        Foreground = Brushes.Green,
            //        FontSize = 25
            //    });
            //}
            //else if (this.DeleteCheck.IsChecked.Value)
            //{
            //    currentRegistration = vm?.ReadLastRegistration(myCurrentPatientID);
            //    if (currentRegistration == null)
            //        return;
            //    if (currentRegistration.Patient == null)
            //        return;

            //    string str =
            //        "姓名：" + currentRegistration.Patient.Name + "     " +
            //        "性别：" + currentRegistration.Patient.Gender + "     " +
            //        "生日：" + currentRegistration.Patient.BirthDay + "     " +
            //        "身份证号：" + currentRegistration.Patient.ZhengJianNum + "     " +
            //        "民族：" + currentRegistration.Patient.Volk + "     " +
            //        "籍贯：" + currentRegistration.Patient.JiGuan_Sheng + "     " +
            //        "电话：" + currentRegistration.Patient.Tel + "     ";
            //    ;
            //    PatientMsg.Inlines.Add(new Run(str));
            //    PatientMsg.Inlines.Add(new Run("账户余额：" + myCurrentBalance.Value + "元\n")
            //    {
            //        Foreground = Brushes.Green,
            //        FontSize = 25
            //    });

            //    str = "号源名称：" + currentRegistration.SignalSource.SignalItem.Name + "     " +
            //        "科室：" + currentRegistration.SignalSource.DepartmentID + "     " +
            //        "看诊状态：" + currentRegistration.SeeDoctorStatus.ToString() + "     " +
            //        "看诊时间：" + currentRegistration.SignalSource.VistDate.Value.Date.ToString("yyyy-MM-dd") + "     " +
            //        "费用：" + currentRegistration.RegisterFee + "元     " +
            //        "挂号经办人：" + currentRegistration.RegisterUser.Username + "     " +
            //        "经办时间：" + currentRegistration.RegisterTime.Value.Date + "     " + "\n";
            //    PatientMsg.Inlines.Add(new Run(str));

            //    if (currentRegistration.ReturnTime.HasValue)
            //    {
            //        this.ReturnWayCombo.SelectedItem = currentRegistration.PayWayEnum;
            //        this.DueReturnMoneyEdit.Text = currentRegistration.RegisterFee.ToString();
            //        this.ServiceMoneyEdit.Text = currentRegistration.ReturnServiceMoney.ToString();
            //        this.RealPayMoneyEdit.Text = (currentRegistration.RegisterFee - currentRegistration.ReturnServiceMoney).ToString();

            //        this.ServiceMoneyEdit.IsEnabled = false;
            //        this.ReturnBtn.IsEnabled = false;
            //    }
            //    else
            //    {
            //        this.ReturnWayCombo.SelectedItem = currentRegistration.PayWayEnum;
            //        this.DueReturnMoneyEdit.Text = currentRegistration.RegisterFee.ToString();
            //        this.ServiceMoneyEdit.Focus();

            //        this.ServiceMoneyEdit.IsEnabled = true;
            //        this.ReturnBtn.IsEnabled = true;
            //    }

            //}
        }

        private void departmentList_Selected(object sender, RoutedEventArgs e)
        {
            var department = this.departmentList.SelectedItem as CommContracts.Department;
            if (department == null)
                return;

            updateSignalSourceMsg();
            updateSignalList();
        }
        private void updateSignalSourceMsg()
        {
            initSignalSourceGrid();
            this.SignalSourceGrid.ItemsSource = updateSignalSourceGrid();
        }

        private List<SignalSourceMsg> updateSignalSourceGrid()
        {
            List<SignalSourceMsg> nullData = new List<SignalSourceMsg>();

            CommClient.ClinicVistTime clinicVistClient = new CommClient.ClinicVistTime();
            List<CommContracts.ClinicVistTime> vistTimeList = new List<CommContracts.ClinicVistTime>();
            vistTimeList = clinicVistClient.GetAllClinicVistTime();

            if (vistTimeList == null)
                return null;
            else
            {
                foreach(CommContracts.ClinicVistTime tem in vistTimeList)
                {
                    nullData.Add(new SignalSourceMsg(tem));
                }
            }

            var department = this.departmentList.SelectedItem as CommContracts.Department;
            if (department == null)
                return nullData;

            var vm = this.DataContext as HISGUIFeeVM;

            List<SignalSourceMsg> data = new List<SignalSourceMsg>();

            List<CommContracts.WorkPlan> sourceList = vm?.GetDepartmentSignalSourceList(department.ID, DateTime.Now.Date, DateTime.Now.AddDays(6).Date);
            bool bIsHasRegistration = false;
            List<CommContracts.Registration> registrationList = vm?.GetDepartmentRegistrationList(department.ID, DateTime.Now.Date, DateTime.Now.AddDays(6).Date);
            if (!(registrationList == null || registrationList.Count <= 0))
            {
                bIsHasRegistration = true;
            }

            if (sourceList == null || sourceList.Count <= 0)
            {
                return nullData;
            }
            else
            {
                foreach (CommContracts.ClinicVistTime tim in vistTimeList)
                {
                    SignalSourceMsg msg = new SignalSourceMsg(tim);
                    foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                    {
                        var query = from u in sourceList
                                    where u.VistDate.Value.DayOfWeek == day 
                                    select u.MaxNum;
                        int HaveNum = query.Sum(); int UsedNum = 0;
                        if (bIsHasRegistration)
                        {
                            var regisQuery = from e in registrationList
                                             where e.SignalSource.VistDate.Value.DayOfWeek == day &&
                                             (!e.ReturnTime.HasValue)
                                             select e;
                            UsedNum = regisQuery.Count();
                        }

                        string str = HaveNum - UsedNum == 0 ? "" : (HaveNum - UsedNum).ToString();

                        switch (day)
                        {
                            case DayOfWeek.Monday:
                                {
                                    msg.Monday = str;
                                    break;
                                }
                            case DayOfWeek.Tuesday:
                                {
                                    msg.Tuesday = str;
                                    break;
                                }
                            case DayOfWeek.Wednesday:
                                {
                                    msg.Wednesday = str;
                                    break;
                                }
                            case DayOfWeek.Thursday:
                                {
                                    msg.Thursday = str;
                                    break;
                                }
                            case DayOfWeek.Saturday:
                                {
                                    msg.Saturday = str;
                                    break;
                                }
                            case DayOfWeek.Sunday:
                                {
                                    msg.Sunday = str;
                                    break;
                                }
                            case DayOfWeek.Friday:
                                {
                                    msg.Friday = str;
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    data.Add(msg);
                }
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
                Binding = new Binding("ClinicVistTime.Name"),
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
                    Binding = new Binding(tempDate.DayOfWeek.ToString()),
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
            catch(Exception ex)
            {
                string str = ex.Message;
                return;
            }

            if (dt == null)
                return;

            List<SignalSourceMsg> list = SignalSourceGrid.ItemsSource as List<SignalSourceMsg>;

            if (list != null)
            {
                CommContracts.ClinicVistTime timeEnum = list.ElementAt(rowIdnex).ClinicVistTime;

                var department = this.departmentList.SelectedItem as CommContracts.Department;
                if (department == null)
                    return;

                var vm = this.DataContext as HISGUIFeeVM;
                List<CommContracts.WorkPlan> sourceList = vm?.GetDepartmentSignalSourceList(department.ID, dt, dt);

                List<CommContracts.Registration> registrationList = vm?.GetDepartmentRegistrationList(department.ID, dt, dt);

                List<SignalSourceNums> numsList = new List<SignalSourceNums>();

                foreach (var source in sourceList)
                {
                    if (source == null)
                        continue;
                    SignalSourceNums nums = new SignalSourceNums();
                    if (!(registrationList == null || registrationList.Count <= 0))
                    {
                        int hasNum = 0;
                        var query = from u in registrationList
                                    where u.SignalSourceID == source.ID &&
                                    (!u.ReturnTime.HasValue)
                                    select u;
                        hasNum = query.Count();
                        nums.HasUsedNum = hasNum;
                    }
                    nums.SignalSource = source;
                    numsList.Add(nums);
                }


                SignalList.ItemsSource = numsList;
            }
        }

        private void AddCheck_Click(object sender, RoutedEventArgs e)
        {
            clearAllDate();
            this.PayBtn.Visibility = Visibility.Visible;
            this.ReturnBtn.Visibility = Visibility.Collapsed;
            //this.PayPanel.Visibility = Visibility.Visible;
            //this.ReturnPanel.Visibility = Visibility.Collapsed;
            this.EditGrid.Visibility = Visibility.Visible;
        }

        private void DeleteCheck_Click(object sender, RoutedEventArgs e)
        {
            clearAllDate();
            this.PayBtn.Visibility = Visibility.Collapsed;
            this.ReturnBtn.Visibility = Visibility.Visible;
            //this.PayPanel.Visibility = Visibility.Collapsed;
            //this.ReturnPanel.Visibility = Visibility.Visible;
            this.EditGrid.Visibility = Visibility.Collapsed;
        }

        private void clearAllDate()
        {
            myCurrentPatientID = 0;
            myCurrentBalance = 0;
            currentRegistration = new CommContracts.Registration();

            ReturnWayCombo.SelectedItem = null;
            DueReturnMoneyEdit.Text = "";
            ServiceMoneyEdit.Text = "";
            RealPayMoneyEdit.Text = "";

            PayWayCombo.SelectedItem = null;
            DiscountEdit.Text = "";
            DuePayMoneyEdit.Text = "";
            RealPayMoneyEdit.Text = "";
            ChargeMoneyEdit.Text = "";

            departmentList.SelectedItem = null;
            SignalSourceGrid.SelectedItem = null;
            SignalList.SelectedItem = null;

            updateSignalList();
            updateSignalSourceMsg();
        }

        private void SignalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tem = this.SignalList.SelectedItem as SignalSourceNums;
            if (tem == null)
                return;

            if (tem.SignalSource == null)
                return;

            this.DiscountEdit.Text = 0.0.ToString();
            this.DuePayMoneyEdit.Text = tem.SignalSource.Price.ToString();
            if (myCurrentBalance.Value >= tem.SignalSource.Price)
            {
                this.PayWayCombo.SelectedItem = CommContracts.PayWayEnum.账户支付;
            }
            else
            {
                this.PayWayCombo.SelectedItem = CommContracts.PayWayEnum.现金支付;
            }

            this.RealPayMoneyEdit.Focus();
        }

        private void RealPayMoneyEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal Discount = 0, DuePay = 0, RealPay = 0, charge = 0;
            Discount = string.IsNullOrEmpty(this.DiscountEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DiscountEdit.Text);
            DuePay = string.IsNullOrEmpty(this.DuePayMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DuePayMoneyEdit.Text);
            RealPay = string.IsNullOrEmpty(this.RealPayMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.RealPayMoneyEdit.Text);
            charge = RealPay - Discount - DuePay;

            this.ChargeMoneyEdit.Text = charge.ToString();
        }

        private void RealPayMoneyEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                decimal charge = string.IsNullOrEmpty(this.ChargeMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.ChargeMoneyEdit.Text);
                if (charge >= 0)
                    this.PayBtn.Focus();
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Registration registration = new CommContracts.Registration();
            registration.PatientID = myCurrentPatientID;

            if (this.PayWayCombo.SelectedItem == null)
                return;

            registration.PayWayEnum = (CommContracts.PayWayEnum)this.PayWayCombo.SelectedItem;
            registration.RegisterFee = string.IsNullOrEmpty(this.DuePayMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DuePayMoneyEdit.Text);
            registration.RegisterTime = DateTime.Now;
            if (vm.CurrentUser != null)
                registration.RegisterUserID = vm.CurrentUser.ID;
            var signal = this.SignalList.SelectedItem as SignalSourceNums;
            if (signal == null)
                return;
            if (signal.SignalSource == null)
                return;

            registration.SignalSourceID = signal.SignalSource.ID;

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
            MessageBox.Show("挂号失败！");
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            currentRegistration.ReturnServiceMoney = string.IsNullOrEmpty(this.ServiceMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.ServiceMoneyEdit.Text);
            currentRegistration.ReturnTime = DateTime.Now;

            if (vm.CurrentUser != null)
                currentRegistration.RegisterUserID = vm.CurrentUser.ID;

            bool? result = vm.UpdateRegistration(currentRegistration);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("退号成功！");
                    clearAllDate();
                    return;
                }
            }
            MessageBox.Show("退号失败！");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ServiceMoneyEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal DueReturn = 0, ServiceMoney = 0, RealReturn = 0;
            DueReturn = string.IsNullOrEmpty(this.DueReturnMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DueReturnMoneyEdit.Text);
            ServiceMoney = string.IsNullOrEmpty(this.ServiceMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.ServiceMoneyEdit.Text);
            RealReturn = DueReturn - ServiceMoney;

            this.RealReturnMoneyEdit.Text = RealReturn.ToString();
        }

        private void ServiceMoneyEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                this.ReturnBtn.Focus();
            }
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RePrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
