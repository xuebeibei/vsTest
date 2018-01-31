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
using HISGUIMedicineLib.ViewModels;
using System.Data;

namespace HISGUIMedicineLib.Views
{
    [Export]
    [Export("InStockView", typeof(InStockView))]
    public partial class InStockView : HISGUIViewBase
    {
        public InStockView()
        {
            InitializeComponent();

            this.StartStockDate.SelectedDate = DateTime.Now.AddDays(-1);
            this.EndStockDate.SelectedDate = DateTime.Now;
            this.StockWay.ItemsSource = Enum.GetValues(typeof(CommContracts.InStoreEnum));
            this.StockWay.SelectedItem = CommContracts.InStoreEnum.采购入库;
            this.Loaded += View_Loaded;
        }

        public void UpdateInStores()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
                ShowAllMedicineInStore();
            else
                ShowAllMaterialInStore();
        }


        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInStores();
        }
        private void AddNewStockBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if(vm.IsMedicineOrMaterial)
            {
                var currentInStore = new CommContracts.MedicineInStore();
                vm.CurrentMedicineInStore = currentInStore;
                vm.IsInitViewEdit = true;
                vm?.ShowMedicineInStoreDetail();
            }
            else
            {
                var currentInStore = new CommContracts.MaterialInStore();
                vm.CurrentMaterialInStore = currentInStore;
                vm.IsInitViewEdit = true;
                vm?.ShowMaterialInStoreDetail();
            }
        }

        private void AllStockList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if(vm.IsMedicineOrMaterial)
            {
                var currentInStore = this.AllStockList.SelectedItem as CommContracts.MedicineInStore;
                vm.IsInitViewEdit = false;
                vm.CurrentMedicineInStore = currentInStore;
                vm?.ShowMedicineInStoreDetail();
            }
            else
            {
                var currentInStore = this.AllStockList.SelectedItem as CommContracts.MaterialInStore;
                vm.IsInitViewEdit = false;
                vm.CurrentMaterialInStore = currentInStore;
                vm?.ShowMaterialInStoreDetail();
            }
            
        }

        private void ShowAllMedicineInStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartStockDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndStockDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MedicineInStore> list = vm?.getAllMedicineInStore((CommContracts.InStoreEnum)this.StockWay.SelectedItem,
                startDateTime, endDateTime, FindStockIDEdit.Text);

            this.AllStockList.ItemsSource = list;
        }
        private void ShowAllMaterialInStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartStockDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndStockDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MaterialInStore> list = vm?.getAllMaterialInStore((CommContracts.InStoreEnum)this.StockWay.SelectedItem,
                startDateTime, endDateTime, FindStockIDEdit.Text);

            this.AllStockList.ItemsSource = list;
        }


        private void FindStockBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateInStores();
        }
    }
}
