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
    [Export("MedicineWorkView", typeof(MedicineWorkView))]
    public partial class MedicineWorkView : HISGUIViewBase
    {
        public MedicineWorkView()
        {
            InitializeComponent();
            CommClient.StoreRoom myd = new CommClient.StoreRoom();
            List<CommContracts.StoreRoom> storeRoomList = myd.GetAllStoreRoom();
            
            if(!(storeRoomList == null || storeRoomList.Count<=0))
            {
                this.StoreCombo.ItemsSource = storeRoomList;
                this.StoreCombo.SelectedItem = storeRoomList.ElementAt(0);
            }

            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if(this.MedicineRadio.IsChecked.Value)
                vm.IsMedicineOrMaterial = true;
            else if(this.MaterialRadio.IsChecked.Value)
                vm.IsMedicineOrMaterial = false;

            vm.CurrentStoreRoom = (CommContracts.StoreRoom)this.StoreCombo.SelectedItem;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.RegionManager.RequestNavigate("MainRegion", "HISGUILoginView");
        }

        private void MedicineRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm.IsMedicineOrMaterial = true;
            UpdateAllBills();
        }

        private void MaterialRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm.IsMedicineOrMaterial = false;
            UpdateAllBills();
        }

        private void UpdateAllBills()
        {
            if (this.tabControl.SelectedIndex == 0)
            {
                this.InStockView.UpdateInStores();
            }
            else if(this.tabControl.SelectedIndex == 1)
            {
                this.OutStockView.UpdateOutStores();
            }
            else if(this.tabControl.SelectedIndex == 2)
            {
                this.ItemsNumView.UpdateNumsStores();
            }
            else if(this.tabControl.SelectedIndex == 3)
            {
                this.CheckView.UpdateCheckStores();
            }
        }
    }
}
