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
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace HISGUIPatientCardLib.Views
{
    [Export]
    [Export("PatientCardManageView", typeof(PatientCardManageView))]
    public partial class PatientCardManageView : HISGUIViewBase
    {
        public PatientCardManageView()
        {
            InitializeComponent();

            string str = Directory.GetCurrentDirectory() + "\\dist\\echarts.html";
            Web.Navigate(new Uri(str));
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 新增检查项目
            var window = new Window();

            PatientCardMsgView eidtInspect = new PatientCardMsgView();
            window.Content = eidtInspect;
            window.Width = 500;
            window.Height = 300;
            window.Title = "办理就诊卡";
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("检查项目新建完成！");
                //UpdateAllDate();
            }
        }
    }
}
