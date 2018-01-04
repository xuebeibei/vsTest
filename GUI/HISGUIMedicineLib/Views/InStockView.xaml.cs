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
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartStockDate.SelectedDate = DateTime.Now.AddDays(-1);
            this.EndStockDate.SelectedDate = DateTime.Now;
            this.StockWay.ItemsSource = Enum.GetValues(typeof(CommContracts.InStoreEnum));
            this.StockWay.SelectedItem = CommContracts.InStoreEnum.采购入库;
            getAllMedicineInStore();

        }
        private void AddNewStockBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            var currentInStore = new CommContracts.MedicineInStore();
            vm.CurrentMedicineInStore = currentInStore;
            vm?.NewInStore();
        }

        private void AllStockList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentInStore = this.AllStockList.SelectedItem as CommContracts.MedicineInStore;

            var vm = this.DataContext as HISGUIMedicineVM;

            vm.CurrentMedicineInStore = currentInStore;
            vm?.NewInStore();
        }

        private void getAllMedicineInStore()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            List<CommContracts.MedicineInStore> list = vm?.getAllMedicineInStore(1, (CommContracts.InStoreEnum)this.StockWay.SelectedItem,
                this.StartStockDate.SelectedDate.Value, this.EndStockDate.SelectedDate.Value);

            this.AllStockList.ItemsSource = list;
        }

        private void FindStockBtn_Click(object sender, RoutedEventArgs e)
        {
            getAllMedicineInStore();
        }
    }
}
