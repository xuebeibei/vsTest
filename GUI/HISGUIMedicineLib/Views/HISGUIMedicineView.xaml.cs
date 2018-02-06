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
using HISGUIMedicineLib.ViewModels;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace HISGUIMedicineLib.Views
{
    [Export]
    [Export("HISGUIMedicineView", typeof(HISGUIMedicineView))]
    public partial class HISGUIMedicineView : HISGUIViewBase
    {
        public HISGUIMedicineView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm.CurrentUser = vm?.getUser(1);

            //StreamReader sr1 = new StreamReader("HISGUIJson.json", Encoding.Default);
            //string jsons1 = sr1.ReadToEnd();
            //CommContracts.User tmp_cfg1 = JsonConvert.DeserializeObject<CommContracts.User>(jsons1);
            //sr1.Close();

            //vm.CurrentUser = tmp_cfg1;

            vm?.MedicineWorkManage();
        }
    }
}
