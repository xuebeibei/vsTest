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
using HISGUIMenuLib.ViewModels;

namespace HISGUIMenuLib.View
{
    [Export]
    [Export("HISGUIMenuView", typeof(HISGUIMenuView))]

    /// <summary>
    /// HISGUIMenuView.xaml 的交互逻辑
    /// </summary>
    public partial class HISGUIMenuView : HISGUIViewBase
    {
        public HISGUIMenuView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUIMenuVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
