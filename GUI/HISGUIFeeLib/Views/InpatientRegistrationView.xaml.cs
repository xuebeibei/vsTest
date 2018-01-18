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
using HISGUIFeeLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("InpatientRegistrationView", typeof(InpatientRegistrationView))]
    public partial class InpatientRegistrationView : HISGUIViewBase
    {
        public InpatientRegistrationView()
        {
            InitializeComponent();
            this.Loaded += InpatientRegistrationView_Loaded;
        }

        private void InpatientRegistrationView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllInHospitalApplicationlList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
