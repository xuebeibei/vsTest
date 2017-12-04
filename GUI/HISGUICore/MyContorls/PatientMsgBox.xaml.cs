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
        public int ID { get; set; }
        public PatientMsgBox()
        {
            InitializeComponent();
            this.PatientMsgText.Text = "测试测试测试";
            this.ID = 0;
        }
        public PatientMsgBox(int id,string str)
        {
            InitializeComponent();
            this.PatientMsgText.Text = str;
            this.ID = id;
        }
    }
}
