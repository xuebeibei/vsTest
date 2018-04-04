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

        private void SetMyComboRange(ComboBox comboBox, int nMin, int nMax)
        {
            if (nMin > nMax)
                return;

            if (comboBox == null)
                return;

            if (comboBox.Items == null)
                return;
            comboBox.Items.Clear();

            for (int i = nMin; i <= nMax; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = MyIntToString(i);
                comboBox.Items.Add(item);
            }
            comboBox.SelectedIndex = 0;
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

        public void SetMyValue(string timeValue)
        {
            if (string.IsNullOrEmpty(timeValue))
            {
                this.HHBox.SelectedIndex = 0;
                this.MMBox.SelectedIndex = 0;
                this.SSBox.SelectedIndex = 0;
                return;
            }

            if (timeValue.Length == 8)
            {
                this.HHBox.Text = timeValue.Substring(0, 2);
                this.MMBox.Text = timeValue.Substring(3, 2);
                this.SSBox.Text = timeValue.Substring(6, 2);
            }
        }

        public string GetMyValue()
        {
            return this.HHBox.Text + ":" + this.MMBox.Text + ":" + this.SSBox.Text;
        }

        public void SetRangeValue(string minTimeValue, string maxTimeValue)
        {
            if (string.IsNullOrEmpty(minTimeValue) || string.IsNullOrEmpty(maxTimeValue))
            {
                return;
            }
            int nMinHH = 0, nMinMM = 0, nMinSS = 0, nMaxHH = 0, nMaxMM = 0, nMaxSS = 0;
            if (minTimeValue.Length == 8)
            {
                nMinHH = int.Parse(minTimeValue.Substring(0, 2));
                nMinMM = int.Parse(minTimeValue.Substring(3, 2));
                nMinSS = int.Parse(minTimeValue.Substring(6, 2));

                nMaxHH = int.Parse(maxTimeValue.Substring(0, 2));
                nMaxMM = int.Parse(maxTimeValue.Substring(3, 2));
                nMaxSS = int.Parse(maxTimeValue.Substring(6, 2));

                DateTime minTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, nMinHH, nMinMM, nMinSS);
                DateTime maxTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, nMaxHH, nMaxMM, nMaxSS);
                if (minTime > maxTime)
                    return;


                SetMyComboRange(this.HHBox, nMinHH, nMaxHH);
                SetMyComboRange(this.MMBox, nMinMM, nMaxMM);
                SetMyComboRange(this.SSBox, nMinSS, nMaxSS);
            }
        }
    }
}
