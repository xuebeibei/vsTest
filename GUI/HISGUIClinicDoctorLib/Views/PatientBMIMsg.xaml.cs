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
    /// PatientBMIMsg.xaml 的交互逻辑
    /// </summary>
    public partial class PatientBMIMsg : UserControl
    {
        public PatientBMIMsg()
        {
            InitializeComponent();
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            CaseHistory jks = new CaseHistory();  //UserControl写的界面   
            window.Title = "历史病历";
            window.Height = 400;
            window.Width = 533;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
