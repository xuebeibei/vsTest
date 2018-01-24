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
            CommClient.Department myd = new CommClient.Department();
            this.DepartmentCombo.ItemsSource = myd.getALLDepartment(CommContracts.DepartmentEnum.临床科室);

            currentManageDate = DateTime.Now.Date;
            updateDateMsg();

            updateDateClinicMsg();
            this.Loaded += ClinicManagementView_Loaded;
        }

        private void ClinicManagementView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void DepartmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var department = this.DepartmentCombo.SelectedItem as CommContracts.Department;
            if (department == null)
                return;
            CommClient.Employee myd = new CommClient.Employee();
            this.EmployeeCombo.ItemsSource = myd.getAllDoctor(department.ID);

            updateDateClinicMsg();
        }
        private void updateDateMsg()
        {
            this.DateMsg.Inlines.Clear();

            DateTime startWeek = currentManageDate.AddDays(1 - Convert.ToInt32(currentManageDate.DayOfWeek.ToString("d")));  //周一  
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

            for (int i = 0; i < 7; i++)
            {
                DateTime tempDate = currentManageDate.AddDays(1 - Convert.ToInt32(currentManageDate.DayOfWeek.ToString("d"))).AddDays(i);
                this.DateClinicMsgGrid.Columns.Add(new DataGridComboBoxColumn()
                {
                    Header = tempDate.ToString("yyyy-MM-dd dddd") + (tempDate.Date == DateTime.Now.Date ? "*" : ""),
                    SelectedItemBinding = new Binding(tempDate.DayOfWeek.ToString()),
                    ItemsSource = listOfAllSignalItems,
                    Width = length,
                    IsReadOnly = (tempDate.Date >= DateTime.Now.Date ? false : true)
                });
            }

        }
        private List<PaiBan> updateDateClinicMsgGrid()
        {
            List<PaiBan> data = new List<PaiBan>();
            for (int i = 0; i < this.EmployeeCombo.Items.Count; i++)
            {
                CommContracts.Employee employee = this.EmployeeCombo.Items.GetItemAt(i) as CommContracts.Employee;
                if (employee == null)
                    continue;
                PaiBan paiBan = new PaiBan();
                paiBan.EmployeeID = employee.ID;
                paiBan.Name = employee.Name;
                data.Add(paiBan);
            }
            return data;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<PaiBan> list = this.DateClinicMsgGrid.ItemsSource as List<PaiBan>;
            if (list == null)
                return;
            for (int i = 0; i < list.Count; i++)
            {
                CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
            }
        }

    }
}
