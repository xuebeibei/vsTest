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
    [Export("ItemsNumView", typeof(ItemsNumView))]
    public partial class ItemsNumView : HISGUIViewBase
    {
        public ItemsNumView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        public void UpdateNumsStores()
        {
            initGrid();
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
                ShowAllMedicineNumsStore();
            else
                ShowAllMaterialNumsStore();
        }


        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            this.SupplierNameBox.ItemsSource = vm?.getAllSupplier();
            UpdateNumsStores();
        }

        private void initGrid()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
            {
                this.AllItemsNumList.View = this.Resources["haveMedicineColumn"] as GridView;
            }
            else 
            {
                this.AllItemsNumList.View = this.Resources["haveMaterialColumn"] as GridView;
            }
            
        }

        private void ShowAllMedicineNumsStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            int nSupplierID = 0;
            var supplier = this.SupplierNameBox.SelectedItem as CommContracts.Supplier;
            if (supplier != null)
                nSupplierID = supplier.ID;

            int nCurrentItemType = -1;
            string str = this.ItemTypeCombo.Text;
            if (str == "西药")
            {
                nCurrentItemType = (int)CommContracts.MedicineTypeEnum.西药;
            }
            else if (str == "中成药")
            {
                nCurrentItemType = (int)CommContracts.MedicineTypeEnum.中成药;
            }
            else if (str == "中药")
            {
                nCurrentItemType = (int)CommContracts.MedicineTypeEnum.中药;
            }

            List<CommContracts.StoreRoomMedicineNum> list = vm?.getAllMedicineItemNum(
                FindItemNameBox.Text,
                nSupplierID,
                nCurrentItemType,
                IsStatusOkCheck.IsChecked.Value,
                IsHasNumCheck.IsChecked.Value,
                IsOverDateCheck.IsChecked.Value,
                IsNumNoEnoughCheck.IsChecked.Value);

            this.AllItemsNumList.ItemsSource = list;
        }

        private void ShowAllMaterialNumsStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            int nSupplierID = 0;
            var supplier = this.SupplierNameBox.SelectedItem as CommContracts.Supplier;
            if (supplier != null)
                nSupplierID = supplier.ID;

            int nCurrentItemType = -1;

            List<CommContracts.StoreRoomMaterialNum> list = vm?.getAllMaterialItemNum(
                FindItemNameBox.Text,
                nSupplierID,
                nCurrentItemType,
                IsStatusOkCheck.IsChecked.Value,
                IsHasNumCheck.IsChecked.Value,
                IsOverDateCheck.IsChecked.Value,
                IsNumNoEnoughCheck.IsChecked.Value);

            this.AllItemsNumList.ItemsSource = list;
        }

        private void AllItemsNumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateNumsStores();
        }
    }
}
