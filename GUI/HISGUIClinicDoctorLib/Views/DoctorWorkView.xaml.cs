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
using HISGUIClinicDoctorLib.ViewModels;
using System.Data;

namespace HISGUIClinicDoctorLib.Views
{
    [Export]
    [Export("DoctorWorkView", typeof(DoctorWorkView))]
    public partial class DoctorWorkView : HISGUIViewBase
    {
        public DoctorWorkView()
        {
            InitializeComponent();
            this.Loaded += DoctorWork_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void DoctorWork_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAllRegistration();
            ShowAllInPatient();
        }

        private void ShowAllRegistration()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary = vm?.GetPatients();

            List<PatientMsgBox> list = new List<PatientMsgBox>();
            if (dictionary != null)
            {
                for (int i = 0; i < dictionary.Count; i++)
                {
                    // 实例化一个控件
                    list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
                }

                this.AllPatientList.ItemsSource = list;
            }
        }

        private void ShowAllInPatient()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary = vm?.GetAllInPatient();

            List<PatientMsgBox> list = new List<PatientMsgBox>();
            if (dictionary != null)
            {
                for (int i = 0; i < dictionary.Count; i++)
                {
                    // 实例化一个控件
                    list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
                }

                this.AllInPatientList.ItemsSource = list;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            var thePatient = this.AllPatientList.SelectedItem as PatientMsgBox;
            vm.IsClinicOrInHospital = true;
            vm.CurrentRegistrationID = thePatient.ID;
            vm?.ReceivingNewPatientsManage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            var thePatient = this.AllInPatientList.SelectedItem as PatientMsgBox;
            vm.IsClinicOrInHospital = false;
            vm.CurrentInpatientID = thePatient.ID;
            vm?.ReceivingNewPatientsManage();
        }
    }
}
