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
    [Export("SignalItemSetView", typeof(SignalItemSetView))]
    public partial class SignalItemSetView : HISGUIViewBase
    {
        private bool bIsEdit = false;

        public SignalItemSetView()
        {
            InitializeComponent();
            this.Loaded += SignalItemSetView_Loaded;
        }

        private void SignalItemSetView_Loaded(object sender, RoutedEventArgs e)
        {
            CommClient.Job jobClient = new CommClient.Job();

            SignalItemDoctorJobComBo.ItemsSource = jobClient.GetAllTypeJob(CommContracts.JobTypeEnum.医师);
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = "";
            UpdateAllDate(strName);
        }

        private void UpdateAllDate(string strName = "")
        {
            var vm = this.DataContext as HISGUISetVM;
            this.AllSignalItemList.ItemsSource = vm?.GetAllSignalItem(strName);
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;
            CommContracts.SignalItem item = new CommContracts.SignalItem();
            vm.CurrentSignalItem = item;

            EditGrid.IsEnabled = true;
            this.SignalItemNameBox.Focus();
            this.AllSignalItemList.SelectedItem = null;
            bIsEdit = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.SignalItemNameBox.Text.Trim()))
            {
                return;
            }

            if (this.SignalItemDoctorJobComBo.SelectedItem == null)
            {
                return;
            }

            var vm = this.DataContext as HISGUISetVM;

            vm.CurrentSignalItem.Name = this.SignalItemNameBox.Text.Trim();
            vm.CurrentSignalItem.DoctorJob = this.SignalItemDoctorJobComBo.Text.Trim();
            if (!string.IsNullOrEmpty(this.SignalPriceBox.Text.Trim()))
                vm.CurrentSignalItem.SellPrice = decimal.Parse(this.SignalPriceBox.Text.Trim());


            CommClient.SignalItem myd = new CommClient.SignalItem();

            if(bIsEdit)
            {
                if (myd.UpdateSignalItem(vm.CurrentSignalItem))
                {
                    MessageBox.Show("OK");
                    UpdateAllDate();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                if (myd.SaveSignalItem(vm.CurrentSignalItem))
                {
                    MessageBox.Show("OK");
                    UpdateAllDate();
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
            var currentDapertment = this.AllSignalItemList.SelectedItem as CommContracts.SignalItem;
            if (currentDapertment == null)
                return;

            if (MessageBox.Show("确认删除该号源种类？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteSignalItem(currentDapertment.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("号源种类删除完成！");
                        UpdateAllDate();
                    }
                }
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

        private void AllSignalItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = this.AllSignalItemList.SelectedItem as CommContracts.SignalItem;

            if (item == null)
                return;

            var vm = this.DataContext as HISGUISetVM;

            vm.CurrentSignalItem = item;

            EditGrid.IsEnabled = false;
            bIsEdit = true;
        }
    }
}
