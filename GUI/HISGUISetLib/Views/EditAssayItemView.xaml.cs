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
    public partial class EditAssayItemView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.AssayItem AssayItem;
        public EditAssayItemView(CommContracts.AssayItem asayItem = null)
        {
            InitializeComponent();
            YiBaoEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.YiBaoEnum));

            bIsEdit = false;
            if (asayItem != null)
            {
                this.AssayItem = asayItem;
                this.NameEdit.Text = asayItem.Name;
                this.AbbrPY.Text = asayItem.AbbrPY;
                this.AbbrWB.Text = asayItem.AbbrWB;
                this.Unit.Text = asayItem.Unit;
                this.YiBaoEnum.Text = asayItem.YiBaoEnum.ToString();
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

            if (this.YiBaoEnum.SelectedItem == null)
            {
                return;
            }
            if (bIsEdit)
            {
                AssayItem.Name = this.NameEdit.Text.Trim();
                AssayItem.AbbrPY = this.AbbrPY.Text;
                AssayItem.AbbrWB = this.AbbrWB.Text;
                AssayItem.Unit = this.Unit.Text;
                AssayItem.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                AssayItem.Price = decimal.Parse(this.Price.Text);


                CommClient.AssayItem myd = new CommClient.AssayItem();
                if (myd.UpdateAssayItem(AssayItem))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.AssayItem assayItem = new CommContracts.AssayItem();
                assayItem.Name = this.NameEdit.Text.Trim();
                assayItem.AbbrPY = this.AbbrPY.Text.Trim();
                assayItem.AbbrWB = this.AbbrWB.Text.Trim();
                assayItem.Unit = this.Unit.Text.Trim();
                assayItem.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                if (!string.IsNullOrEmpty(this.Price.Text))
                    assayItem.Price = decimal.Parse(this.Price.Text.Trim());

                CommClient.AssayItem myd = new CommClient.AssayItem();
                if (myd.SaveAssayItem(assayItem))
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
