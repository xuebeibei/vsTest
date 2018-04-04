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

namespace HISGUISetLib.Views
{
    /// <summary>
    /// EditSignalItemView.xaml 的交互逻辑
    /// </summary>
    public partial class EditSignalItemView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.SignalItem SignalItem;
        public EditSignalItemView(CommContracts.SignalItem signalItem = null)
        {
            InitializeComponent();
            SignalItemCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.SignalTimeEnum));
            SignalItemCombo.SelectedItem = CommContracts.SignalTimeEnum.上午;
            bIsEdit = false;
            if (signalItem != null)
            {
                this.SignalItem = signalItem;
                this.NameEdit.Text = signalItem.Name;
                this.SellPrice.Text = signalItem.SellPrice.ToString();
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.SignalItemCombo.SelectedItem == null)
            {
                return;
            }
            if (bIsEdit)
            {
                SignalItem.Name = this.NameEdit.Text.Trim();
                
                if (!string.IsNullOrEmpty(this.SellPrice.Text.Trim()))
                    SignalItem.SellPrice = decimal.Parse(this.SellPrice.Text.Trim());

                CommClient.SignalItem myd = new CommClient.SignalItem();
                if (myd.UpdateSignalItem(SignalItem))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.SignalItem signalItem = new CommContracts.SignalItem();
                signalItem.Name = this.NameEdit.Text.Trim();
                if (!string.IsNullOrEmpty(this.SellPrice.Text.Trim()))
                    signalItem.SellPrice = decimal.Parse(this.SellPrice.Text.Trim());


                CommClient.SignalItem myd = new CommClient.SignalItem();
                if (myd.SaveSignalItem(signalItem))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }
    }
}
