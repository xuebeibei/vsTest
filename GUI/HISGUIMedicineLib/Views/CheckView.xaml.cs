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

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartCheckDate.SelectedDate = DateTime.Now.AddDays(-1);
            this.EndCheckDate.SelectedDate = DateTime.Now;

            getAllMedicineCheckStore();
        }

        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            getAllMedicineCheckStore();
        }

        private void getAllMedicineCheckStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            DateTime startDateTime = this.StartCheckDate.SelectedDate.Value.Date;
            DateTime endDateTime = this.EndCheckDate.SelectedDate.Value.Date;
            endDateTime = endDateTime.AddDays(1);
            endDateTime = endDateTime.AddSeconds(-1);

            List<CommContracts.MedicineCheckStore> list = vm?.getAllMedicineCheckStore(1,
                startDateTime, endDateTime);

            this.AllCheckList.ItemsSource = list;
        }

        private void AllCheckList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentOutStore = this.AllCheckList.SelectedItem as CommContracts.MedicineCheckStore;

            var vm = this.DataContext as HISGUIMedicineVM;
            vm.IsInitViewEdit = false;
            vm.CurrentMedicineCheckStore = currentOutStore;
            vm?.ShowCheckStoreDetail();
        }

        private void NewCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            var currentCheckStore = new CommContracts.MedicineCheckStore();
            vm.CurrentMedicineCheckStore = currentCheckStore;
            vm.IsInitViewEdit = true;
            vm?.ShowCheckStoreDetail();
        }
    }
}
