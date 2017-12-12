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
using HISGUIClinicDoctorLib.ViewModels;
using System.Data;

namespace HISGUIClinicDoctorLib.Views
{
    [Export]
    [Export("ClinicRemedy", typeof(ClinicRemedy))]
    public partial class ClinicRemedy : HISGUIViewBase
    {
        public ClinicRemedy()
        {
            InitializeComponent();
            RemedyPanel.Children.Add(new MyTableEdit(MyTableEditEnum.zhiliao));
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            TempletList jks = new TempletList();  //UserControl写的界面   
            window.Title = "治疗模板";
            window.Height = 500;
            window.Width = 300;

            window.Content = jks;
            window.ShowDialog();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
