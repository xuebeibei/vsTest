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

namespace HISGUIDoctorLib.Views
{
    /// <summary>
    /// NewFileView.xaml 的交互逻辑
    /// </summary>
    public partial class NewFileView : UserControl
    {
        public string GetHeader { get; set; }
        public NewFileView()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            GetHeader = this.NameBox.Text;

            (this.Parent as Window).DialogResult = true;
            (this.Parent as Window).Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }

        private void FileTypeTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            string strHeader = "";

            NameBox.Text = "空" + strHeader;
        }
    }
}
