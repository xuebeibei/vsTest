﻿using System;
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

            for (int i = 0; i < 7; i++)
            {
                DateTime tempDate = getMonday(currentManageDate).AddDays(i);
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
            var department = this.DepartmentCombo.SelectedItem as CommContracts.Department;
            if (department == null)
                return null;
            if (department.ID < 0)
                return null;

            var vm = this.DataContext as HISGUIDoctorVM;
            DateTime monday = getMonday(currentManageDate);

            List<PaiBan> data = new List<PaiBan>();
            for (int i = 0; i < this.EmployeeCombo.Items.Count; i++)
            {
                CommContracts.Employee employee = this.EmployeeCombo.Items.GetItemAt(i) as CommContracts.Employee;
                if (employee == null)
                    continue;

                List<CommContracts.SignalSource> sourceList = vm?.GetSignalSourceList(department.ID, employee.ID, monday, monday.AddDays(6));
                if (sourceList == null || sourceList.Count <= 0)
                {
                    PaiBan paiBan = new PaiBan();
                    paiBan.EmployeeID = employee.ID;
                    paiBan.Name = employee.Name;
                    data.Add(paiBan);
                }
                else
                {
                    PaiBan paiBan = new PaiBan();
                    paiBan.EmployeeID = employee.ID;
                    paiBan.Name = employee.Name;

                    foreach (var tem in sourceList)
                    {
                        if (tem == null)
                            continue;
                       
                        DayOfWeek dayOfWeek = tem.VistTime.Value.DayOfWeek;

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
            return data;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<CommContracts.SignalSource> sourceList = getSignalsFromView();
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

        private List<CommContracts.SignalSource> getSignalsFromView()
        {
            var department = this.DepartmentCombo.SelectedItem as CommContracts.Department;
            if (department == null)
                return null;
            if (department.ID < 0)
                return null;

            List<PaiBan> list = this.DateClinicMsgGrid.ItemsSource as List<PaiBan>;
            if (list == null)
                return null;

            List<CommContracts.SignalSource> sourceList = new List<CommContracts.SignalSource>();

            for (int i = 0; i < list.Count; i++)
            {
                PaiBan paiBan = list.ElementAt(i);
                if (paiBan == null)
                    continue;

                if (paiBan.EmployeeID <= 0)
                    continue;

                if (paiBan.Monday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Monday.MaxNum;
                    signalSource.Price = paiBan.Monday.SellPrice;
                    signalSource.SignalItemID = paiBan.Monday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(0);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }

                if (paiBan.Tuesday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Tuesday.MaxNum;
                    signalSource.Price = paiBan.Tuesday.SellPrice;
                    signalSource.SignalItemID = paiBan.Tuesday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(1);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Wednesday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Wednesday.MaxNum;
                    signalSource.Price = paiBan.Wednesday.SellPrice;
                    signalSource.SignalItemID = paiBan.Wednesday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(2);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }

                if (paiBan.Thursday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Thursday.MaxNum;
                    signalSource.Price = paiBan.Thursday.SellPrice;
                    signalSource.SignalItemID = paiBan.Thursday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(3);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Friday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Friday.MaxNum;
                    signalSource.Price = paiBan.Friday.SellPrice;
                    signalSource.SignalItemID = paiBan.Friday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(4);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Saturday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Saturday.MaxNum;
                    signalSource.Price = paiBan.Saturday.SellPrice;
                    signalSource.SignalItemID = paiBan.Saturday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(5);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
                    {
                        sourceList.Add(signalSource);
                    }
                }


                if (paiBan.Sunday != null)
                {
                    CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
                    signalSource.DepartmentID = department.ID;
                    signalSource.EmployeeID = paiBan.EmployeeID;
                    signalSource.MaxNum = paiBan.Sunday.MaxNum;
                    signalSource.Price = paiBan.Sunday.SellPrice;
                    signalSource.SignalItemID = paiBan.Sunday.ID;
                    signalSource.VistTime = getMonday(currentManageDate).AddDays(6);
                    if (signalSource.VistTime.Value.Date >= DateTime.Now.Date)
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
