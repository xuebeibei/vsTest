﻿using System;
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
    [Export("RegistrationDitchView", typeof(RegistrationDitchView))]
    public partial class RegistrationDitchView : HISGUIViewBase
    {
        private bool bIsEdit;

        public RegistrationDitchView()
        {
            InitializeComponent();
            this.Loaded += RegistrationDitchView_Loaded;
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void RegistrationDitchView_Loaded(object sender, RoutedEventArgs e)
        {
            this.PriorityCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PriorityEnum));
            this.StatusCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.RegistrationDitchStatusEnum));

            newRegistrationDitch();

            updateAllRegistrationDitchList();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newRegistrationDitch();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;
            
            if (vm.CurrentRegistrationDitch == null)
                return;

            CommClient.RegistrationDitch vistTimeClient = new CommClient.RegistrationDitch();
            vm.CurrentRegistrationDitch.StartTime = this.StartTime.GetMyValue();

            if(bIsEdit == true)
            {
                if (vistTimeClient.UpdateRegistrationDitch(vm.CurrentRegistrationDitch))
                {
                    MessageBox.Show("OK");
                    newRegistrationDitch();
                    updateAllRegistrationDitchList();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                if (vistTimeClient.SaveRegistrationDitch(vm.CurrentRegistrationDitch))
                {
                    MessageBox.Show("OK");
                    newRegistrationDitch();
                    updateAllRegistrationDitchList();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditGrid.IsEnabled = true;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;

            CommClient.RegistrationDitch ditchClient = new CommClient.RegistrationDitch();
            if(ditchClient.DeleteRegistrationDitch(vm.CurrentRegistrationDitch.ID))
            {
                MessageBox.Show("OK");
                newRegistrationDitch();
                updateAllRegistrationDitchList();
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

        private void AllRegistrationDitchViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = this.AllRegistrationDitchViewList.SelectedItem as CommContracts.RegistrationDitch;
            if (currentItem == null)
                return;

            updateDateToView(currentItem);

            EditGrid.IsEnabled = false;
        }

        private void updateDateToView(CommContracts.RegistrationDitch RegistrationDitch)
        {
            var vm = this.DataContext as HISGUISetVM;
            vm.CurrentRegistrationDitch = RegistrationDitch;
            this.StartTime.SetMyValue(vm.CurrentRegistrationDitch.StartTime);
            bIsEdit = true;
        }

        private void updateAllRegistrationDitchList()
        {
            CommClient.RegistrationDitch registrationDitchClient = new CommClient.RegistrationDitch();
            List<CommContracts.RegistrationDitch> list = registrationDitchClient.GetAllRegistrationDitch();
            this.AllRegistrationDitchViewList.ItemsSource = list;
        }

        private void newRegistrationDitch()
        {
            bIsEdit = false;
            CommContracts.RegistrationDitch vistTime = new CommContracts.RegistrationDitch();
            updateDateToView(vistTime);
            EditGrid.IsEnabled = true;
            this.NameBox.Focus();
            if (this.AllRegistrationDitchViewList.SelectedItem != null)
                this.AllRegistrationDitchViewList.SelectedItem = null;
        }
    }
}
