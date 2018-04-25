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
            CommClient.Shift myd = new CommClient.Shift();
            ShiftCombo.ItemsSource = myd.GetAllShift();
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
            CommClient.SignalTime vistTimeClient = new CommClient.SignalTime();

            CommContracts.SignalTime clinicVistTime = new CommContracts.SignalTime();

            if (this.ShiftCombo.SelectedItem == null)
                return;

            clinicVistTime.ShiftID = (this.ShiftCombo.SelectedItem as CommContracts.Shift).ID;
            clinicVistTime.StartWaitTime = this.StartWaitTime.GetMyValue();
            clinicVistTime.EndWaitTime = this.EndWaitTime.GetMyValue();
            clinicVistTime.LastSellTime = this.LastSellTime.GetMyValue();


            if(vistTimeClient.SaveClinicVistTime(clinicVistTime))
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
            CommContracts.SignalTime vistTime = new CommContracts.SignalTime();
            updateDateToView(vistTime);
            EditGrid.IsEnabled = true;
            this.ShiftCombo.Focus();
            if (this.AllClinicVistTimeList.SelectedItem != null)
                this.AllClinicVistTimeList.SelectedItem = null;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditGrid.IsEnabled = true;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllClinicVistTimeList.SelectedItem as CommContracts.SignalTime;
            if (temp == null)
                return;

            CommClient.SignalTime client = new CommClient.SignalTime();
            if(client.DeleteClinicVistTime(temp.ID))
            {
                MessageBox.Show("OK");
                updateAllClinicVistTimeList();
            }
            else
            {
                MessageBox.Show("Error");
            }
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

        private void updateDateToView(CommContracts.SignalTime clinicVistTime)
        {
            if (clinicVistTime.Shift != null)
            {
                this.ShiftCombo.SelectedItem = clinicVistTime.Shift;
                this.StartVistTime.SetMyValue(clinicVistTime.Shift.StartTime);
                this.EndVistTime.SetMyValue(clinicVistTime.Shift.EndTime);
                this.StartWaitTime.SetMyValue(clinicVistTime.StartWaitTime);
                this.EndWaitTime.SetMyValue(clinicVistTime.EndWaitTime);
                this.LastSellTime.SetMyValue(clinicVistTime.LastSellTime);
            }
                
            else
            {
                this.ShiftCombo.SelectedItem = null;

                const string nulltime = "00:00:00";
                this.StartVistTime.SetMyValue(nulltime);
                this.EndVistTime.SetMyValue(nulltime);
                this.StartWaitTime.SetMyValue(nulltime);
                this.EndWaitTime.SetMyValue(nulltime);
                this.LastSellTime.SetMyValue(nulltime);
            }
                
        }

        private void updateAllClinicVistTimeList()
        {
            CommClient.SignalTime vistTimeClient = new CommClient.SignalTime();
            List<CommContracts.SignalTime> list = vistTimeClient.GetAllClinicVistTime();
            this.AllClinicVistTimeList.ItemsSource = list;
        }

        private void AllClinicVistTimeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = this.AllClinicVistTimeList.SelectedItem as CommContracts.SignalTime;
            if (currentItem == null)
                return;

            updateDateToView(currentItem);

            EditGrid.IsEnabled = false;
        }

        private void ShiftCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentShift = this.ShiftCombo.SelectedItem as CommContracts.Shift;
            if (currentShift == null)
                return;

            this.StartVistTime.SetMyValue(currentShift.StartTime);
            this.EndVistTime.SetMyValue(currentShift.EndTime);
        }
    }
}
