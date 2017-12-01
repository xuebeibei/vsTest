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
using HISGUITriageLib.ViewModels;
using System.Data;

namespace HISGUITriageLib.Views
{
    [Export]
    [Export("SelectDoctorView", typeof(SelectDoctorView))]
    public partial class SelectDoctorView : HISGUIViewBase
    {
        public SelectDoctorView()
        {
            InitializeComponent();
        }

        [Import]
        private SelectDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

    }
}
