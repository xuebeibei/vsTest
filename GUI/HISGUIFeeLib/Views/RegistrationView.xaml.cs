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

namespace HISGUIFeeLib.Views
{
    public class SignalSourceMsg
    {
        public SignalSourceMsg()
        {
            TimeEnum = CommContracts.SignalTimeEnum.上午;
        }

        public SignalSourceMsg(CommContracts.SignalTimeEnum signalTimeEnum)
        {
            TimeEnum = signalTimeEnum;
        }

        public CommContracts.SignalTimeEnum TimeEnum { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
    [Export]
    [Export("RegistrationView", typeof(RegistrationView))]
    public partial class RegistrationView : HISGUIViewBase
    {
        private CommContracts.Registration currentRegistration;
        private decimal? currentPatientBalance;
        public RegistrationView()
        {
            InitializeComponent();
            currentPatientBalance = 0.0m;
            currentRegistration = new CommContracts.Registration();
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

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            PatientMsg.Inlines.Clear();
            currentPatientBalance = vm?.GetCurrentPatientBalance(1);
            if (this.AddCheck.IsChecked.Value)
            {
                CommContracts.Patient patient = vm?.ReadCurrentPatient(1);
                if (patient == null)
                    return;
                
                string str =
                    "姓名：" + patient.Name + "     " +
                    "性别：" + patient.Gender + "     " +
                    "生日：" + patient.BirthDay + "     " +
                    "身份证号：" + patient.IDCardNo + "     " +
                    "民族：" + patient.Volk + "     " +
                    "籍贯：" + patient.JiGuan + "     " +
                    "电话：" + patient.Tel + "     "
                    ;
                PatientMsg.Inlines.Add(new Run(str));
                PatientMsg.Inlines.Add(new Run("账户余额：" + currentPatientBalance.Value + "元\n")
                {
                    Foreground = Brushes.Green,
                    FontSize = 25
                });
            }
            else if (this.DeleteCheck.IsChecked.Value)
            {
                currentRegistration = vm?.ReadLastRegistration(1);
                if (currentRegistration == null)
                    return;
                if (currentRegistration.Patient == null)
                    return;

                string str =
                    "姓名：" + currentRegistration.Patient.Name + "     " +
                    "性别：" + currentRegistration.Patient.Gender + "     " +
                    "生日：" + currentRegistration.Patient.BirthDay + "     " +
                    "身份证号：" + currentRegistration.Patient.IDCardNo + "     " +
                    "民族：" + currentRegistration.Patient.Volk + "     " +
                    "籍贯：" + currentRegistration.Patient.JiGuan + "     " +
                    "电话：" + currentRegistration.Patient.Tel + "     ";
                ;
                PatientMsg.Inlines.Add(new Run(str));
                PatientMsg.Inlines.Add(new Run("账户余额：" + currentPatientBalance.Value + "元\n")
                {
                    Foreground = Brushes.Green,
                    FontSize = 25
                });

                str = "号源名称：" + currentRegistration.SignalSource.SignalItem.Name + "     " + 
                    "科室：" + currentRegistration.SignalSource.DepartmentID + "     " +
                    "看诊状态：" + currentRegistration.SeeDoctorStatus.ToString() + "     " +
                    "看诊时间：" + currentRegistration.SignalSource.VistTime.Value.Date.ToString("yyyy-MM-dd") + "     " +
                    "时段：" + currentRegistration.SignalSource.SignalItem.SignalTimeEnum + "     " +
                    "费用：" + currentRegistration.RegisterFee + "元     " +
                    "挂号经办人：" + currentRegistration.RegisterUser.Username + "     " +
                    "经办时间：" + currentRegistration.RegisterTime.Value.Date + "     " +"\n";
                PatientMsg.Inlines.Add(new Run(str));

                if(currentRegistration.ReturnTime.HasValue)
                {
                    this.ReturnWayCombo.SelectedItem = currentRegistration.PayWayEnum;
                    this.DueReturnMoneyEdit.Text = currentRegistration.RegisterFee.ToString();
                    this.ServiceMoneyEdit.Text = currentRegistration.ReturnServiceMoney.ToString();
                    this.RealPayMoneyEdit.Text = (currentRegistration.RegisterFee - currentRegistration.ReturnServiceMoney).ToString();

                    this.ServiceMoneyEdit.IsEnabled = false;
                    this.ReturnBtn.IsEnabled = false;
                }
                else
                {
                    this.ReturnWayCombo.SelectedItem = currentRegistration.PayWayEnum;
                    this.DueReturnMoneyEdit.Text = currentRegistration.RegisterFee.ToString();
                    this.ServiceMoneyEdit.Focus();

                    this.ServiceMoneyEdit.IsEnabled = true;
                    this.ReturnBtn.IsEnabled = true;
                }
                
            }
        }

        private void FindPatientBtn_Click(object sender, RoutedEventArgs e)
        {

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
            nullData.Add(new SignalSourceMsg(CommContracts.SignalTimeEnum.上午));
            nullData.Add(new SignalSourceMsg(CommContracts.SignalTimeEnum.下午));
            nullData.Add(new SignalSourceMsg(CommContracts.SignalTimeEnum.晚上));

            var department = this.departmentList.SelectedItem as CommContracts.Department;
            if (department == null)
                return nullData;

            var vm = this.DataContext as HISGUIFeeVM;

            List<SignalSourceMsg> data = new List<SignalSourceMsg>();

            List<CommContracts.SignalSource> sourceList = vm?.GetDepartmentSignalSourceList(department.ID, DateTime.Now.Date, DateTime.Now.AddDays(6).Date);
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
                foreach (CommContracts.SignalTimeEnum tim in Enum.GetValues(typeof(CommContracts.SignalTimeEnum)))
                {
                    SignalSourceMsg msg = new SignalSourceMsg(tim);
                    foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                    {
                        var query = from u in sourceList
                                    where u.VistTime.Value.DayOfWeek == day &&
                                    u.SignalItem.SignalTimeEnum == tim
                                    select u.MaxNum;
                        int HaveNum = query.Sum(); int UsedNum = 0;
                        if (bIsHasRegistration)
                        {
                            var regisQuery = from e in registrationList
                                             where e.SignalSource.VistTime.Value.DayOfWeek == day &&
                                             e.SignalSource.SignalItem.SignalTimeEnum == tim
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
                Binding = new Binding("TimeEnum"),
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

            DateTime dt = DateTime.ParseExact(data, "yyyy-MM-dd dddd", System.Globalization.CultureInfo.CurrentCulture);
            if (dt == null)
                return;
            List<SignalSourceMsg> list = SignalSourceGrid.ItemsSource as List<SignalSourceMsg>;

            if (list != null)
            {
                CommContracts.SignalTimeEnum timeEnum = list.ElementAt(rowIdnex).TimeEnum;

                var department = this.departmentList.SelectedItem as CommContracts.Department;
                if (department == null)
                    return;

                var vm = this.DataContext as HISGUIFeeVM;
                List<CommContracts.SignalSource> sourceList = vm?.GetDepartmentSignalSourceList(department.ID, dt, dt);
                SignalList.ItemsSource = sourceList;
            }
        }

        private void AddCheck_Click(object sender, RoutedEventArgs e)
        {
            initDate();
            this.PayBtn.Visibility = Visibility.Visible;
            this.ReturnBtn.Visibility = Visibility.Collapsed;
            this.PayPanel.Visibility = Visibility.Visible;
            this.ReturnPanel.Visibility = Visibility.Collapsed;
            this.EditGrid.Visibility = Visibility.Visible;
        }

        private void DeleteCheck_Click(object sender, RoutedEventArgs e)
        {
            initDate();
            this.PayBtn.Visibility = Visibility.Collapsed;
            this.ReturnBtn.Visibility = Visibility.Visible;
            this.PayPanel.Visibility = Visibility.Collapsed;
            this.ReturnPanel.Visibility = Visibility.Visible;
            this.EditGrid.Visibility = Visibility.Collapsed;
        }

        private void initDate()
        {
            PatientMsg.Inlines.Clear();
            ReturnWayCombo.SelectedItem = null;
            DueReturnMoneyEdit.Text = "";
            ServiceMoneyEdit.Text = "";
            RealPayMoneyEdit.Text = "";
        }

        private void SignalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tem = this.SignalList.SelectedItem as CommContracts.SignalSource;
            if (tem == null)
                return;

            this.DiscountEdit.Text = 0.0.ToString();
            this.DuePayMoneyEdit.Text = tem.Price.ToString();
            if (currentPatientBalance.Value >= tem.Price)
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
                this.PayBtn.Focus();
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            CommContracts.Registration registration = new CommContracts.Registration();
            registration.PatientID = 1;

            registration.PayWayEnum = (CommContracts.PayWayEnum)this.PayWayCombo.SelectedItem;
            registration.RegisterFee = string.IsNullOrEmpty(this.DuePayMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DuePayMoneyEdit.Text);
            registration.RegisterTime = DateTime.Now;
            registration.RegisterUserID = 1;
            var signal = this.SignalList.SelectedItem as CommContracts.SignalSource;
            if (signal == null)
                return;

            registration.SignalSourceID = signal.ID;

            var vm = this.DataContext as HISGUIFeeVM;
            bool? result = vm.SaveRegistration(registration);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("挂号成功！");
                    return;
                }
            }
            MessageBox.Show("挂号失败！");
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            currentRegistration.ReturnServiceMoney = string.IsNullOrEmpty(this.ServiceMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.ServiceMoneyEdit.Text);
            currentRegistration.ReturnTime = DateTime.Now;
            currentRegistration.ReturnUserID = 1;

            var vm = this.DataContext as HISGUIFeeVM;
            bool? result = vm.UpdateRegistration(currentRegistration);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("退号成功！");
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
    }
}
