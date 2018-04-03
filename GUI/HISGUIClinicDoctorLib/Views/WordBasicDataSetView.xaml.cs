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
using HISGUIDoctorLib.ViewModels;
using System.Data;
using System.Windows.Threading;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("WordBasicDataSetView", typeof(WordBasicDataSetView))]
    public partial class WordBasicDataSetView : HISGUIViewBase
    {
        public WordBasicDataSetView()
        {
            InitializeComponent();
            this.Loaded += WordBasicDataSetView_Loaded;
        }

        private void WordBasicDataSetView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyDataNameList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
