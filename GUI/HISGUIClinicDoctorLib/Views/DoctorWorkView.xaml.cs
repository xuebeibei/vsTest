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

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("DoctorWorkView", typeof(DoctorWorkView))]
    public partial class DoctorWorkView : HISGUIViewBase
    {
        private int currentEmployeeID { get; set; }
        public DoctorWorkView()
        {
            InitializeComponent();
            currentEmployeeID = 1;
            this.Loaded += DoctorWork_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void DoctorWork_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllRegistration();
        }

        private void UpdateAllRegistration()
        {
            var temp = this.AllPatientList.SelectedItem as CommContracts.Registration;

            var vm = this.DataContext as HISGUIDoctorVM;
            this.AllPatientList.ItemsSource = vm?.GetDoctorPatients(currentEmployeeID, DateTime.Now.Date);
            if (temp != null)
            {
                this.AllPatientList.SelectedItem = temp;
            }
        }

        private void CallBtn_Click(object sender, RoutedEventArgs e)
        {
            List<CommContracts.Registration> list = this.AllPatientList.ItemsSource as List<CommContracts.Registration>;
            if (list == null || list.Count <= 0)
                return;

            var vm = this.DataContext as HISGUIDoctorVM;
            var tempRegistration = this.AllPatientList.SelectedItem as CommContracts.Registration;

            int nextNo = 0;
            if (tempRegistration == null)
            {
                nextNo = 0;
            }
            else
            {
                int nIndex = list.IndexOf(tempRegistration);
                if (nIndex < 0 || nIndex >= list.Count-1)
                {
                    nextNo = 0;
                }
                else
                {
                    nextNo = nIndex + 1;
                }
            }

            this.AllPatientList.SelectedItem = list.ElementAt(nextNo);
            tempRegistration = list.ElementAt(nextNo);
            if(tempRegistration.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.候诊中)
            {
                this.StartBtn.Content = "开始接诊";
                this.StartBtn.IsEnabled = true;
                this.OverBtn.IsEnabled = false;
                this.TurnToInHospitalBtn.IsEnabled = false;
            }
            else if(tempRegistration.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.接诊中)
            {
                this.StartBtn.Content = "继续接诊";
                this.StartBtn.IsEnabled = true;
                this.OverBtn.IsEnabled = false;
                this.TurnToInHospitalBtn.IsEnabled = false;
            }
            else if(tempRegistration.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.接诊结束 || tempRegistration.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.未到诊)
            {
                this.StartBtn.Content = "开始接诊";
                this.StartBtn.IsEnabled = false;
                this.OverBtn.IsEnabled = false;
                this.TurnToInHospitalBtn.IsEnabled = false;
            }
            
            this.PatientMsgView.SetMyEnable(false);
            this.PatientMsgView.ShowClinicMsg(tempRegistration);
            this.PatientMsgView.Visibility = Visibility.Visible;
            this.TipMsgLabel.Visibility = Visibility.Collapsed;
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            var tempRegistration = this.AllPatientList.SelectedItem as CommContracts.Registration;

            if (tempRegistration == null)
                return;

            tempRegistration.StartSeeDoctorTime = DateTime.Now;
            tempRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.接诊中;
            vm.UpdateRegistration(tempRegistration);

            this.PatientMsgView.SetMyEnable(true);
            this.PatientMsgView.ShowClinicMsg(tempRegistration);
            this.PatientMsgView.Visibility = Visibility.Visible;
            this.TipMsgLabel.Visibility = Visibility.Collapsed;
            this.StartBtn.IsEnabled = false;
            this.OverBtn.IsEnabled = true;
            this.TurnToInHospitalBtn.IsEnabled = true;
            UpdateAllRegistration();
        }

        private void OverBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            var tempRegistration = this.AllPatientList.SelectedItem as CommContracts.Registration;

            if (tempRegistration == null)
                return;

            tempRegistration.EndSeeDoctorTime = DateTime.Now;
            tempRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.接诊结束;
            vm.UpdateRegistration(tempRegistration);

            this.PatientMsgView.SetMyEnable(false);
            this.PatientMsgView.ShowClinicMsg(tempRegistration);
            this.PatientMsgView.Visibility = Visibility.Visible;
            this.TipMsgLabel.Visibility = Visibility.Collapsed;
            this.StartBtn.IsEnabled = false;
            this.OverBtn.IsEnabled = false;
            this.TurnToInHospitalBtn.IsEnabled = false;
            UpdateAllRegistration();
        }

        private void TurnToInHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            var tempRegistration = this.AllPatientList.SelectedItem as CommContracts.Registration;

            if (tempRegistration == null)
                return;

            

            CommContracts.InHospitalApply inHospitalApply = new CommContracts.InHospitalApply();
            inHospitalApply.PatientID = vm.CurrentRegistration.PatientID;
            inHospitalApply.UserID = vm.CurrentUser.ID;
            
            bool? result =  vm.SaveInHospitalApply(inHospitalApply);
            if(result.HasValue)
            {
                if(result.Value)
                {
                    MessageBox.Show("入院申请成功！");
                    tempRegistration.EndSeeDoctorTime = DateTime.Now;
                    tempRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.申请入院;
                    vm.UpdateRegistration(tempRegistration);

                    this.PatientMsgView.SetMyEnable(false);
                    this.PatientMsgView.ShowClinicMsg(tempRegistration);
                    this.PatientMsgView.Visibility = Visibility.Visible;
                    this.TipMsgLabel.Visibility = Visibility.Collapsed;
                    this.StartBtn.IsEnabled = false;
                    this.OverBtn.IsEnabled = false;
                    this.TurnToInHospitalBtn.IsEnabled = false;
                    UpdateAllRegistration();
                    return;
                }
            }
            MessageBox.Show("入院申请失败！");
        }
    }
}
