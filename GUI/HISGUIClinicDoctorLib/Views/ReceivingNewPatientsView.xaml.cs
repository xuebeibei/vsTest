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
    [Export("ReceivingNewPatientsView", typeof(ReceivingNewPatientsView))]
    public partial class ReceivingNewPatientsView : HISGUIViewBase
    {
        public ReceivingNewPatientsView()
        {
            InitializeComponent();
            this.Loaded += ReceivingNewPatients_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void ReceivingNewPatients_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            CostPreview jks = new CostPreview();  //UserControl写的界面   
            window.Title = "费用";
            window.Height = 768;
            window.Width = 1024;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
