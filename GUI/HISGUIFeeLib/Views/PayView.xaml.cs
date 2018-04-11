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
using System.Windows.Shapes;

namespace HISGUIFeeLib.Views
{
    /// <summary>
    /// PayWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PayView : UserControl
    {
        public CommContracts.PayWayEnum PayWayEnum { get; set; }
        public decimal MoneyNum { get; set; }
        public PayView(string DiscountEditText, string DuePayMoneyEditText)
        {
            InitializeComponent();
            this.Loaded += PayView_Loaded;


            this.DiscountEdit.Text = DiscountEditText;
            this.DuePayMoneyEdit.Text = DuePayMoneyEditText;
        }

        private void PayView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void RealPayMoneyEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal Discount = 0, DuePay = 0, RealPay = 0, charge = 0;
            Discount = string.IsNullOrEmpty(this.DiscountEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DiscountEdit.Text);
            DuePay = string.IsNullOrEmpty(this.DuePayMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.DuePayMoneyEdit.Text);
            RealPay = string.IsNullOrEmpty(this.RealPayMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.RealPayMoneyEdit.Text);
            charge = RealPay - Discount - DuePay;

            this.ChargeMoneyEdit.Text = charge.ToString();
        }

        private void RealPayMoneyEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                decimal charge = string.IsNullOrEmpty(this.ChargeMoneyEdit.Text.Trim()) ? 0.0m : decimal.Parse(this.ChargeMoneyEdit.Text);
                if (charge >= 0)
                    this.OkBtn.Focus();
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(ChargeMoneyEdit.Text) >= 0)
            {
                MoneyNum = decimal.Parse(DuePayMoneyEdit.Text);
                PayWayEnum = CommContracts.PayWayEnum.现金支付;
                (this.Parent as Window).DialogResult = true;
                (this.Parent as Window).Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }
    }
}
