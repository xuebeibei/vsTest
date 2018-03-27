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
    [Export("PatientCardMsgView", typeof(PatientCardMsgView))]
    public partial class PatientCardMsgView : HISGUIViewBase
    {
        public PatientCardMsgView()
        {
            InitializeComponent();
            this.YBCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.YbEnum));

            this.Loaded += PatientCardMsgView_Loaded;
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void PatientCardMsgView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            CommClient.Patient pClient = new CommClient.Patient();

            CommContracts.Patient patient = new CommContracts.Patient();
            patient.PID = pClient.getNewPID();
            patient.PatientCardNo = patient.PID;
            vm.CurrentPatient = patient;

            CommContracts.PatientCardManage patientCardManage = new CommContracts.PatientCardManage();
            patientCardManage.CurrentTime = DateTime.Now;
            patientCardManage.User = vm.CurrentUser;
            patientCardManage.Patient = patient;

            vm.PatientCardManage = patientCardManage;

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

            var current = (CommContracts.YbEnum)YBCombo.SelectedItem;

            if (current == CommContracts.YbEnum.自费)
            {
                VisualStateManager.GoToState(this, "VisualState2", false);
            }
            else if (current == CommContracts.YbEnum.城镇职工 || current == CommContracts.YbEnum.城乡居民)
            {
                VisualStateManager.GoToState(this, "VisualState3", false);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string strIDCardNum = IDCardTextBox.Text.Trim();

            bool bIsIDCardOK = IDCardHellper.IsIDCardNumOk(strIDCardNum);

            if (!bIsIDCardOK)
            {
                this.IDCardTextBox.Foreground = new SolidColorBrush(Colors.Red);  //用固态画刷填充前景色
            }
            else
            {
                int year = 0, month = 0, day = 0, sex = 0;
                IDCardHellper.GetBirthAndSexFromIDCard(strIDCardNum, ref year, ref month, ref day, ref sex);

                this.myBirthControl.SetValue(year, month, day);

                if (sex % 2 == 0)
                {
                    this.WomanRadioBtn.IsChecked = true;
                }
                else
                {
                    this.ManRadioBtn.IsChecked = true;
                }
            }
        }

        private void IDCardTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IDCardTextBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 保存
            var vm = this.DataContext as HISGUIPatientCardVM;
            vm.CurrentPatient.BirthDay = this.myBirthControl.GetValue();

            vm.PatientCardManage.CardNo = vm.CurrentPatient.PatientCardNo;
            vm.PatientCardManage.CardManageEnum = CommContracts.CardManageEnum.eNew;
            vm.PatientCardManage.UserID = vm.CurrentUser.ID;
            string ErrorMsg = "";
            if (vm.SavePatientCardManage(vm.PatientCardManage, ref ErrorMsg))
            {
                (this.Parent as Window).DialogResult = true;
                (this.Parent as Window).Close();
            }
            else
            {
                MessageBox.Show(ErrorMsg);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
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
    }
}
