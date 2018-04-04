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
using HISGUISetLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;
using Microsoft.Win32;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("ClinicVistTimeView", typeof(ClinicVistTimeView))]
    public partial class ClinicVistTimeView : HISGUIViewBase
    {
        public ClinicVistTimeView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;
            CommClient.ClinicVistTime vistTimeClient = new CommClient.ClinicVistTime();
            vistTimeClient.SaveClinicVistTime(vm.CurrentClinicVistTime);
        }

        private void AllClinicVistTimeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;
            CommContracts.ClinicVistTime vistTime = new CommContracts.ClinicVistTime();
            vm.CurrentClinicVistTime = vistTime;
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
    }
}
