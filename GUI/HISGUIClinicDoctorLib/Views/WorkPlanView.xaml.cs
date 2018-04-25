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
        public PaiBan()
        {
            WorkPlanIDList = new List<int>();
            WorkPlanWorkTypeList = new List<CommContracts.WorkType>();
            for (int i = 0; i < 7; i++)
            {
                WorkPlanIDList.Add(0);
                WorkPlanWorkTypeList.Add(new CommContracts.WorkType());
            }
        }

        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }

        public List<int> WorkPlanIDList { get; set; }

        public List<CommContracts.WorkType> WorkPlanWorkTypeList { get; set; }

        public int MaxVistNum { get; set; }
    }

    [Export]
    [Export("WorkPlanView", typeof(WorkPlanView))]
    public partial class WorkPlanView : HISGUIViewBase
    {
        private DateTime currentManageDate;  // 用来实现日历翻页的

        public WorkPlanView()
        {
            InitializeComponent();

            this.Loaded += ClinicManagementView_Loaded;
        }

        private void ClinicManagementView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            CommClient.Department myd = new CommClient.Department();

            CommClient.Employee employeeClient = new CommClient.Employee();
            this.DepartmentBlock.Text = employeeClient.GetCurrentDepartment(vm.CurrentUser.ID).Name;

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

            CommClient.WorkType myd = new CommClient.WorkType();
            List<CommContracts.WorkType> listOfAllWorkTypes = myd.GetAllWorkType();
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
                Binding = new Binding("ShiftName"),
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
                    SelectedItemBinding = new Binding("WorkPlanWorkTypeList["+(int)tempDate.DayOfWeek+"]"),
                    ItemsSource = listOfAllWorkTypes,
                    Width = length,
                    IsReadOnly = (tempDate.Date >= DateTime.Now.Date ? false : true)
                });
            }

            this.DateClinicMsgGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "最大工作量",
                Binding = new Binding("MaxVistNum"),
                Width = 100,
                IsReadOnly = false,
                Foreground = Brushes.Green // 设置该列字体颜色
            });
        }
        private List<PaiBan> updateDateClinicMsgGrid()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            CommClient.Employee employeeClient = new CommClient.Employee();

            var department = employeeClient.GetCurrentDepartment(vm.CurrentUser.ID);

            if (department == null)
                return null;
            if (department.ID < 0)
                return null;

            CommClient.EmployeeDepartmentHistory historyClient = new CommClient.EmployeeDepartmentHistory();
            List<CommContracts.Employee> DoctorList = historyClient.GetAllDepartmentDoctor(department.ID);
            if (DoctorList == null)
                return null;

            CommClient.Shift vistTimeClient = new CommClient.Shift();
            List<CommContracts.Shift> shiftList = vistTimeClient.GetAllShift();
            if (shiftList == null)
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

                List<CommContracts.WorkPlan> sourceList = vm?.GetSignalSourceList(department.ID, employee.ID, monday, monday.AddDays(6), 0);
                if (sourceList == null || sourceList.Count <= 0)
                {
                    foreach (var shift in shiftList)
                    {
                        PaiBan paiBan = new PaiBan();
                        paiBan.EmployeeID = employee.ID;
                        paiBan.Name = employee.Name;
                        paiBan.ShiftID = shift.ID;
                        paiBan.ShiftName = shift.Name;
                        paiBan.MaxVistNum = 0;
                        data.Add(paiBan);
                    }
                }
                else
                {
                    foreach (var vistTime in shiftList)
                    {
                        PaiBan paiBan = new PaiBan();
                        paiBan.EmployeeID = employee.ID;
                        paiBan.Name = employee.Name;

                        paiBan.ShiftID = vistTime.ID;
                        paiBan.ShiftName = vistTime.Name;

                        foreach (var tem in sourceList)
                        {
                            if (tem == null)
                                continue;
                            if (tem.ShiftID != vistTime.ID)
                                continue;

                            DayOfWeek dayOfWeek = tem.WorkPlanDate.Value.DayOfWeek;

                            paiBan.WorkPlanIDList[(int)dayOfWeek] = tem.ID;
                            paiBan.WorkPlanWorkTypeList[(int)dayOfWeek] = tem.WorkType;

                            paiBan.MaxVistNum = tem.MaxNum;
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

        /// <summary>
        /// 从界面中得到需要保存的排班记录列表
        /// 注意：界面上是从周一到周日分别对应的是0-6
        ///       然而，外国的一周是从周日开始的，所以枚举类型DayOfWeek是周日到周一对应0-6
        ///       会造成Bug
        /// </summary>
        /// <returns></returns>
        private List<CommContracts.WorkPlan> getSignalsFromView()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            CommClient.Employee employeeClient = new CommClient.Employee();

            var department = employeeClient.GetCurrentDepartment(vm.CurrentUser.ID);
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

                for (int week = 0; week < 7; week++)
                {
                    if (paiBan.WorkPlanWorkTypeList[week] != null)
                    {
                        if (paiBan.WorkPlanWorkTypeList[week].ID == 0)
                            continue;

                        CommContracts.WorkPlan signalSource = new CommContracts.WorkPlan();
                        signalSource.ID = paiBan.WorkPlanIDList[week];
                        signalSource.DepartmentID = department.ID;
                        signalSource.EmployeeID = paiBan.EmployeeID;
                        signalSource.WorkTypeID = paiBan.WorkPlanWorkTypeList[week].ID;
                        signalSource.ShiftID = paiBan.ShiftID;
                        signalSource.MaxNum = paiBan.MaxVistNum;


                        if (week == 0)
                            signalSource.WorkPlanDate = getMonday(currentManageDate).AddDays(6);
                        else
                            signalSource.WorkPlanDate = getMonday(currentManageDate).AddDays(week - 1);


                        if (signalSource.WorkPlanDate.Value.Date >= DateTime.Now.Date)
                        {
                            sourceList.Add(signalSource);
                        }
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCells = DateClinicMsgGrid.SelectedCells;

            if (selectedCells == null)
                return;

            foreach (var cellitem in selectedCells)
            {
                if (cellitem == null)
                    continue;

                PaiBan paiBan = cellitem.Item as PaiBan;

                string strColumn = cellitem.Column.Header.ToString();

                DateTime columnDate = DateTime.Parse(strColumn);

                int workPlanID = 0;

                workPlanID = paiBan.WorkPlanIDList[(int)columnDate.DayOfWeek];

                CommClient.WorkPlan workPlanClient = new CommClient.WorkPlan();
                workPlanClient.UpdateWorkPlanStatus(workPlanID, CommContracts.WorkPlanStatus.停诊);
            }

            updateDateClinicMsg();
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
