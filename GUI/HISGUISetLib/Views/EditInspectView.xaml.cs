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
    public partial class EditInspectItemView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.InspectItem Inspect;
        public EditInspectItemView(CommContracts.InspectItem inspect = null)
        {
            InitializeComponent();
            YiBaoEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.YiBaoEnum));

            bIsEdit = false;
            if (inspect != null)
            {
                this.Inspect = inspect;
                this.NameEdit.Text = inspect.Name;
                this.AbbrPY.Text = inspect.AbbrPY;
                this.AbbrWB.Text = inspect.AbbrWB;
                this.Unit.Text = inspect.Unit;

                this.YiBaoEnum.Text = inspect.YiBaoEnum.ToString();
                this.SellPrice.Text = inspect.Price.ToString();

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
                Inspect.Name = this.NameEdit.Text.Trim();
                Inspect.AbbrPY = this.AbbrPY.Text;
                Inspect.AbbrWB = this.AbbrWB.Text;
                Inspect.Unit = this.Unit.Text;
                Inspect.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;

                Inspect.Price = decimal.Parse(this.SellPrice.Text);


                CommClient.InspectItem myd = new CommClient.InspectItem();
                if (myd.UpdateInspectItem(Inspect))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.InspectItem inspect = new CommContracts.InspectItem();
                inspect.Name = this.NameEdit.Text.Trim();
                inspect.AbbrPY = this.AbbrPY.Text.Trim();
                inspect.AbbrWB = this.AbbrWB.Text.Trim();
                inspect.Unit = this.Unit.Text.Trim();
                inspect.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                if (!string.IsNullOrEmpty(this.SellPrice.Text))
                    inspect.Price = decimal.Parse(this.SellPrice.Text.Trim());

                CommClient.InspectItem myd = new CommClient.InspectItem();
                if (myd.SaveInspectItem(inspect))
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
