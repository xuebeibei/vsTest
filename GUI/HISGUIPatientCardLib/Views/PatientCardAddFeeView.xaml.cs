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
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using Microsoft.VisualBasic;

namespace HISGUIPatientCardLib.Views
{
    [Export]
    [Export("PatientCardAddFeeView", typeof(PatientCardAddFeeView))]
    public partial class PatientCardAddFeeView : HISGUIViewBase
    {
        public PatientCardAddFeeView()
        {
            InitializeComponent();
            this.Loaded += PatientCardAddFeeView_Loaded;
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void PatientCardAddFeeView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            String strPatientCardNum = Interaction.InputBox("请输入就诊卡卡号", "读卡", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;


            var vm = this.DataContext as HISGUIPatientCardVM;

            CommClient.Patient patientClient = new CommClient.Patient();
            CommContracts.Patient patient = new CommContracts.Patient();

            string ErrorMsg = "";
            patient = patientClient.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);

            if(patient == null)
            {
                MessageBox.Show(ErrorMsg);
            }
            else
            {
                vm.CurrentPatient = patient;
            }
        }

        private void FindCardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RePrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
