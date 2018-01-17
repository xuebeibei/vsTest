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
    /// EditOtherServiceItemView.xaml 的交互逻辑
    /// </summary>
    public partial class EditOtherServiceItemView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.OtherServiceItem OtherServiceItem;
        public EditOtherServiceItemView(CommContracts.OtherServiceItem asayItem = null)
        {
            InitializeComponent();

            bIsEdit = false;
            if (asayItem != null)
            {
                this.OtherServiceItem = asayItem;
                this.NameEdit.Text = asayItem.Name;
                this.AbbrPY.Text = asayItem.AbbrPY;
                this.AbbrWB.Text = asayItem.AbbrWB;
                this.Unit.Text = asayItem.Unit;
                this.Price.Text = asayItem.Price.ToString();

                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }
            if (bIsEdit)
            {
                OtherServiceItem.Name = this.NameEdit.Text.Trim();
                OtherServiceItem.AbbrPY = this.AbbrPY.Text;
                OtherServiceItem.AbbrWB = this.AbbrWB.Text;
                OtherServiceItem.Unit = this.Unit.Text;
                OtherServiceItem.Price = decimal.Parse(this.Price.Text);


                CommClient.OtherServiceItem myd = new CommClient.OtherServiceItem();
                if (myd.UpdateOtherServiceItem(OtherServiceItem))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.OtherServiceItem OtherServiceItem = new CommContracts.OtherServiceItem();
                OtherServiceItem.Name = this.NameEdit.Text.Trim();
                OtherServiceItem.AbbrPY = this.AbbrPY.Text.Trim();
                OtherServiceItem.AbbrWB = this.AbbrWB.Text.Trim();
                OtherServiceItem.Unit = this.Unit.Text.Trim();
                if (!string.IsNullOrEmpty(this.Price.Text))
                    OtherServiceItem.Price = decimal.Parse(this.Price.Text.Trim());

                CommClient.OtherServiceItem myd = new CommClient.OtherServiceItem();
                if (myd.SaveOtherServiceItem(OtherServiceItem))
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
