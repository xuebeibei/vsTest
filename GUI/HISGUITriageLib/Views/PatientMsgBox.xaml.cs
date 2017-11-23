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

namespace HISGUITriageLib.Views
{
    /// <summary>
    /// PatientMsgBox.xaml 的交互逻辑
    /// </summary>
    public partial class PatientMsgBox : UserControl
    {
        public PatientMsgBox(CommClient.Registration registration)
        {
            InitializeComponent();
            
            this.TimeLabel.Content = "登记：" + registration.GetDateTime();
            PatientMsgLabel.Content = registration.getPatientMsg();
            DepartmentLabel.Content = "科室：" + registration.getDepartment();
            DoctorLabel.Content = "医生：" + registration.getDoctor();
            VisitingTimeLabel.Content = "看诊时间:" + registration.getVisitingTime().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            PersonalInformation jks = new PersonalInformation();  //UserControl写的界面   
            window.Title = "个人信息";
            window.Height = 700;
            window.Width = 660;
            
            window.Content = jks;
            window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            DoctorFind jks = new DoctorFind();  //UserControl写的界面   
            window.Title = "查找医生";
            window.Height = 400;
            window.Width = 660;

            window.Content = jks;
            window.ShowDialog();

            var visualUsername = true ? "VisualState1" : "VisualState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }
    }
}
