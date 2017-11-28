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
    public class MyTextEditText : DependencyObject
    {
        public string Tittle
        {
            get { return (string)GetValue(TittleProperty); }
            set { SetValue(TittleProperty, value); }
        }

        public static readonly DependencyProperty TittleProperty =
            DependencyProperty.Register("Tittle", typeof(string), typeof(MyTextEditText));

        public string Tip
        {
            get { return (string)GetValue(TipProperty); }
            set { SetValue(TipProperty, value); }
        }

        public static readonly DependencyProperty TipProperty =
            DependencyProperty.Register("Tip", typeof(string), typeof(MyTextEditText));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyTextEditText));

        public int MaxNum
        {
            get { return (int)GetValue(MaxNumProperty); }
            set { SetValue(MaxNumProperty, value); }
        }

        public static readonly DependencyProperty MaxNumProperty =
            DependencyProperty.Register("MaxNum", typeof(int), typeof(MyTextEditText));

        public int TextNum
        {
            get { return (int)GetValue(TextNumProperty); }
            set { SetValue(TextNumProperty, value); }
        }

        public static readonly DependencyProperty TextNumProperty =
            DependencyProperty.Register("TextNum", typeof(int), typeof(MyTextEditText));

        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }

    public partial class MyTextEdit : UserControl
    {
        //private MyTextEditText mytext;
        //public MyTextEditText mytext { get; set; }

        public MyTextEdit()
        {
            InitializeComponent();
            //mytext = new MyTextEditText();
            //mytext.SetValue(MyTextEditText.TittleProperty, "aaaa:");
            //mytext.SetValue(MyTextEditText.TextProperty, "dfadfasdfdasfdsadsf");
            //mytext.SetValue(MyTextEditText.MaxNumProperty, 500);

            //this.TittleLabel.SetBinding(Label.ContentProperty, new Binding("Tittle") { Source = mytext });
            //this.TextEdit.SetBinding(TextBox.TextProperty, new Binding("Text") { Source = mytext });
            //this.TextNum.SetBinding(Label.ContentProperty, new Binding("TextNum") { Source = mytext});
            //this.TextMaxNum.SetBinding(Label.ContentProperty, new Binding("MaxNum") { Source = mytext });


        }
    }
}
