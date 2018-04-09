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
using HISGUIDoctorLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUIDoctorLib.Views
{
    public class PaiBan
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int VistTimeID { get; set; }
        public string VistTimeName { get; set; }
        public CommContracts.SignalItem Monday { get; set; }
        public CommContracts.SignalItem Tuesday { get; set; }
        public CommContracts.SignalItem Wednesday { get; set; }
        public CommContracts.SignalItem Thursday { get; set; }
        public CommContracts.SignalItem Friday { get; set; }
        public CommContracts.SignalItem Saturday { get; set; }
        public CommContracts.SignalItem Sunday { get; set; }
    }

    [Export]
    [Export("ClinicManagementView", typeof(ClinicManagementView))]
    public partial class ClinicManagementView : HISGUIViewBase
    {
        private DateTime currentManageDate;  // 用来实现日历翻页的

        public ClinicManagementView()
        {
            InitializeComponent();

            this.Loaded += ClinicManagementView_Loaded;
        }

        private void ClinicManagementView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            CommClient.Department myd = new CommClient.Department();
            this.DepartmentBlock.Text = vm.CurrentUser.Employee.Department.Name;

            currentManageDate = DateTime.Now.Date;
            updateDateMsg();

            updateDateClinicMsg();
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void updateDateMsg()
        {
            this.DateMsg.Inlines.Clear();

            DateTime startWeek = getMonday(currentManageDate);  //周一  
            DateTime endWeek = startWeek.AddDays(6);  //周日 
            string str = startWeek.ToString("yyyy年MM月dd日") + "-" + endWeek.ToString("yyyy年MM月dd日");

            this.DateMsg.Inlines.Add(new Run(str) { FontSize = 20 });
        }

        private void LastWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            currentManageDate = currentManageDate.AddDays(-7);
            updateDateMsg();
            updateDateClinicMsg();
        }

        private void NextWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            currentManageDate = currentManageDate.AddDays(7);
            updateDateMsg();
            updateDateClinicMsg();
        }

        private void NowWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            currentManageDate = DateTime.Now.Date;
            updateDateMsg();
            updateDateClinicMsg();
        }

        private void updateDateClinicMsg()
        {
            initDateClinicMsgGrid();
            this.DateClinicMsgGrid.ItemsSource = updateDateClinicMsgGrid();
        }


        private void initDateClinicMsgGrid()
        {
            this.DateClinicMsgGrid.Columns.Clear();

            CommClient.SignalItem myd = new CommClient.SignalItem();
            List<CommContracts.SignalItem> listOfAllSignalItems = myd.GetAllSignalItem();
            DataGridLength length = new DataGridLength(1, DataGridLengthUnitType.Star);



            this.DateClinicMsgGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "人员",
                Binding = new Binding("Name"),
                Width = 100,
                IsReadOnly = true
                //,
                //Foreground = Brushes.Blue // 设置该列字体颜色
            });

            this.DateClinicMsgGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "时段",
                Binding = new Binding("VistTimeName"),
                Width = 100,
                IsReadOnly = true
                //,
                //Foreground = Brushes.Blue // 设置该列字体颜色
            });

            for (int i = 0; i < 7; i++)
            {
                DateTime tempDate = getMonday(currentManageDate).AddDays(i);
                this.DateClinicMsgGrid.Columns.Add(new DataGridComboBoxColumn()
                {
                    Header = tempDate.ToString("yyyy-MM-dd dddd"),
                    SelectedItemBinding = new Binding(tempDate.DayOfWeek.ToString()),
                    ItemsSource = listOfAllSignalItems,
                    Width = length,
                    IsReadOnly = (tempDate.Date >= DateTime.Now.Date ? false : true)
                });
            }
        }
        private List<PaiBan> updateDateClinicMsgGrid()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            var department = vm.CurrentUser.Employee.Department;
            if (department == null)
                return null;
            if (department.ID < 0)
                return null;

            CommClient.Employee employeeClient = new CommClient.Employee();
            List<CommContracts.Employee> DoctorList = employeeClient.getAllDoctor(department.ID);
            if (DoctorList == null)
                return null;

            CommClient.ClinicVistTime vistTimeClient = new CommClient.ClinicVistTime();
            List<CommContracts.ClinicVistTime> vistTimeList = vistTimeClient.GetAllClinicVistTime();
            if (vistTimeList == null)
            {
                return null;
            }

            DateTime monday = getMonday(currentManageDate);

            List<PaiBan> data = new List<PaiBan>();
            for (int i = 0; i < DoctorList.Count(); i++)
            {
                CommContracts.Employee employee = DoctorList.ElementAt(i);
                if (employee == null)
                    continue;

                List<CommContracts.WorkPlan> sourceList = vm?.GetSignalSourceList(department.ID, employee.ID, monday, monday.AddDays(6));
                if (sourceList == null || sourceList.Count <= 0)
                {
                    foreach (var vistTime in vistTimeList)
                    {
                        PaiBan paiBan = new PaiBan();
                        paiBan.EmployeeID = employee.ID;
                        paiBan.Name = employee.Name;
                        paiBan.VistTimeID = vistTime.ID;
                        paiBan.VistTimeName = vistTime.Name;
                        data.Add(paiBan);
                    }
                }
                else
                {
                    foreach (var vistTime in vistTimeList)
                    {
                        PaiBan paiBan = new PaiBan();
                        paiBan.EmployeeID = employee.ID;
                        paiBan.Name = employee.Name;

                        paiBan.VistTimeID = vistTime.ID;
                        paiBan.VistTimeName = vistTime.Name;

                        foreach (var tem in sourceList)
                        {
                            if (tem == null)
                                continue;
                            if (tem.ClinicVistTimeID != vistTime.ID)
                                continue;
                            
                            DayOfWeek dayOfWeek = tem.VistDate.Value.DayOfWeek;

                            switch (dayOfWeek)
                            {
                                case DayOfWeek.Monday:
                                    {
                                        paiBan.Monday = tem.SignalItem;
                                    }
                                    break;
                                case DayOfWeek.Tuesday:
                                    {
                                        paiBan.Tuesday = tem.SignalItem;
                                    }
                                    break;
                                case DayOfWeek.Wednesday:
                                    {
                                        paiBan.Wednesday = tem.SignalItem;
                                    }
                                    break;
                                case DayOfWeek.Thursday:
                                    {
                                        paiBan.Thursday = tem.SignalItem;
                                    }
                                    break;
                                case DayOfWeek.Saturday:
                                    {
                                        paiBan.Saturday = tem.SignalItem;
                                    }
                                    break;
                                case DayOfWeek.Sunday:
                                    {
                                        paiBan.Sunday = tem.SignalItem;
                                    }
                                    break;
                                case DayOfWeek.Friday:
                                    {
                                        paiBan.Friday = tem.SignalItem;
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        data.Add(paiBan);
                    }
                }

            }
            return data;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<CommContracts.WorkPlan> sourceList = getSignalsFromView();
            if (sourceList != null)
            {
                if (sourceList.Count > 0)
                {
                    var vm = this.DataContext as HISGUIDoctorVM;
                    bool? result = vm?.SaveSignalSourceList(sourceList);
                    if (result.HasValue)
                    {
                        if (result.Value)
                        {
                            MessageBox.Show("门诊号源保存成功！");
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("门诊号源保存失败！");
        }

        private List<CommContracts.WorkPlan> getSignalsFromView()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            var department = vm.CurrentUser.Employee.Department;
            if (department == null)
                return null;
            if (department.ID < 0)
                return null;


            List<PaiBan> list = this.DateClinicMsgGrid.ItemsSource as List<PaiBan>;
            if (list == null)
                return null;

            List<CommContracts.WorkPlan> sourceList = new List<CommContracts.WorkPlan>();

            for (int i = 0; i < list.Count; i++)
            {
                PaiBan paiBan = list.ElementAt(i);
                if (paiBan == null)
                    continue;

                if (paiBan.EmployeeID <= 0)
                    continue;

                if (paiBan.Monday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Monday.SellPrice;
                    signalSource.SignalItemID = paiBan.Monday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(0);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }

                if (paiBan.Tuesday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Tuesday.SellPrice;
                    signalSource.SignalItemID = paiBan.Tuesday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(1);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Wednesday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Wednesday.SellPrice;
                    signalSource.SignalItemID = paiBan.Wednesday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(2);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }

                if (paiBan.Thursday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Thursday.SellPrice;
                    signalSource.SignalItemID = paiBan.Thursday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(3);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Friday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Friday.SellPrice;
                    signalSource.SignalItemID = paiBan.Friday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(4);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Saturday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Saturday.SellPrice;
                    signalSource.SignalItemID = paiBan.Saturday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(5);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Sunday != null)
                {
                    CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.Price = paiBan.Sunday.SellPrice;
                    signalSource.SignalItemID = paiBan.Sunday.ID;
                    signalSource.ClinicVistTimeID = paiBan.VistTimeID;
                    signalSource.VistDate = getMonday(currentManageDate).AddDays(6);
                    if (signalSource.VistDate.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }
            }
            return sourceList;
        }

        private DateTime getMonday(DateTime dt)
        {
            DateTime tempDate = dt.AddDays(1 - Convert.ToInt32(currentManageDate.DayOfWeek.ToString("d")));
            return tempDate;
        }

    }
}
