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
using HISGUIWorkstationLib.ViewModels;

namespace HISGUIWorkstationLib.View
{
    [Export]
    [Export("HISGUIWorkstationView", typeof(HISGUIWorkstationView))]
    public partial class HISGUIWorkstationView : HISGUIViewBase
    {
        public HISGUIWorkstationView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUIWorkstationVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
