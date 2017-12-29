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
using HISGUIDoctorLib.ViewModels;
using System.Data;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("ReceivingNewPatientsView", typeof(ReceivingNewPatientsView))]
    public partial class ReceivingNewPatientsView : HISGUIViewBase
    {
        public ReceivingNewPatientsView()
        {
            InitializeComponent();
            this.Loaded += ReceivingNewPatients_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void ReceivingNewPatients_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;

            // 使用blend设计之后状态切换，效果很不好，所以弃用
            //var isClinicOrHospitalState = vm.IsClinicOrInHospital ? "VisualState" : "VisualState1";
            //VisualStateManager.GoToState(this, isClinicOrHospitalState, false);

            if(vm.IsClinicOrInHospital)
            {
                Page1.Visibility = Visibility.Visible;
                Page2.Visibility = Visibility.Collapsed;
                this.tabControl.SelectedIndex = 0;  // 设置默认选中的选项卡，否则会出现界面乱切换的现象
            }
            else
            {
                Page1.Visibility = Visibility.Collapsed;
                Page2.Visibility = Visibility.Visible;
                this.tabControl.SelectedIndex = 1;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            CostPreview jks = new CostPreview();  //UserControl写的界面   
            window.Title = "费用";
            window.Height = 768;
            window.Width = 1024;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
