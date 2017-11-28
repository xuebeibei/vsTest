using System;
using System.Collections.Generic;
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

namespace HISGUIClinicDoctorLib.Views
{
    /// <summary>
    /// ClinicRemedy.xaml 的交互逻辑
    /// </summary>
    public partial class ClinicRemedy : UserControl
    {
        public ClinicRemedy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            TempletList jks = new TempletList();  //UserControl写的界面   
            window.Title = "西/成药处方模板";
            window.Height = 500;
            window.Width = 300;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
