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
    [Export("PatientMedicalRecord", typeof(PatientMedicalRecord))]
    public partial class PatientMedicalRecord : HISGUIViewBase
    {
        public PatientMedicalRecord()
        {
            InitializeComponent();
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
            window.Title = "病历模板";
            window.Height = 500;
            window.Width = 300;

            window.Content = jks;
            window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            CaseHistory jks = new CaseHistory();  //UserControl写的界面   
            window.Title = "历史病历";
            window.Height = 400;
            window.Width = 533;

            window.Content = jks;
            window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            TempletSave jks = new TempletSave();  //UserControl写的界面   
            window.Title = "新增病历模板";
            window.Height = 700;
            window.Width = 600;

            window.Content = jks;
            window.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //var window = new Window();//Windows窗体
            //PrintDlg jks = new PrintDlg();  //UserControl写的界面   
            //window.Title = "历史病历";
            //window.Height = 400;
            //window.Width = 533;

            //window.Content = jks;
            //window.ShowDialog();
            //PrintPreviewWindow previewWnd = new PrintPreviewWindow("FlowDocument.xaml");//在这里我们将FlowDocument.xaml这个页面传进去，之后通过打印预览窗口的构造函数填充打印内容,如果有数据要插入应该在此传数据结构进去  
            //previewWnd.Owner = this;
            //previewWnd.ShowInTaskbar = false;//设置预览窗体在最小化时不要出现在任务栏中   
            //previewWnd.ShowDialog();//显示打印预览窗体
        }
    }
}
