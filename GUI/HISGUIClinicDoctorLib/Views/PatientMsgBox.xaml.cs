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
    /// PatientMsgBox.xaml 的交互逻辑
    /// </summary>
    public partial class PatientMsgBox : UserControl
    {
        public PatientMsgBox()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            ReceivingNewPatients jks = new ReceivingNewPatients();  //UserControl写的界面   
            window.Title = "费用";
            window.Height = 768;
            window.Width = 1024;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
