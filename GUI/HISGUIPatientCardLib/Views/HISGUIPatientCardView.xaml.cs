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
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;

namespace HISGUIPatientCardLib.Views
{
    [Export]
    [Export("HISGUIPatientCardView", typeof(HISGUIPatientCardView))]
    public partial class HISGUIPatientCardView : HISGUIViewBase
    {
        public HISGUIPatientCardView()
        {
            InitializeComponent();
            this.Loaded += HISGUIPatientCardView_Loaded;
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void HISGUIPatientCardView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;
            var jsons1 = vm?.MainData.SelectToken("LoginUser") + "";
            CommContracts.Employee user = new CommContracts.Employee();
            user = JsonConvert.DeserializeObject<CommContracts.Employee>(jsons1);

            vm.CurrentUser = user;
            vm?.PatientCardManageView();
        }
    }
}
