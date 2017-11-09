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
using HISGUIRegistrationLib.ViewModels;
using System.Data;

namespace HISGUIRegistrationLib.Views
{
    [Export]
    [Export("HISGUIRegistrationView", typeof(HISGUIRegistrationView))]
    public partial class HISGUIRegistrationView : HISGUIViewBase
    {
        public HISGUIRegistrationView()
        {
            InitializeComponent();
            this.Loaded += Login_Loaded;
        }

        [Import]
        private HISGUIRegistrationVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIRegistrationVM;
            this.departmentTree.ItemsSource = vm?.getTrees(0, vm?.getDepts());//数据绑定

            vm?.newRegistrationBill();
            vm?.getPatient();
            vm?.initSignalTime();

            vm?.showDepartmentSignal(0);
            this.grid1.ItemsSource = vm._dt.DefaultView;
        }

        private void departmentTree_Selected(object sender, RoutedEventArgs e)
        {
            var aaa =  this.departmentTree.SelectedItem as CommContracts.Department;

            var vm = this.DataContext as HISGUIRegistrationVM;
            vm?.showDepartmentSignal(aaa.ID);
            this.grid1.ItemsSource = vm._dt.DefaultView;
        }

        private void ShowList(string row,  string column)
        {
            DateTime date = Convert.ToDateTime(column);
            
            var vm = this.DataContext as HISGUIRegistrationVM;

            var aaa = this.departmentTree.SelectedItem as CommContracts.Department;

            this.listView1.ItemsSource = vm.getSignalSource(aaa.ID, date, Convert.ToInt32(row));
            
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SignalSource temp = this.listView1.SelectedItem as SignalSource;
            var vm = this.DataContext as HISGUIRegistrationVM;
            vm?.showSelectSignal(temp);
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIRegistrationVM;
            bool? saveResult = vm?.SaveRegistrationBill();
            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                vm?.newRegistrationBill();
            }
            else
            {
                MessageBox.Show("保存失败！");
                return;
            }
        }

        private void grid1_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            try
            {
                //string columnIndex = dg.SelectedCells[0].Column.ToString();  // 列坐标
                //var rowIdnex = dg.Items.IndexOf(dg.SelectedCells[0].Item);   // 行坐标
                string data = dg.SelectedCells[0].Column.Header.ToString();
                var temp = dg.SelectedCells[0].Item as DataRowView;
                var index = temp[0].ToString();


                ShowList(index, data);
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
