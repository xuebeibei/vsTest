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

namespace HISGUICore.MyContorls
{
    public partial class PatientMsgBox : UserControl
    {
        public PatientMsgBox()
        {
            InitializeComponent();
            this.PatientMsgText.Text = "测试测试测试";
        }
        public PatientMsgBox(string str)
        {
            InitializeComponent();
            this.PatientMsgText.Text = str;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var window = new Window();//Windows窗体
        //    PersonalInformation jks = new PersonalInformation();  //UserControl写的界面   
        //    window.Title = "个人信息";
        //    window.Height = 700;
        //    window.Width = 660;

        //    window.Content = jks;
        //    window.ShowDialog();
        //}

 
    }
}
