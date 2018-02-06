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
using HISGUISetLib.ViewModels;
using System.Data;
using Newtonsoft.Json;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("HISGUISetView", typeof(HISGUISetView))]
    public partial class HISGUISetView : HISGUIViewBase
    {
        public HISGUISetView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;

            var jsons1 = vm?.MainData.SelectToken("LoginUser") + "";
            CommContracts.User user = new CommContracts.User();
            user = JsonConvert.DeserializeObject<CommContracts.User>(jsons1);

            vm.CurrentUser = user;

            vm?.SetWorkManage();
        }
    }
}
