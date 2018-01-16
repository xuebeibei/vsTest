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
    public partial class EditSupplierView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.Supplier Supplier;
        public EditSupplierView(CommContracts.Supplier supplier = null)
        {
            InitializeComponent();
            bIsEdit = false;
            if (supplier != null)
            {
                this.Supplier = supplier;
                this.NameEdit.Text = supplier.Name;
                this.ContentsEdit.Text = supplier.Contents;
                this.TelEdit.Text = supplier.Tel;
                this.AddressEdit.Text = supplier.Address;
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
                Supplier.Name = this.NameEdit.Text.Trim();
                Supplier.Contents = this.ContentsEdit.Text.Trim();
                Supplier.Tel = this.TelEdit.Text.Trim();
                Supplier.Address = this.AddressEdit.Text.Trim();

                CommClient.Supplier myd = new CommClient.Supplier();
                if (myd.UpdateSupplier(Supplier))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Supplier supplier = new CommContracts.Supplier();
                supplier.Name = this.NameEdit.Text.Trim();
                supplier.Contents = this.ContentsEdit.Text.Trim();
                supplier.Tel = this.TelEdit.Text.Trim();
                supplier.Address = this.AddressEdit.Text.Trim();

                CommClient.Supplier myd = new CommClient.Supplier();
                if (myd.SaveSupplier(supplier))
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
