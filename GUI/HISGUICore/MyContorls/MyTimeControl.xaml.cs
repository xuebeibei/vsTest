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
    /// <summary>
    /// MyTimeControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyTimeControl : UserControl
    {
        public MyTimeControl()
        {
            InitializeComponent();
            this.Loaded += MyTimeControl_Loaded;
        }

        private void MyTimeControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 24; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = MyIntToString(i);
                HHBox.Items.Add(item);
            }
            HHBox.SelectedIndex = 0;

            for (int i = 0; i <= 60; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = MyIntToString(i);
                MMBox.Items.Add(item);
            }
            MMBox.SelectedIndex = 0;

            for (int i = 0; i <= 60; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = MyIntToString(i);
                SSBox.Items.Add(item);
            }
            SSBox.SelectedIndex = 0;
        }

        private string MyIntToString(int num)
        {
            string str = "";

            // 将数字加一之后变成字符串
            str = num.ToString();

            // 然后将字符串拿" "填充左侧为8位
            str = str.PadLeft(2);

            // 再将" "替换成"0"
            str = str.Replace(" ", "0");

            return str;
        }
    }
}
