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
    /// EditMedicineView.xaml 的交互逻辑
    /// </summary>
    public partial class EditMedicineView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.Medicine Medicine;
        public EditMedicineView(CommContracts.Medicine medicine = null)
        {
            InitializeComponent();
            MedicineTypeEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.MedicineTypeEnum));
            DosageFormEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.DosageFormEnum));
            YiBaoEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.YiBaoEnum));

            bIsEdit = false;
            if (medicine != null)
            {
                this.Medicine = medicine;
                this.NameEdit.Text = medicine.Name;
                this.MedicineTypeEnumCombo.SelectedItem = medicine.MedicineTypeEnum;
                this.Abbr1Edit.Text = medicine.Abbr1;
                this.Abbr2Edit.Text = medicine.Abbr2;
                this.Abbr3Edit.Text = medicine.Abbr3;
                this.DosageFormEnumCombo.SelectedItem = medicine.DosageFormEnum;
                this.Unit.Text = medicine.Unit;
                this.AdministrationRoute.Text = medicine.AdministrationRoute;
                this.Specifications.Text = medicine.Specifications;
                this.Manufacturer.Text = medicine.Manufacturer;
                this.PoisonousHemp.IsChecked = medicine.PoisonousHemp;
                this.Valuable.IsChecked = medicine.Valuable;
                this.EssentialDrugs.IsChecked = medicine.EssentialDrugs;
                this.YiBaoEnum.Text = medicine.YiBaoEnum.ToString();
                this.MaxNum.Text = medicine.MaxNum.ToString();
                this.MinNum.Text = medicine.MinNum.ToString();
                this.SellPrice.Text = medicine.SellPrice.ToString();

                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.MedicineTypeEnumCombo.SelectedItem == null)
            {
                return;
            }
            if (bIsEdit)
            {
                Medicine.Name = this.NameEdit.Text.Trim();
                Medicine.MedicineTypeEnum = (CommContracts.MedicineTypeEnum)this.MedicineTypeEnumCombo.SelectedItem;
                Medicine.Abbr1 = this.Abbr1Edit.Text;
                Medicine.Abbr2 = this.Abbr2Edit.Text;
                Medicine.Abbr3 = this.Abbr3Edit.Text;
                Medicine.DosageFormEnum = (CommContracts.DosageFormEnum)this.DosageFormEnumCombo.SelectedItem;
                Medicine.Unit = this.Unit.Text;
                Medicine.AdministrationRoute = this.AdministrationRoute.Text;
                Medicine.Specifications = this.Specifications.Text;
                Medicine.Manufacturer = this.Manufacturer.Text;
                Medicine.PoisonousHemp = this.PoisonousHemp.IsChecked.Value;
                Medicine.Valuable = this.Valuable.IsChecked.Value;
                Medicine.EssentialDrugs = this.EssentialDrugs.IsChecked.Value;
                Medicine.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                Medicine.MaxNum = int.Parse(this.MaxNum.Text);
                Medicine.MinNum = int.Parse(this.MinNum.Text);
                Medicine.SellPrice = decimal.Parse(this.SellPrice.Text);


                CommClient.Medicine myd = new CommClient.Medicine();
                if (myd.UpdateMedicine(Medicine))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Medicine medicine = new CommContracts.Medicine();
                medicine.Name = this.NameEdit.Text.Trim();
                medicine.MedicineTypeEnum = (CommContracts.MedicineTypeEnum)this.MedicineTypeEnumCombo.SelectedItem;
                medicine.Abbr1 = this.Abbr1Edit.Text;
                medicine.Abbr2 = this.Abbr2Edit.Text;
                medicine.Abbr3 = this.Abbr3Edit.Text;
                medicine.DosageFormEnum = (CommContracts.DosageFormEnum)this.DosageFormEnumCombo.SelectedItem;
                medicine.Unit = this.Unit.Text;
                medicine.AdministrationRoute = this.AdministrationRoute.Text;
                medicine.Specifications = this.Specifications.Text;
                medicine.Manufacturer = this.Manufacturer.Text;
                medicine.PoisonousHemp = this.PoisonousHemp.IsChecked.Value;
                medicine.Valuable = this.Valuable.IsChecked.Value;
                medicine.EssentialDrugs = this.EssentialDrugs.IsChecked.Value;
                medicine.YiBaoEnum = (CommContracts.YiBaoEnum)this.YiBaoEnum.SelectedItem;
                medicine.MaxNum = int.Parse(this.MaxNum.Text);
                medicine.MinNum = int.Parse(this.MinNum.Text);
                medicine.SellPrice = decimal.Parse(this.SellPrice.Text);
                CommClient.Medicine myd = new CommClient.Medicine();
                if (myd.SaveMedicine(medicine))
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
