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
using HISGUISetLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;
using Microsoft.Win32;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("DepartmentSetView", typeof(DepartmentSetView))]
    public partial class DepartmentSetView : HISGUIViewBase
    {
        public DepartmentSetView()
        {
            InitializeComponent();
            this.Loaded += DepartmentSetView_Loaded;
        }

        private void DepartmentSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增科室
            var window = new Window();

            EditDepartmentView eidtDepartment = new EditDepartmentView();
            window.Content = eidtDepartment;
            window.Width = 400;
            window.Height = 300;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("科室新建完成！");
                UpdateAllDate();
            }
        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentDapertment = this.AllDepartmentList.SelectedItem as CommContracts.Department;
            if (currentDapertment == null)
                return;

            if(MessageBox.Show("确认删除该科室？","删除",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteDepartment(currentDapertment.ID);
                if (bIsOK.HasValue)
                {
                    if(bIsOK.Value)
                    {
                        MessageBox.Show("科室删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllDepartmentList.SelectedItem as CommContracts.Department;
            if (temp == null)
                return;

            // 新增科室
            var window = new Window();

            EditDepartmentView eidtDepartment = new EditDepartmentView(temp);
            window.Content = eidtDepartment;
            window.Width = 400;
            window.Height = 300;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("科室修改完成！");
                UpdateAllDate();
            }
        }

        private void ExportItemBtn_Click(object sender, RoutedEventArgs e)
        {
            //ExportToExecl();
        }

        private void ImportItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllDepartmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateAllDate(string strName = "")
        {
            var vm = this.DataContext as HISGUISetVM;
            this.AllDepartmentList.ItemsSource = vm?.GetFindAllDepartment(strName);
        }

    }
}
