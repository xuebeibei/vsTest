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
    public partial class EditTherapyItemView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.TherapyItem TherapyItem;
        public EditTherapyItemView(CommContracts.TherapyItem therapyItem = null)
        {
            InitializeComponent();
            YiBaoEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.YiBaoEnum));

            bIsEdit = false;
            if (therapyItem != null)
            {
                this.TherapyItem = therapyItem;
                this.NameEdit.Text = therapyItem.Name;
                this.AbbrPY.Text = therapyItem.AbbrPY;
                this.AbbrWB.Text = therapyItem.AbbrWB;
                this.Unit.Text = therapyItem.Unit;
                this.YiBaoEnum.Text = therapyItem.YiBaoEnum.ToString();
                this.Price.Text = therapyItem.Price.ToString();

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
                TherapyItem.Name = this.NameEdit.Text.Trim();
                TherapyItem.AbbrPY = this.AbbrPY.Text;
                TherapyItem.AbbrWB = this.AbbrWB.Text;
                TherapyItem.Unit = this.Unit.Text;
                TherapyItem.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                TherapyItem.Price = decimal.Parse(this.Price.Text);


                CommClient.TherapyItem myd = new CommClient.TherapyItem();
                if (myd.UpdateTherapyItem(TherapyItem))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.TherapyItem therapyItem = new CommContracts.TherapyItem();
                therapyItem.Name = this.NameEdit.Text.Trim();
                therapyItem.AbbrPY = this.AbbrPY.Text.Trim();
                therapyItem.AbbrWB = this.AbbrWB.Text.Trim();
                therapyItem.Unit = this.Unit.Text.Trim();
                therapyItem.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                if (!string.IsNullOrEmpty(this.Price.Text))
                    therapyItem.Price = decimal.Parse(this.Price.Text.Trim());

                CommClient.TherapyItem myd = new CommClient.TherapyItem();
                if (myd.SaveTherapyItem(therapyItem))
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
