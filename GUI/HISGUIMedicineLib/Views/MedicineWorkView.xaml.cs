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
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            //var vm = this.DataContext as HISGUIMedicineVM;
            
        }

        private void AddNewStockBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllStockList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
