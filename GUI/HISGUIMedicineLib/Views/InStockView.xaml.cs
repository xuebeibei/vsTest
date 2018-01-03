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
            var vm = this.DataContext as HISGUIMedicineVM;
            List<CommContracts.MedicineInStore> list = vm?.getAllMedicineInStore(1, CommContracts.InStoreEnum.采购入库,
                new DateTime(2017, 10, 1), new DateTime(2018, 10, 1));

            this.AllStockList.ItemsSource = list;

        }
        private void AddNewStockBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.NewInStore();
        }

        private void AllStockList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var currentInStore = this.AllStockList.SelectedItem as CommContracts.MedicineInStore;
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.NewInStore();
        }
    }
}
