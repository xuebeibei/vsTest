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
            this.Loaded += ClinicVistTimeView_Loaded;
        }

        private void ClinicVistTimeView_Loaded(object sender, RoutedEventArgs e)
        {
            updateAllClinicVistTimeList();
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

            vm.CurrentClinicVistTime.StartVistTime = this.StartVistTime.GetMyValue();
            vm.CurrentClinicVistTime.EndVistTime = this.EndVistTime.GetMyValue();
            vm.CurrentClinicVistTime.StartWaitTime = this.StartWaitTime.GetMyValue();
            vm.CurrentClinicVistTime.EndWaitTime = this.EndWaitTime.GetMyValue();
            vm.CurrentClinicVistTime.LastSellTime = this.LastSellTime.GetMyValue();

            if(vistTimeClient.SaveClinicVistTime(vm.CurrentClinicVistTime))
            {
                MessageBox.Show("OK");
                updateAllClinicVistTimeList();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            CommContracts.ClinicVistTime vistTime = new CommContracts.ClinicVistTime();
            updateDateToView(vistTime);
            EditGrid.IsEnabled = true;
            this.VistTimeNameBox.Focus();
            if (this.AllClinicVistTimeList.SelectedItem != null)
                this.AllClinicVistTimeList.SelectedItem = null;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditGrid.IsEnabled = true;
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

        private void updateDateToView(CommContracts.ClinicVistTime clinicVistTime)
        {
            var vm = this.DataContext as HISGUISetVM;
            vm.CurrentClinicVistTime = clinicVistTime;

            this.StartVistTime.SetMyValue(vm.CurrentClinicVistTime.StartVistTime);
            this.EndVistTime.SetMyValue(vm.CurrentClinicVistTime.EndVistTime);
            this.StartWaitTime.SetMyValue(vm.CurrentClinicVistTime.StartWaitTime);
            this.EndWaitTime.SetMyValue(vm.CurrentClinicVistTime.EndWaitTime);
            this.LastSellTime.SetMyValue(vm.CurrentClinicVistTime.LastSellTime);
        }

        private void updateAllClinicVistTimeList()
        {
            CommClient.ClinicVistTime vistTimeClient = new CommClient.ClinicVistTime();
            List<CommContracts.ClinicVistTime> list = vistTimeClient.GetAllClinicVistTime();
            this.AllClinicVistTimeList.ItemsSource = list;
        }

        private void AllClinicVistTimeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = this.AllClinicVistTimeList.SelectedItem as CommContracts.ClinicVistTime;
            if (currentItem == null)
                return;

            updateDateToView(currentItem);

            EditGrid.IsEnabled = false;
        }
    }
}
