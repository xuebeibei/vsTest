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
    [Export("SignalTypeSetView", typeof(SignalTypeSetView))]
    public partial class SignalTypeSetView : HISGUIViewBase
    {
        private bool bIsEdit = false;
        private CommContracts.SignalType m_SignalType;

        public SignalTypeSetView()
        {
            InitializeComponent();
            this.Loaded += SignalTypeSetView_Loaded;
        }

        private void SignalTypeSetView_Loaded(object sender, RoutedEventArgs e)
        {
            CommClient.Job jobClient = new CommClient.Job();
            CommClient.WorkType typeClient = new CommClient.WorkType();

            SignalItemDoctorJobComBo.ItemsSource = jobClient.GetAllTypeJob(CommContracts.JobTypeEnum.医师);
            SignalItemWorkTypeComBo.ItemsSource = typeClient.GetAllWorkType();
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
            CommClient.SignalType signalTypeClient = new CommClient.SignalType();
            this.AllSignalItemList.ItemsSource = signalTypeClient.GetAllSignalType(strName);
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            CommContracts.SignalType item = new CommContracts.SignalType();
            this.SignalItemNameBox.Text = "";
            this.SignalItemDoctorJobComBo.SelectedItem = null;
            this.SignalItemWorkTypeComBo.SelectedItem = null;
            this.SignalItemPrice.Text = "";

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
            
            CommClient.SignalType myd = new CommClient.SignalType();

            if (bIsEdit)
            {
                m_SignalType.Name = this.SignalItemNameBox.Text.Trim();
                m_SignalType.JobID = (this.SignalItemDoctorJobComBo.SelectionBoxItem as CommContracts.Job).ID;
                m_SignalType.WorkTypeID = (this.SignalItemWorkTypeComBo.SelectedItem as CommContracts.WorkType).ID;
                m_SignalType.DoctorClinicFee = decimal.Parse(this.SignalItemPrice.Text.Trim());

                if (myd.UpdateSignalType(m_SignalType))
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
                CommContracts.SignalType signalType = new CommContracts.SignalType();
                signalType.Name = this.SignalItemNameBox.Text.Trim();
                signalType.JobID = (this.SignalItemDoctorJobComBo.SelectedItem as CommContracts.Job).ID;
                signalType.WorkTypeID = (this.SignalItemWorkTypeComBo.SelectedItem as CommContracts.WorkType).ID;
                signalType.DoctorClinicFee = decimal.Parse(this.SignalItemPrice.Text.Trim());

                if (myd.SaveSignalType(signalType))
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
            var currentDapertment = this.AllSignalItemList.SelectedItem as CommContracts.SignalType;
            if (currentDapertment == null)
                return;

            if (MessageBox.Show("确认删除该号源种类？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                CommClient.SignalType signalTypeClient = new CommClient.SignalType();
                bool? bIsOK = signalTypeClient.DeleteSignalType(m_SignalType.ID);
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
            var item = this.AllSignalItemList.SelectedItem as CommContracts.SignalType;

            if (item == null)
                return;

            var vm = this.DataContext as HISGUISetVM;

            m_SignalType = item;
            this.SignalItemNameBox.Text = m_SignalType.Name;
            this.SignalItemDoctorJobComBo.SelectedItem = m_SignalType.Job;
            this.SignalItemWorkTypeComBo.SelectedItem = m_SignalType.WorkType;
            this.SignalItemPrice.Text = m_SignalType.DoctorClinicFee.ToString();

            EditGrid.IsEnabled = false;
            bIsEdit = true;
        }
    }
}
