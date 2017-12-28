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
using System.IO;
using System.Xml;

namespace HISGUIClinicDoctorLib.Views
{
    [Export]
    [Export("PatientMedicalRecord", typeof(PatientMedicalRecord))]
    public partial class PatientMedicalRecord : HISGUIViewBase
    {
        private List<MyTextEdit> myTextList;

        public PatientMedicalRecord()
        {
            InitializeComponent();

            initText();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        public void initText()
        {
            string str = "主诉;现病史;既往史;过敏史;个人史;家族史;疫苗接种史;检验检查;体格检查;初步诊断;治疗意见;备注";
            string[] q = str.Split(';');
            if (q != null)
            {
                myTextList = new List<MyTextEdit>();
                for (int i = 0; i < 11; i++)
                {
                    MyTextEdit myText = new MyTextEdit(q[i], 500);
                    myTextList.Add(myText);
                    this.MedicalRecordPanel.Children.Add(myText);
                    if (i <= 7 && i >= 2)
                        myText.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;

            string strXML = vm?.GetClinicMedicalRecord();

            if (!string.IsNullOrEmpty(strXML))
            {
                StringReader Reader = new StringReader(strXML);

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(Reader);
                foreach (var tem in myTextList)
                {

                    string strTittle = "//" + tem.GetTittle();
                    XmlNode node = xmlDoc.DocumentElement.SelectSingleNode(strTittle);
                    tem.SetTextContent(node.InnerText);
                }
            }
            else
            {
                foreach (var tem in myTextList)
                {
                    tem.SetTextContent("");
                }
            }
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Button aa = sender as Button;
            int n = int.Parse(aa.DataContext.ToString());

            string btnContent = aa.Content.ToString();
            if (string.IsNullOrEmpty(btnContent))
                return;

            string str = btnContent.Substring(0,1);
            string str1 = btnContent.Substring(1,btnContent.Length - 1);
            if(str == "+")
            {
                if (myTextList.ElementAt(n) != null)
                {
                    myTextList.ElementAt(n).Visibility = Visibility.Visible;
                    aa.Content = "-" + str1;
                }
            }
            else if(str == "-")
            {
                if (myTextList.ElementAt(n) != null)
                {
                    myTextList.ElementAt(n).Visibility = Visibility.Collapsed;
                    aa.Content = "+" + str1;
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;

            string strXML = "<?xml version=\"1.0\" encoding=\"ISO - 8859 - 1\"?><note>";
            foreach(var tem in myTextList)
            {
                strXML += "<" + tem.GetTittle() + ">" + tem.GetTextContent() + "</" + tem.GetTittle() + ">"; 
            }
            strXML += "</note>";

            bool? result = vm?.SaveClinicMedicalRecord(strXML);

            if(result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("保存成功！");
                    return;
                }
            }

            MessageBox.Show("保存失败！");
        }
    }
}
