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

            bIsEdit = false;
            if (medicine != null)
            {
                this.Medicine = medicine;
                this.NameEdit.Text = medicine.Name;
                this.MedicineTypeEnumCombo.SelectedItem = medicine.MedicineTypeEnum;
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
