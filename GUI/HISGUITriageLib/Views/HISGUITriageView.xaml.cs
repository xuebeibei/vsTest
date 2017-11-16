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
using HISGUITriageLib.ViewModels;
using System.Data;


namespace HISGUITriageLib.Views
{
    [Export]
    [Export("HISGUITriageView", typeof(HISGUITriageView))]
    public partial class HISGUITriageView : HISGUIViewBase
    {
        public HISGUITriageView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUITriageVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
