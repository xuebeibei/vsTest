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
        private CommContracts.MaterialItem Material;
        public EditMaterialView(CommContracts.MaterialItem material = null)
        {
            InitializeComponent();
            YiBaoEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.YiBaoEnum));

            bIsEdit = false;
            if (material != null)
            {
                this.Material = material;
                this.NameEdit.Text = material.Name;
                this.AbbrPY.Text = material.AbbrPY;
                this.AbbrWB.Text = material.AbbrWB;
                this.Unit.Text = material.Unit;
                this.Specifications.Text = material.Specifications;
                this.Manufacturer.Text = material.Manufacturer;
                this.Valuable.IsChecked = material.Valuable;
                this.YiBaoEnum.Text = material.YiBaoEnum.ToString();
                this.MaxNum.Text = material.MaxNum.ToString();
                this.MinNum.Text = material.MinNum.ToString();
                this.SellPrice.Text = material.SellPrice.ToString();

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
                Material.Name = this.NameEdit.Text.Trim();
                Material.AbbrPY = this.AbbrPY.Text;
                Material.AbbrWB = this.AbbrWB.Text;
                Material.Unit = this.Unit.Text;
                Material.Specifications = this.Specifications.Text;
                Material.Manufacturer = this.Manufacturer.Text;
                Material.Valuable = this.Valuable.IsChecked.Value;
                Material.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                Material.MaxNum = int.Parse(this.MaxNum.Text);
                Material.MinNum = int.Parse(this.MinNum.Text);
                Material.SellPrice = decimal.Parse(this.SellPrice.Text);


                CommClient.MaterialItem myd = new CommClient.MaterialItem();
                if (myd.UpdateMaterial(Material))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.MaterialItem material = new CommContracts.MaterialItem();
                material.Name = this.NameEdit.Text.Trim();
                material.AbbrPY = this.AbbrPY.Text.Trim();
                material.AbbrWB = this.AbbrWB.Text.Trim();
                material.Unit = this.Unit.Text.Trim();
                material.Specifications = this.Specifications.Text.Trim();
                material.Manufacturer = this.Manufacturer.Text.Trim();
                material.Valuable = this.Valuable.IsChecked.Value;
                material.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                if(!string.IsNullOrEmpty(this.MaxNum.Text))
                    material.MaxNum = int.Parse(this.MaxNum.Text.Trim());
                if (!string.IsNullOrEmpty(this.MinNum.Text))
                    material.MinNum = int.Parse(this.SellPrice.Text.Trim());
                if (!string.IsNullOrEmpty(this.MinNum.Text))
                    material.SellPrice = decimal.Parse(this.SellPrice.Text.Trim());

                CommClient.MaterialItem myd = new CommClient.MaterialItem();
                if (myd.SaveMaterial(material))
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
