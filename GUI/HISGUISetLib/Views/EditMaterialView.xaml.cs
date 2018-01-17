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
    /// EditMaterialView.xaml 的交互逻辑
    /// </summary>
    public partial class EditMaterialView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.MaterialItem MaterialItem;
        public EditMaterialView(CommContracts.MaterialItem materialItem = null)
        {
            InitializeComponent();
            YiBaoEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.YiBaoEnum));

            bIsEdit = false;
            if (materialItem != null)
            {
                this.MaterialItem = materialItem;
                this.NameEdit.Text = materialItem.Name;
                this.AbbrPY.Text = materialItem.AbbrPY;
                this.AbbrWB.Text = materialItem.AbbrWB;
                this.Unit.Text = materialItem.Unit;
                this.Specifications.Text = materialItem.Specifications;
                this.Manufacturer.Text = materialItem.Manufacturer;
                this.Valuable.IsChecked = materialItem.Valuable;
                this.YiBaoEnum.Text = materialItem.YiBaoEnum.ToString();
                this.MaxNum.Text = materialItem.MaxNum.ToString();
                this.MinNum.Text = materialItem.MinNum.ToString();
                this.SellPrice.Text = materialItem.SellPrice.ToString();

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
                MaterialItem.Name = this.NameEdit.Text.Trim();
                MaterialItem.AbbrPY = this.AbbrPY.Text;
                MaterialItem.AbbrWB = this.AbbrWB.Text;
                MaterialItem.Unit = this.Unit.Text;
                MaterialItem.Specifications = this.Specifications.Text;
                MaterialItem.Manufacturer = this.Manufacturer.Text;
                MaterialItem.Valuable = this.Valuable.IsChecked.Value;
                MaterialItem.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                MaterialItem.MaxNum = int.Parse(this.MaxNum.Text);
                MaterialItem.MinNum = int.Parse(this.MinNum.Text);
                MaterialItem.SellPrice = decimal.Parse(this.SellPrice.Text);


                CommClient.MaterialItem myd = new CommClient.MaterialItem();
                if (myd.UpdateMaterial(MaterialItem))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.MaterialItem materialItem = new CommContracts.MaterialItem();
                materialItem.Name = this.NameEdit.Text.Trim();
                materialItem.AbbrPY = this.AbbrPY.Text.Trim();
                materialItem.AbbrWB = this.AbbrWB.Text.Trim();
                materialItem.Unit = this.Unit.Text.Trim();
                materialItem.Specifications = this.Specifications.Text.Trim();
                materialItem.Manufacturer = this.Manufacturer.Text.Trim();
                materialItem.Valuable = this.Valuable.IsChecked.Value;
                materialItem.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                if(!string.IsNullOrEmpty(this.MaxNum.Text))
                    materialItem.MaxNum = int.Parse(this.MaxNum.Text.Trim());
                if (!string.IsNullOrEmpty(this.MinNum.Text))
                    materialItem.MinNum = int.Parse(this.MinNum.Text.Trim());
                if (!string.IsNullOrEmpty(this.SellPrice.Text))
                    materialItem.SellPrice = decimal.Parse(this.SellPrice.Text.Trim());

                CommClient.MaterialItem myd = new CommClient.MaterialItem();
                if (myd.SaveMaterial(materialItem))
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
