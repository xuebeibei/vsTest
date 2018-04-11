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

namespace HISGUIFeeLib.Views
{
    /// <summary>
    /// ReturnPayView.xaml 的交互逻辑
    /// </summary>
    public partial class ReturnPayView : UserControl
    {
        public ReturnPayView()
        {
            InitializeComponent();
            this.Loaded += ReturnPayView_Loaded;
        }

        private void ReturnPayView_Loaded(object sender, RoutedEventArgs e)
        {
            ReturnWayCombo.SelectedItem = null;
            DueReturnMoneyEdit.Text = "";
            ServiceMoneyEdit.Text = "";
        }

        private void ServiceMoneyEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal DueReturn = 0, ServiceMoney = 0, RealReturn = 0;
            DueReturn = string.IsNullOrEmpty(this.DueReturnMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DueReturnMoneyEdit.Text);
            ServiceMoney = string.IsNullOrEmpty(this.ServiceMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.ServiceMoneyEdit.Text);
            RealReturn = DueReturn - ServiceMoney;

            this.RealReturnMoneyEdit.Text = RealReturn.ToString();
        }

        private void ServiceMoneyEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                //this.ReturnBtn.Focus();
            }
        }
    }
}
