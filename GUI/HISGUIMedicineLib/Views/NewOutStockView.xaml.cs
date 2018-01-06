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
using HISGUICore.MyContorls;
using HISGUIMedicineLib.ViewModels;
using System.Data;

namespace HISGUIMedicineLib.Views
{
    [Export]
    [Export("NewOutStockView", typeof(NewOutStockView))]
    public partial class NewOutStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public NewOutStockView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.medicineInStock);
            OnStockPanel.Children.Add(myTableEdit);

            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            initBinding();
            initDate();
            initEnable();
            initVisible();
        }

        private void initBinding()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            //this.DepartmentCombo.ItemsSource = vm?.getAllDepartment();
            this.OutStockWay.ItemsSource = Enum.GetValues(typeof(CommContracts.OutStoreEnum));
        }

        private void initDate()
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            if(vm.CurrentMedicineOutStore != null)
            {
                this.myTableEdit.ClearAllDetails();

            }
        }

        private void initEnable()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            this.myTableEdit.IsEnabled = vm.IsInitViewEdit;
        }
        
        private void initVisible()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsInitViewEdit)
            {
                this.SaveBtn.Visibility = Visibility.Visible;
                this.SaveAndCheckBtn.Visibility = Visibility.Visible;
                this.EditBtn.Visibility = Visibility.Collapsed;
                this.ReCheckBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.SaveBtn.Visibility = Visibility.Collapsed;
                this.SaveAndCheckBtn.Visibility = Visibility.Collapsed;
                if (vm.CurrentMedicineInStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                {
                    this.EditBtn.Visibility = Visibility.Collapsed;
                    this.ReCheckBtn.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.EditBtn.Visibility = Visibility.Visible;
                    this.ReCheckBtn.Visibility = Visibility.Visible;
                }
            }

        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAndCheckBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReCheckBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.MedicineWorkManage();
        }

        private void DepartmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EmployeeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
