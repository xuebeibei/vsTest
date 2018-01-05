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

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllMedicineItemNum();
        }

        private void getAllMedicineItemNum()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            List<CommContracts.StoreRoomMedicineNum> list = vm?.getAllMedicineItemNum(1, 
                FindItemNameBox.Text,
                1,
                0,
                IsStatusOkCheck.IsChecked.Value,
                IsHasNumCheck.IsChecked.Value,
                IsOverDateCheck.IsChecked.Value,
                IsNumNoEnoughCheck.IsChecked.Value);

            this.AllItemsNumList.ItemsSource = list;
        }

        private void AllItemsNumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
