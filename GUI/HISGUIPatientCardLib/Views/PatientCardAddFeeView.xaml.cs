using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
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
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUICore.MyContorls;
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using Microsoft.VisualBasic;

namespace HISGUIPatientCardLib.Views
{
    [Export]
    [Export("PatientCardAddFeeView", typeof(PatientCardAddFeeView))]
    public partial class PatientCardAddFeeView : HISGUIViewBase
    {
        public PatientCardAddFeeView()
        {
            InitializeComponent();
            this.Loaded += PatientCardAddFeeView_Loaded;
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void InitCombo()
        {
            this.FeeTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.FeeTypeEnum));
            this.FeeTypeCombo.SelectedIndex = 0;

            this.PrePayWayCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PrePayWayEnum));
            this.PrePayWayCombo.SelectedIndex = 0;

            this.ZJCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.ZhengJianEnum));
            this.ZJCombo.SelectedIndex = 0;

            this.CardTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PatientCardEnum));
            this.CardTypeCombo.SelectedIndex = 0;
        }

        private void PatientCardAddFeeView_Loaded(object sender, RoutedEventArgs e)
        {
            InitCombo();
        }

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            String strPatientCardNum = Interaction.InputBox("请输入就诊卡卡号", "读卡", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;

            updatePatientsMsg(strPatientCardNum);
        }

        private void updatePatientsMsg(String strPatientCardNum)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;
            CommContracts.Patient patient = new CommContracts.Patient();
            string strAge = "";
            if (string.IsNullOrEmpty(strPatientCardNum))
            {
                vm.CurrentPatient = patient;
                CommClient.PatientCardPrePay prePayClient = new CommClient.PatientCardPrePay();
                List<CommContracts.PatientCardPrePay> list = prePayClient.GetAllPrePay(patient.ID);
                this.listView1.ItemsSource = list;
                this.AgeBox.Text = strAge;
                return;
            }

            CommClient.Patient patientClient = new CommClient.Patient();
            
            string ErrorMsg = "";
            patient = patientClient.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);

            if (patient == null)
            {
                MessageBox.Show(ErrorMsg);
            }
            else
            {
                vm.CurrentPatient = patient;
                CommClient.PatientCardPrePay prePayClient = new CommClient.PatientCardPrePay();
                List<CommContracts.PatientCardPrePay> list = prePayClient.GetAllPrePay(patient.ID);
                this.listView1.ItemsSource = list;

                strAge = IDCardHellper.GetAge(patient.BirthDay.Value.Year, patient.BirthDay.Value.Month, patient.BirthDay.Value.Day);
                this.AgeBox.Text = strAge;
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            // 保存收取
            if (string.IsNullOrEmpty(this.FeeNumBox.Text))
            {
                return;
            }

            if (Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2) < 0)
            {
                return;
            }

            var vm = this.DataContext as HISGUIPatientCardVM;

            CommContracts.PatientCardPrePay prePay = new CommContracts.PatientCardPrePay();
            prePay.PrePayType = CommContracts.PrePayTypeEnum.缴款;
            prePay.PrePayMoney = Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2);
            prePay.PrePayWayEnum = (CommContracts.PrePayWayEnum)this.PrePayWayCombo.SelectedItem;
            prePay.PatientID = vm.CurrentPatient.ID;
            prePay.UserID = vm.CurrentUser.ID;
            prePay.CurrentTime = DateTime.Now;

            CommClient.PatientCardPrePay prePayClient = new CommClient.PatientCardPrePay();

            int prePayID = 0; string ErrorMsg = "";
            if (prePayClient.SavePrePay(prePay, ref prePayID, ref ErrorMsg))
            {
                CommClient.Patient patientClient = new CommClient.Patient();
                vm.CurrentPatient.PatientCardBalance += Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2);

                if (patientClient.UpdatePatient(vm.CurrentPatient, ref ErrorMsg))
                {
                    MessageBox.Show("OK");
                    updatePatientsMsg(vm.CurrentPatient.PatientCardNo);
                }
                else
                {
                    vm.CurrentPatient.PatientCardBalance -= Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2);
                    prePayClient.DeletePrePay(prePayID);

                    MessageBox.Show("Error:" + ErrorMsg);
                }
            }
            else
            {
                MessageBox.Show("Error:"+ ErrorMsg);
            }
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            // 保存退款 
            if (string.IsNullOrEmpty(this.FeeNumBox.Text))
            {
                return;
            }

            if (Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2) < 0)
            {
                return;
            }

            if (Math.Round(Decimal.Parse(this.BalanceBox.Text), 2) - Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2) < 0)
            {
                return;
            }

            var vm = this.DataContext as HISGUIPatientCardVM;
            CommContracts.PatientCardPrePay prePay = new CommContracts.PatientCardPrePay();
            prePay.PrePayType = CommContracts.PrePayTypeEnum.退款;
            prePay.PrePayMoney = Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2);
            prePay.PrePayWayEnum = (CommContracts.PrePayWayEnum)this.PrePayWayCombo.SelectedItem;
            prePay.PatientID = vm.CurrentPatient.ID;
            prePay.UserID = vm.CurrentUser.ID;
            prePay.CurrentTime = DateTime.Now;

            CommClient.PatientCardPrePay prePayClient = new CommClient.PatientCardPrePay();
            int prePayID = 0; string ErrorMsg = "";
            if (prePayClient.SavePrePay(prePay, ref prePayID, ref ErrorMsg))
            {
                CommClient.Patient patientClient = new CommClient.Patient();
                vm.CurrentPatient.PatientCardBalance -= Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2);

                if(patientClient.UpdatePatient(vm.CurrentPatient, ref ErrorMsg))
                {
                    MessageBox.Show("OK");
                    updatePatientsMsg(vm.CurrentPatient.PatientCardNo);
                }
                else
                {
                    vm.CurrentPatient.PatientCardBalance += Math.Round(Decimal.Parse(this.FeeNumBox.Text), 2);
                    prePayClient.DeletePrePay(prePayID);
                    MessageBox.Show("Error:" + ErrorMsg);
                }
            }
            else
            {
                MessageBox.Show("Error" + ErrorMsg);
            }
        }

        private void RePrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            updatePatientsMsg("");
        }
    }
}
