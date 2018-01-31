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
    [Export("CheckView", typeof(CheckView))]
    public partial class CheckView : HISGUIViewBase
    {
        public CheckView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        public void UpdateCheckStores()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
                ShowAllMedicineCheckStore();
            else
                ShowAllMaterialCheckStore();
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartCheckDate.SelectedDate = DateTime.Now.AddDays(-1);
            this.EndCheckDate.SelectedDate = DateTime.Now;

            UpdateCheckStores();
        }

        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCheckStores();
        }

        private void ShowAllMedicineCheckStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartCheckDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndCheckDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MedicineCheckStore> list = vm?.getAllMedicineCheckStore(
                startDateTime, endDateTime);

            this.AllCheckList.ItemsSource = list;
        }

        private void ShowAllMaterialCheckStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartCheckDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndCheckDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MaterialCheckStore> list = vm?.getAllMaterialCheckStore(
                startDateTime, endDateTime);

            this.AllCheckList.ItemsSource = list;
        }

        private void AllCheckList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
            {
                var currentOutStore = this.AllCheckList.SelectedItem as CommContracts.MedicineCheckStore;
                vm.IsInitViewEdit = false;
                vm.CurrentMedicineCheckStore = currentOutStore;
                vm?.ShowMedicineCheckStoreDetail();
            }
            else
            {
                var currentOutStore = this.AllCheckList.SelectedItem as CommContracts.MaterialCheckStore;
                vm.IsInitViewEdit = false;
                vm.CurrentMaterialCheckStore = currentOutStore;
                vm?.ShowMaterialCheckStoreDetail();
            }
        }

        private void NewCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsMedicineOrMaterial)
            {
                var currentCheckStore = new CommContracts.MedicineCheckStore();
                vm.CurrentMedicineCheckStore = currentCheckStore;
                vm.IsInitViewEdit = true;
                vm?.ShowMedicineCheckStoreDetail();
            }
            else
            {
                var currentCheckStore = new CommContracts.MaterialCheckStore();
                vm.CurrentMaterialCheckStore = currentCheckStore;
                vm.IsInitViewEdit = true;
                vm?.ShowMaterialCheckStoreDetail();
            }
        }
    }
}
