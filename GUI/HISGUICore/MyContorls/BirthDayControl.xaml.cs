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
    /// BirthDayControl.xaml 的交互逻辑
    /// </summary>
    public partial class BirthDayControl : UserControl
    {
        public BirthDayControl()
        {
            InitializeComponent();
            this.Loaded += BirthDayControl_Loaded;
        }

        public void SetValue(int year, int month, int day)
        {
            this.YearCombo.Text = year.ToString();
            this.MonthCombo.Text = month.ToString();
            this.DayCombo.Text = day.ToString();
        }

        public DateTime? GetValue()
        {
            if (this.YearCombo.SelectedValue == null || this.MonthCombo.SelectedValue == null || this.DayCombo.SelectedValue == null)
                return null;

            int nMonth = int.Parse(this.MonthCombo.SelectedValue.ToString().Substring(this.MonthCombo.SelectedValue.ToString().IndexOf(':') + 1, this.MonthCombo.SelectedValue.ToString().Length - this.MonthCombo.SelectedValue.ToString().IndexOf(':') - 1));
            int nYear = int.Parse(this.YearCombo.SelectedValue.ToString().Substring(this.YearCombo.SelectedValue.ToString().IndexOf(':') + 1, this.YearCombo.SelectedValue.ToString().Length - this.YearCombo.SelectedValue.ToString().IndexOf(':') - 1));
            int nDay = int.Parse(this.DayCombo.SelectedValue.ToString().Substring(this.DayCombo.SelectedValue.ToString().IndexOf(':') + 1, this.DayCombo.SelectedValue.ToString().Length - this.DayCombo.SelectedValue.ToString().IndexOf(':') - 1));

            DateTime date = new DateTime(nYear, nMonth, nDay);
            return date;
        }

        private void BirthDayControl_Loaded(object sender, RoutedEventArgs e)
        {
            //添加item

            for (int i = 0; i <= 150; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = DateTime.Now.Year - i;
                YearCombo.Items.Add(item);
            }

            for (int i = 1; i <= 12; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                MonthCombo.Items.Add(item);
            }
        }

        private void YearCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDayCombo();
        }

        private void MonthCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDayCombo();
        }

        private void UpdateDayCombo()
        {
            var year = this.YearCombo.SelectedValue;
            var month = this.MonthCombo.SelectedValue;
            if (month != null && year != null)
            {
                int nMonth = int.Parse(month.ToString().Substring(month.ToString().IndexOf(':') + 1, month.ToString().Length - month.ToString().IndexOf(':') - 1));
                int nYear = int.Parse(year.ToString().Substring(year.ToString().IndexOf(':') + 1, year.ToString().Length - year.ToString().IndexOf(':') - 1));

                DayCombo.Items.Clear();

                int nDayNum = 0;
                if (nMonth == 2)
                {
                    if ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0)
                    {
                        nDayNum = 29;
                    }
                    else
                    {
                        nDayNum = 28;
                    }

                }
                else if (nMonth == 1 || nMonth == 3 || nMonth == 5 || nMonth == 7 || nMonth == 8 || nMonth == 10 || nMonth == 12)
                {
                    nDayNum = 31;
                }
                else
                {
                    nDayNum = 30;
                }

                for (int i = 1; i <= nDayNum; i++)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = i;
                    DayCombo.Items.Add(item);
                }
            }
        }
    }
}
