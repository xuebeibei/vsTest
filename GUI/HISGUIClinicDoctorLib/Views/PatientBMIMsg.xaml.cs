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
    [Export("PatientBMIMsg", typeof(PatientBMIMsg))]
    public partial class PatientBMIMsg : HISGUIViewBase
    {
        public PatientBMIMsg()
        {
            InitializeComponent();
            this.Loaded += PatientBMIMsg_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void PatientBMIMsg_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            string str = vm?.getPatientBMIMsg();
            this.BMILabel.Content = str;
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            CaseHistory jks = new CaseHistory();  //UserControl写的界面   
            window.Title = "历史病历";
            window.Height = 400;
            window.Width = 533;

            window.Content = jks;
            window.ShowDialog();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            PersonalInformation jks = new PersonalInformation();  //UserControl写的界面   
            window.Title = "完善信息";
            window.Height = 700;
            window.Width = 533;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
