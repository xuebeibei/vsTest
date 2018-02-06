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
using HISGUINurseLib.ViewModels;
using System.Data;
using Newtonsoft.Json;

namespace HISGUINurseLib.Views
{
    [Export]
    [Export("HISGUINurseView", typeof(HISGUINurseView))]
    public partial class HISGUINurseView : HISGUIViewBase
    {
        public HISGUINurseView()
        {
            InitializeComponent();
            this.Loaded += Triage_Loaded;
        }

        [Import]
        private HISGUINurseVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Triage_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            var jsons1 = vm?.MainData.SelectToken("LoginUser") + "";
            CommContracts.User user = new CommContracts.User();
            user = JsonConvert.DeserializeObject<CommContracts.User>(jsons1);

            vm.CurrentUser = user;
            vm?.TriageManage();
        }

    }
}
