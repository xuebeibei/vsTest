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
using HISGUIClinicDoctorLib.ViewModels;
using System.Data;

namespace HISGUIClinicDoctorLib.Views
{
    [Export]
    [Export("HISGUITriageView", typeof(HISGUIClinicDoctorView))]
    public partial class HISGUIClinicDoctorView : HISGUIViewBase
    {
        public HISGUIClinicDoctorView()
        {
            InitializeComponent();
            this.Loaded += ClinicDoctor_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void ClinicDoctor_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            vm?.DoctorWorkManage();
        }
    }
}
