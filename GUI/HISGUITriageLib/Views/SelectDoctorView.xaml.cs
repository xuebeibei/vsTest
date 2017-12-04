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
        private TriageVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int nDoctorID = this.DoctorFindList.SelectDoctorID;
            if (nDoctorID <= 0)
            {
                MessageBox.Show("请选择医生!");
                return;
            }

            var vm = this.DataContext as TriageVM;

            bool? aa = vm?.SaveTriage(nDoctorID);
            if(aa.HasValue)
            {
                if(aa.Value)
                {
                    // 跳转回去
                    vm?.SelectDoctorOK();
                }
            }
        }
    }
}
