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
using HISGUICore.MyContorls;
using HISGUIDoctorLib.ViewModels;
using System.Data;
using System.Windows.Threading;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("BasicDataSetView", typeof(BasicDataSetView))]
    public partial class BasicDataSetView : HISGUIViewBase
    {
        public BasicDataSetView()
        {
            InitializeComponent();
            this.Loaded += WordBasicDataSetView_Loaded;
        }

        private void WordBasicDataSetView_Loaded(object sender, RoutedEventArgs e)
        {
            this.listView1.View = this.Resources["ChuZhenShiDuan"] as GridView;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyDataNameList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = MyDataNameList.SelectedItem as TreeViewItem;
            if (item == null)
                return;

            if (item.Header == null)
                return;

            if (this.listView1 == null)
                return;

            string strCurrentName = item.Header.ToString();

            SetMenuEnable(false);

            if (strCurrentName == "值班时段字典")
            {
                this.listView1.View = this.Resources["ChuZhenShiDuan"] as GridView;
                var vm = this.DataContext as HISGUIDoctorVM;

                CommClient.Shift client = new CommClient.Shift();
                List<CommContracts.Shift> list = client.GetAllShift();
                this.listView1.ItemsSource = list;
            }
            //else if (strCurrentName == "号别字典")
            //{
            //    this.listView1.View = this.Resources["HaoBie"] as GridView;
            //    var vm = this.DataContext as HISGUIDoctorVM;

            //    CommClient.SignalItem client = new CommClient.SignalItem();
            //    List<CommContracts.SignalType> list = client.GetAllSignalItem();
            //    this.listView1.ItemsSource = list;
            //}
            else if (strCurrentName == "科室字典")
            {
                this.listView1.View = this.Resources["KeShi"] as GridView;
                var vm = this.DataContext as HISGUIDoctorVM;

                CommClient.Department client = new CommClient.Department();
                List<CommContracts.Department> list = client.getALLDepartment(CommContracts.DepartmentEnum.临床科室);
                this.listView1.ItemsSource = list;
            }
            else if (strCurrentName == "医生字典")
            {
                this.listView1.View = this.Resources["YiSheng"] as GridView;
                SetMenuEnable(true);

                var vm = this.DataContext as HISGUIDoctorVM;

                CommClient.Employee employeeClient = new CommClient.Employee();
                int nCurrentDepartmentID = employeeClient.GetCurrentDepartment(vm.CurrentUser.ID).ID;
                CommClient.EmployeeDepartmentHistory historyClient = new CommClient.EmployeeDepartmentHistory();

                List<CommContracts.Employee> list = historyClient.GetAllDepartmentEmployee(nCurrentDepartmentID);
                this.listView1.ItemsSource = list;
            }
        }

        private void SetMenuEnable(bool IsEnable)
        {
            this.NewBtn.IsEnabled = IsEnable;
            this.EditBtn.IsEnabled = IsEnable;
            this.DeleteBtn.IsEnabled = IsEnable;
            this.ExportBtn.IsEnabled = IsEnable;
            this.ImportBtn.IsEnabled = IsEnable;
            this.PrintBtn.IsEnabled = IsEnable;
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TreeViewItem item = MyDataNameList.SelectedItem as TreeViewItem;
            if (item == null)
                return;

            string strCurrentName = item.Header.ToString();
            if (strCurrentName == "科室字典")
            {
                var currentDepartment = this.listView1.SelectedItem as CommContracts.Department;
                if (currentDepartment == null)
                {
                    return;
                }

                SetMenuEnable(false);
                var vm = this.DataContext as HISGUIDoctorVM;

                CommClient.Employee employeeClient = new CommClient.Employee();
                int nCurrentDepartmentID = employeeClient.GetCurrentDepartment(vm.CurrentUser.ID).ID;

                if (currentDepartment.ID == nCurrentDepartmentID)
                {
                    // 只允许修改自身所在科室的信息
                    this.EditBtn.IsEnabled = true;
                }
            }
        }
    }
}
