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
using HISGUILoginLib.ViewModels;

namespace HISGUILoginLib.Views
{
    [Export]
    [Export("HISGUILoginView", typeof(HISGUILoginView))]
    public partial class HISGUILoginView : HISGUIViewBase
    {
        public HISGUILoginView()
        {
            InitializeComponent();
            this.Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUILoginVM;
            vm.LogName = "登录";
            vm.UserName = "admin";
            vm.PassWord = "admin";
        }

        [Import]
        private HISGUILoginVM ImportVM
        {
            set { this.VM = value; }
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUILoginVM;

            bool? loginResult = vm?.Login();
            if (!loginResult.HasValue)
            {
                return;
            }
            if ((bool)loginResult)
            {
                vm?.RegionManager.RequestNavigate("MainRegion", "HISGUIWorkstationView");
            }
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
