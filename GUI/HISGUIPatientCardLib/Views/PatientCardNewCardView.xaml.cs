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

namespace HISGUIPatientCardLib.Views
{

    [Export]
    [Export("PatientCardNewCardView", typeof(PatientCardNewCardView))]
    public partial class PatientCardNewCardView : HISGUIViewBase
    {
        CommContracts.PatientCardManage m_patientCardManage;
        CommContracts.Patient m_Patient;

        public PatientCardNewCardView()
        {
            InitializeComponent();
            

            this.Loaded += PatientCardMsgView_Loaded;
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void newPatientCard()
        {
            CommClient.Patient patientClient = new CommClient.Patient();

            m_Patient = new CommContracts.Patient();
            m_Patient.PID = patientClient.getNewPID();
            m_patientCardManage = new CommContracts.PatientCardManage();
            m_patientCardManage.Patient = m_Patient;
            m_patientCardManage.CardNo = m_Patient.PID;


            var vm = this.DataContext as HISGUIPatientCardVM;
            vm.CurrentPatient = m_Patient;


        }

        private bool SavePatientCard()
        {
            return false;
        }

        private bool LostPatientCard()
        {
            return false;
        }

        private bool UpdatePatientMsg()
        {
            return false;
        }

        private List<CommContracts.PatientCardManage> GetAllPatientCardRecords()
        {
            return null;
        }

        private void FindPatient()
        {

        }

        private void InitCombo()
        {
            this.YBCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.FeeTypeEnum));
            this.YBCombo.SelectedIndex = 0;

            this.GenderCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.GenderEnum));
            this.GenderCombo.SelectedIndex = 0;

            this.ZJCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.ZhengJianEnum));
            this.ZJCombo.SelectedIndex = 0;

            this.JobCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PatientJobEnum));
            this.JobCombo.SelectedIndex = 0;

            this.ConnectGX.ItemsSource = Enum.GetValues(typeof(CommContracts.GuanXiEnum));
            this.ConnectGX.SelectedIndex = 0;

            this.CardTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PatientCardEnum));
            this.CardTypeCombo.SelectedIndex = 0;

            this.VolkCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.VolkEnum));
            this.VolkCombo.SelectedIndex = 0;

            this.CountryCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.CountryEnum));
            this.CountryCombo.SelectedIndex = 0;

            this.HYCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.HunYinEnum));
            this.HYCombo.SelectedIndex = 0;
        }

        private void PatientCardMsgView_Loaded(object sender, RoutedEventArgs e)
        {
            InitCombo();
            //var vm = this.DataContext as HISGUIPatientCardVM;

            //CommClient.Patient pClient = new CommClient.Patient();

            //CommContracts.Patient patient = new CommContracts.Patient();
            //patient.PID = pClient.getNewPID();
            //patient.PatientCardNo = patient.PID;
            //vm.CurrentPatient = patient;

            //CommContracts.PatientCardManage patientCardManage = new CommContracts.PatientCardManage();
            //patientCardManage.CurrentTime = DateTime.Now;
            //patientCardManage.User = vm.CurrentUser;
            //patientCardManage.Patient = patient;

            //vm.PatientCardManage = patientCardManage;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateYbType();
        }

        private void updateYbType()
        {
            if (YBCombo.SelectedItem == null)
            {
                VisualStateManager.GoToState(this, "VisualState2", false);
                return;
            }

            var current = (CommContracts.FeeTypeEnum)YBCombo.SelectedItem;

            if (current == CommContracts.FeeTypeEnum.自费)
            {
                VisualStateManager.GoToState(this, "VisualState2", false);
            }
            else if (current == CommContracts.FeeTypeEnum.城镇职工 || current == CommContracts.FeeTypeEnum.城乡居民)
            {
                VisualStateManager.GoToState(this, "VisualState3", false);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string strIDCardNum = ZJNumBox.Text.Trim();

            bool bIsIDCardOK = IDCardHellper.IsIDCardNumOk(strIDCardNum);

            if (!bIsIDCardOK)
            {
                this.ZJNumBox.BorderBrush = new SolidColorBrush(Colors.Red);  
            }
            else
            {
                int year = 0, month = 0, day = 0, sex = 0;
                IDCardHellper.GetBirthAndSexFromIDCard(strIDCardNum, ref year, ref month, ref day, ref sex);

                this.myBirthControl.SetValue(year, month, day);

                if (sex % 2 == 0)
                {
                    
                }
                else
                {
                    
                }
            }
        }

        private void ZJNumBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ZJNumBox.BorderBrush = new SolidColorBrush(Colors.LightGray);
        }

        private bool check()
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            bool bIsOK = true;
            if (string.IsNullOrEmpty(vm.CurrentPatient.Name))
            {
                bIsOK = false;
                this.txt_Name.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                this.txt_Name.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }

            if (string.IsNullOrEmpty(vm.CurrentPatient.ZhengJianNum) || !IDCardHellper.IsIDCardNumOk(vm.CurrentPatient.ZhengJianNum))
            {
                bIsOK = false;
                this.ZJNumBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                this.ZJNumBox.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }

            return bIsOK;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;
            vm.CurrentPatient.BirthDay = this.myBirthControl.GetValue();

            if (!check())
            {
                return;
            }

            vm.PatientCardManage.CardNo = vm.CurrentPatient.PatientCardNo;
            vm.PatientCardManage.CardManageEnum = CommContracts.CardManageEnum.eNew;
            vm.PatientCardManage.UserID = vm.CurrentUser.ID;
            string ErrorMsg = "";
            if (vm.SavePatientCardManage(vm.PatientCardManage, ref ErrorMsg))
            {

            }
            else
            {
                MessageBox.Show(ErrorMsg);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void NormalRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            // 办理普通卡
            VisualStateManager.GoToState(this, "VisualState", false);
        }

        private void TempRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            // 办理临时卡
            VisualStateManager.GoToState(this, "VisualState1", false);
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newPatientCard();
        }

        private void LostBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReNewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
