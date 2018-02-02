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
    [Export("InHospitalRecivingView", typeof(InHospitalRecivingView))]
    public partial class InHospitalRecivingView : HISGUIViewBase
    {
        public InHospitalRecivingView()
        {
            InitializeComponent();
            this.Loaded += InHospitalRecivingView_Loaded;
        }

        private void InHospitalRecivingView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllInHospital();
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void UpdateAllInHospital()
        {
            var temp = this.AllPatientList.SelectedItem as CommContracts.Registration;

            var vm = this.DataContext as HISGUIDoctorVM;
            this.AllPatientList.ItemsSource = vm?.GetDoctorInHospitalPatients(vm.CurrentUser.EmployeeID);
            if (temp != null)
            {
                this.AllPatientList.SelectedItem = temp;
            }
        }

        private void AllPatientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;

            var temp = this.AllPatientList.SelectedItem as CommContracts.InHospital;
            if (temp == null)
                return;

            this.PatientMsgView.SetMyEnable(true);
            this.PatientMsgView.ShowInHospitalMsg(temp);
            this.PatientMsgView.Visibility = Visibility.Visible;
            this.TipMsgLabel.Visibility = Visibility.Collapsed;
        }
    }
}
