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
    [Export]
    [Export("RegistrationView", typeof(RegistrationView))]
    public partial class RegistrationView : HISGUIViewBase
    {
        public RegistrationView()
        {
            InitializeComponent();
            this.Loaded += RegistrationView_Loaded;
        }

        private void RegistrationView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            this.departmentList.ItemsSource = vm?.getAllDepartment();//数据绑定

            //vm?.newRegistrationBill();
            //vm?.getPatient();
            //vm?.initSignalTime();

            //vm?.showDepartmentSignal(0);
            //this.grid1.ItemsSource = vm._dt.DefaultView;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void ShowList(string row, string column)
        {
            DateTime date = Convert.ToDateTime(column);

            var vm = this.DataContext as HISGUIFeeVM;

            var aaa = this.departmentList.SelectedItem as CommContracts.Department;

            //this.listView1.ItemsSource = vm.getSignalSource(aaa.ID, date, Convert.ToInt32(row));

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SignalSource temp = this.listView1.SelectedItem as SignalSource;
            //var vm = this.DataContext as HISGUIFeeVM;
            //vm?.showSelectSignal(temp);
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            //bool? saveResult = vm?.SaveRegistrationBill();
            //if (!saveResult.HasValue)
            //{
            //    MessageBox.Show("保存失败！");
            //    return;
            //}
            //else if ((bool)saveResult.Value)
            //{
            //    MessageBox.Show("保存成功！");
            //    vm?.newRegistrationBill();
            //}
            //else
            //{
            //    MessageBox.Show("保存失败！");
            //    return;
            //}
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

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Patient patient = vm?.ReadCurrentPatient(8);
            decimal? dBalance = vm?.GetCurrentPatientBalance(8);
            if (patient == null)
                return;
            PatientMsg.Inlines.Clear();
            string str =
                "姓名：" + patient.Name + "\r\n" +
                "性别：" + patient.Gender + "\r\n" +
                "生日：" + patient.BirthDay + "\r\n" +
                "身份证号：" + patient.IDCardNo + "\r\n" +
                "民族：" + patient.Volk + "\r\n" +
                "籍贯：" + patient.JiGuan + "\r\n" +
                "电话：" + patient.Tel + "\r\n"
                ;
            PatientMsg.Inlines.Add(new Run(str));
            PatientMsg.Inlines.Add(new Run("账户余额：" + dBalance.Value) { Foreground = Brushes.Green, FontSize = 25 });

        }

        private void FindPatientBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void departmentList_Selected(object sender, RoutedEventArgs e)
        {
            var department = this.departmentList.SelectedItem as CommContracts.Department;
            DataTable data = new DataTable();
            var vm = this.DataContext as HISGUIFeeVM;
            data = vm?.showDepartmentSignal(department.ID);
            this.grid1.ItemsSource = data.DefaultView;
        }
    }
}
