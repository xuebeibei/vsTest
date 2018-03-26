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
            //添加item

            for (int i = 0; i <= 150; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = DateTime.Now.Year - i;
                YearCombo.Items.Add(item);
            }

            for (int i = 1; i <= 12; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                MonthCombo.Items.Add(item);
            }

            //for (int i = 1; i <= 31; i++)
            //{
            //    ComboBoxItem item = new ComboBoxItem();
            //    item.Content = i;
            //    DayCombo.Items.Add(item);
            //}



            var vm = this.DataContext as HISGUIPatientCardVM;

            CommClient.Patient pClient = new CommClient.Patient();

            CommContracts.Patient patient = new CommContracts.Patient();
            patient.PID = pClient.getNewPID();
            patient.PatientCardNo = "0000 0001";
            vm.CurrentPatient = patient;

            CommContracts.PatientCardManage patientCardManage = new CommContracts.PatientCardManage();
            patientCardManage.CurrentTime = DateTime.Now;
            patientCardManage.User = vm.CurrentUser;
            patientCardManage.Patient = patient;

            vm.PatientCardManage = patientCardManage;

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            // 办理普通卡
            VisualStateManager.GoToState(this, "VisualState", false);
            YBCombo.SelectedItem = null;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            // 办理临时卡
            VisualStateManager.GoToState(this, "VisualState1", false);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 保存
            var vm = this.DataContext as HISGUIPatientCardVM;
            var temp = vm.CurrentPatient;
            temp.Name += "";

            vm.PatientCardManage.CardNo = temp.PatientCardNo;
            vm.PatientCardManage.CardManageEnum = CommContracts.CardManageEnum.eNew;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // 取消
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string str = IDCardTextBox.Text.Trim();

            bool bIsIDCardOK = true;

            if (str.Length == 18)
            {
                bIsIDCardOK = IDCardHellper.CheckIDCard18(str);
            }
            else if (str.Length == 15)
            {
                bIsIDCardOK = IDCardHellper.CheckIDCard15(str);
            }
            else
            {
                bIsIDCardOK = false;
            }

        }

        private void MonthCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDayCombo();
        }

        private void YearCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDayCombo();
        }

        private void UpdateDayCombo()
        {
            var year = this.YearCombo.SelectedValue;
            var month = this.MonthCombo.SelectedValue;
            if (month!=null && year != null)
            {

                int nMonth = int.Parse(month.ToString().Substring(month.ToString().IndexOf(':') + 1, month.ToString().Length - month.ToString().IndexOf(':') - 1));
                int nYear = int.Parse(year.ToString().Substring(year.ToString().IndexOf(':') + 1, year.ToString().Length - year.ToString().IndexOf(':') - 1));


                DayCombo.Items.Clear();

                int nDayNum = 0;
                if (nMonth == 2)
                {
                    if ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0)
                    {
                        nDayNum = 29;
                    }
                    else
                    {
                        nDayNum = 28;
                    }

                }
                else if (nMonth == 1 || nMonth == 3 || nMonth == 5 || nMonth == 7 || nMonth == 8 || nMonth == 10 || nMonth == 12)
                {
                    nDayNum = 31;
                }
                else
                {
                    nDayNum = 30;
                }

                for (int i = 1; i <= nDayNum; i++)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = i;
                    DayCombo.Items.Add(item);
                }
            }
        }
    }
}
