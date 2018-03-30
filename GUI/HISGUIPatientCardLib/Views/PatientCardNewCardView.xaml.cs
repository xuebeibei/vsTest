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
    [Export("PatientCardNewCardView", typeof(PatientCardNewCardView))]
    public partial class PatientCardNewCardView : HISGUIViewBase
    {
        private bool bIsEdit = false;
        /// <summary>
        /// 构造函数
        /// </summary>
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

        /// <summary>
        /// 加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatientCardMsgView_Loaded(object sender, RoutedEventArgs e)
        {
            InitCombo();
            newPatientCard();
        }

        /// <summary>
        /// 新建卡
        /// </summary>
        private void newPatientCard()
        {
            CommClient.Patient patientClient = new CommClient.Patient();

            CommContracts.Patient tempPatient = new CommContracts.Patient();
            tempPatient.PID = patientClient.getNewPID();
            tempPatient.PatientCardNo = patientClient.getNewPatientCardNum();

            var vm = this.DataContext as HISGUIPatientCardVM;
            vm.CurrentPatient = tempPatient;


            this.PatientMsgGrid.IsEnabled = true;
            this.bIsEdit = false;
            this.EditBtn.IsEnabled = false;
            this.LostBtn.IsEnabled = false;
            this.ReNewBtn.IsEnabled = false;

            this.txt_Name.Focus();
            this.ManageCardRecordsList.SelectedItems.Clear();
            this.ManageCardRecordsList.ItemsSource = null;
        }

        private bool LostPatientCard()
        {
            return false;
        }

        private List<CommContracts.PatientCardManage> GetAllPatientCardRecords(string strName)
        {
            CommClient.PatientCardManage manage = new CommClient.PatientCardManage();
            return manage.GetAllPatientCardManage(strName);
        }

        /// <summary>
        /// 初始化界面上所有combobox的值和默认选项
        /// </summary>
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

            this.PatientCardStatusCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PatientCardStatusEnum));
            this.PatientCardStatusCombo.SelectedIndex = 0;
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //updateYbType();
        }

        private void updateYbType()
        {
            if (YBCombo.SelectedItem == null)
            {
                // VisualStateManager.GoToState(this, "VisualState2", false);
                return;
            }

            var current = (CommContracts.FeeTypeEnum)YBCombo.SelectedItem;

            if (current == CommContracts.FeeTypeEnum.自费)
            {
                // VisualStateManager.GoToState(this, "VisualState2", false);
            }
            else if (current == CommContracts.FeeTypeEnum.城镇职工 || current == CommContracts.FeeTypeEnum.城乡居民)
            {
                // VisualStateManager.GoToState(this, "VisualState3", false);
            }
        }

        /// <summary>
        /// 根据证件填写信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZJBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.ZJCombo.SelectedItem == null)
            {
                return;
            }

            if ((CommContracts.ZhengJianEnum)this.ZJCombo.SelectedItem == CommContracts.ZhengJianEnum.身份证)
            {
                GetDateFromIDCard(ZJNumBox.Text.Trim());
            }
        }

        private void GetDateFromIDCard(string strIDCardNum)
        {
            bool bIsIDCardOK = IDCardHellper.IsIDCardNumOk(strIDCardNum);

            if (bIsIDCardOK)
            {
                int year = 0, month = 0, day = 0, sex = 0;
                IDCardHellper.GetBirthAndSexFromIDCard(strIDCardNum, ref year, ref month, ref day, ref sex);

                this.myBirthControl.SetValue(year, month, day);

                if (sex % 2 == 0)
                {
                    this.GenderCombo.SelectedItem = CommContracts.GenderEnum.女;
                }
                else
                {
                    this.GenderCombo.SelectedItem = CommContracts.GenderEnum.男;
                }
                this.AgeBox.Text = IDCardHellper.GetAge(year, month, day);
            }
        }

        /// <summary>
        /// 保存前对数据的检查
        /// </summary>
        /// <returns></returns>
        private bool check(ref string Error)
        {
            Error = "";
            var vm = this.DataContext as HISGUIPatientCardVM;

            bool bIsOK = true;
            if (string.IsNullOrEmpty(vm.CurrentPatient.Name))
            {
                Error = "姓名不能为空";
                bIsOK = false;
            }

            if (string.IsNullOrEmpty(vm.CurrentPatient.ZhengJianNum))
            {
                Error = "证件号不能为空";
                bIsOK = false;
            }
            else if ((CommContracts.ZhengJianEnum)ZJCombo.SelectedItem == CommContracts.ZhengJianEnum.身份证 &&
                !IDCardHellper.IsIDCardNumOk(vm.CurrentPatient.ZhengJianNum))
            {
                Error = "证件号不正确";
                bIsOK = false;
            }

            return bIsOK;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;
            vm.CurrentPatient.BirthDay = this.myBirthControl.GetValue();

            string strMsg = "";
            if (!check(ref strMsg))
            {
                MessageBox.Show(strMsg);
                return;
            }

            if (bIsEdit)
            {
                if (vm.UpdatePatientMsg(vm.CurrentPatient, ref strMsg))
                {
                    MessageBox.Show("修改患者信息完成！");
                    newPatientCard();
                }
                else
                {
                    MessageBox.Show(strMsg);
                }
            }
            else
            {
                CommContracts.PatientCardManage manage = new CommContracts.PatientCardManage();
                manage.Patient = vm.CurrentPatient;
                manage.CardNo = vm.CurrentPatient.PatientCardNo;
                manage.CardManageEnum = CommContracts.CardManageEnum.新建卡;
                manage.UserID = vm.CurrentUser.ID;

                if (vm.SavePatientCardManage(manage, ref strMsg))
                {
                    MessageBox.Show("新建卡完成！");
                    newPatientCard();
                }
                else
                {
                    MessageBox.Show(strMsg);
                }
            }
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            String PM = Interaction.InputBox("请输入带查找姓名", "查找", "", 100, 100);

            if (string.IsNullOrEmpty(PM))
                return;

            List<CommContracts.PatientCardManage> list = GetAllPatientCardRecords(PM);
            this.ManageCardRecordsList.ItemsSource = list;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newPatientCard();
        }

        private void LostBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            CommContracts.PatientCardManage manage = new CommContracts.PatientCardManage();
            
            vm.CurrentPatient.PatientCardStatus = CommContracts.PatientCardStatusEnum.挂失;
            manage.Patient = vm.CurrentPatient;
            manage.PatientID = vm.CurrentPatient.ID;
            manage.CardNo = vm.CurrentPatient.PatientCardNo;
            manage.CardManageEnum = CommContracts.CardManageEnum.挂失卡;
            manage.UserID = vm.CurrentUser.ID;

            string strMsg = "";
            if (vm.SavePatientCardManage(manage, ref strMsg))
            {
                MessageBox.Show("挂失卡完成！");
                newPatientCard();
            }
            else
            {
                MessageBox.Show(strMsg);
            }
        }

        private void ReNewBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            CommClient.Patient client = new CommClient.Patient();
            vm.CurrentPatient.PatientCardNo = client.getNewPatientCardNum();
            vm.CurrentPatient.PatientCardStatus = CommContracts.PatientCardStatusEnum.补办;

            CommContracts.PatientCardManage manage = new CommContracts.PatientCardManage();
            manage.Patient = vm.CurrentPatient;
            manage.PatientID = vm.CurrentPatient.ID;
            manage.CardNo = vm.CurrentPatient.PatientCardNo;
            manage.CardManageEnum = CommContracts.CardManageEnum.补办卡;
            manage.UserID = vm.CurrentUser.ID;

            string strMsg = "";
            if (vm.SavePatientCardManage(manage, ref strMsg))
            {
                MessageBox.Show("补办卡完成！");
                newPatientCard();
            }
            else
            {
                MessageBox.Show(strMsg);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientMsgGrid.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            bIsEdit = true;
        }

        private void ManageCardRecordsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = this.ManageCardRecordsList.SelectedItem;
            if (currentItem == null)
                return;

            CommContracts.PatientCardManage manage = currentItem as CommContracts.PatientCardManage;

            var vm = this.DataContext as HISGUIPatientCardVM;

            vm.CurrentPatient = manage.Patient;
            if (manage.Patient.ZhengJianEnum == CommContracts.ZhengJianEnum.身份证)
            {
                GetDateFromIDCard(manage.Patient.ZhengJianNum);
            }

            if(manage.Patient.PatientCardStatus == CommContracts.PatientCardStatusEnum.挂失)
            {
                this.EditBtn.IsEnabled = false;
                this.LostBtn.IsEnabled = false;
            }
            else
            {
                this.LostBtn.IsEnabled = true;
                this.EditBtn.IsEnabled = true;
            }

            PatientMsgGrid.IsEnabled = false;
            this.ReNewBtn.IsEnabled = true;
            this.SaveBtn.IsEnabled = false;
        }
    }
}
