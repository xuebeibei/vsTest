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
    /// EditPatientView.xaml 的交互逻辑
    /// </summary>
    public partial class EditPatientView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.Patient Patient;
        public EditPatientView(CommContracts.Patient patient = null)
        {
            InitializeComponent();
            GenderCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.GenderEnum));
            VolkEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.VolkEnum));

            bIsEdit = false;
            if (patient != null)
            {
                this.Patient = patient;
                this.Name.Text = patient.Name;
                this.IDCardNo.Text = patient.IDCardNo;
                this.JiGuan.Text = patient.JiGuan;
                this.Tel.Text = patient.Tel;
                this.GenderCombo.Text = patient.Gender.ToString();
                this.VolkEnumCombo.Text = patient.Volk.ToString();
                this.BirthDay.SelectedDate = patient.BirthDay;

                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Name.Text.Trim()))
            {
                return;
            }

            if (this.GenderCombo.SelectedItem == null)
            {
                return;
            }
            if (bIsEdit)
            {
                Patient.Name = this.Name.Text.Trim();
                Patient.IDCardNo = this.IDCardNo.Text;
                Patient.JiGuan = this.JiGuan.Text;
                Patient.Tel = this.Tel.Text;
                Patient.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                Patient.Volk = (CommContracts.VolkEnum)this.VolkEnumCombo.SelectedItem;
                Patient.BirthDay = this.BirthDay.SelectedDate;


                CommClient.Patient myd = new CommClient.Patient();
                if (myd.UpdatePatient(Patient))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Patient patient = new CommContracts.Patient();
                patient.Name = this.Name.Text.Trim();
                patient.IDCardNo = this.IDCardNo.Text.Trim();
                patient.JiGuan = this.JiGuan.Text.Trim();
                patient.Tel = this.Tel.Text.Trim();
                patient.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                patient.Volk = (CommContracts.VolkEnum)this.VolkEnumCombo.SelectedItem;
                patient.BirthDay = this.BirthDay.SelectedDate;

                CommClient.Patient myd = new CommClient.Patient();
                if (myd.SavePatient(patient))
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
