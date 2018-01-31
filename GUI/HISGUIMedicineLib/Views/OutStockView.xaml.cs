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
    [Export("OutStockView", typeof(OutStockView))]
    public partial class OutStockView : HISGUIViewBase
    {
        public OutStockView()
        {
            InitializeComponent();
            this.StartOutStockDate.SelectedDate = DateTime.Now.AddDays(-1);
            this.EndOutStockDate.SelectedDate = DateTime.Now;
            this.OutStoreEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.OutStoreEnum));
            this.OutStoreEnum.SelectedItem = CommContracts.OutStoreEnum.科室出库;
            this.Loaded += View_Loaded;
        }

        public void UpdateOutStores()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
                ShowAllMedicineOutStore();
            else
                ShowAllMaterialOutStore();
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOutStores();
        }

        private void ShowAllMedicineOutStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartOutStockDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndOutStockDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MedicineOutStore> list = vm?.getAllMedicineOutStore((CommContracts.OutStoreEnum)this.OutStoreEnum.SelectedItem,
                startDateTime, endDateTime, FindOutStockIDEdit.Text);

            this.AllOutStockList.ItemsSource = list;
        }

        private void ShowAllMaterialOutStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartOutStockDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndOutStockDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MaterialOutStore> list = vm?.getAllMaterialOutStore((CommContracts.OutStoreEnum)this.OutStoreEnum.SelectedItem,
                startDateTime, endDateTime, FindOutStockIDEdit.Text);

            this.AllOutStockList.ItemsSource = list;
        }

        private void AddNewOutStockBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
            {
                var currentOutStore = new CommContracts.MedicineOutStore();
                vm.CurrentMedicineOutStore = currentOutStore;
                vm.IsInitViewEdit = true;
                vm?.ShowMedicineOutStoreDetail();
            }
            else
            {
                var currentOutStore = new CommContracts.MaterialOutStore();
                vm.CurrentMaterialOutStore = currentOutStore;
                vm.IsInitViewEdit = true;
                vm?.ShowMaterialOutStoreDetail();
            }
        }

        private void AllOutStockList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
            {
                var currentOutStore = this.AllOutStockList.SelectedItem as CommContracts.MedicineOutStore;
                vm.IsInitViewEdit = false;
                vm.CurrentMedicineOutStore = currentOutStore;
                vm?.ShowMedicineOutStoreDetail();
            }
            else
            {
                var currentOutStore = this.AllOutStockList.SelectedItem as CommContracts.MaterialOutStore;
                vm.IsInitViewEdit = false;
                vm.CurrentMaterialOutStore = currentOutStore;
                vm?.ShowMaterialOutStoreDetail();
            }
        }

        private void FindOutStockBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateOutStores();
        }
    }
}
