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
    public partial class MyTextEdit : UserControl
    {
        public MyTextEdit()
        {
            InitializeComponent();
        }

        public MyTextEdit(string strTittle, int maxnum)
        {
            InitializeComponent();

            this.TittleLabel.Content = strTittle;
            this.TextMaxNum.Content = maxnum.ToString();
            this.TextEdit.MaxLength = maxnum;
        }

        private void TextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                string str = TextEdit.Text;
                string strSelect = "";
                if (string.IsNullOrEmpty(str))
                {
                    return;
                }
                if (str.IndexOf(';') == -1)
                {
                    strSelect = str;
                }
                else
                {
                    string[] p = str.Split(';');

                    if (p == null)
                        return;
                    if (p.Count() <= 0)
                        return;

                    strSelect = p[p.Count() - 1];
                }
                //MessageBox.Show(strSelect);

            }
        }

        public string GetTittle()
        {
            return this.TittleLabel.Content.ToString();
        }

        public string GetTextContent()
        {
            return this.TextEdit.Text;
        }

        public void SetTextContent(string strContent)
        {
            this.TextEdit.Text = strContent;
        }
    }
}
