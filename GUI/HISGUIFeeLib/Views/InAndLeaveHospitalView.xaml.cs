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
using HISGUIFeeLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("InAndLeaveHospitalView", typeof(InAndLeaveHospitalView))]
    public partial class InAndLeaveHospitalView : HISGUIViewBase
    {
        private CommContracts.Inpatient Inpatient;
        private bool IsEdit;
        public InAndLeaveHospitalView()
        {
            InitializeComponent();

            this.PayTypeEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.BaoXianEnum));
            this.GenderCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.GenderEnum));
            this.VolkEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.VolkEnum));
            this.MarriageEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.MarriageEnum));
            this.IllnesSstateEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.IllnesSstateEnum));

            this.PayTypeEnumCombo.SelectedItem = CommContracts.BaoXianEnum.自费;
            this.GenderCombo.SelectedItem = CommContracts.GenderEnum.男;
            this.VolkEnumCombo.SelectedItem = CommContracts.VolkEnum.汉族;


            NewInPatient();
            UpdateAllWait();

            this.Loaded += InpatientRegistrationView_Loaded;
        }

        private void UpdateAllWait()
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
            if (this.InManageCheck.IsChecked.Value)
                AllWaitList.ItemsSource = myd.GetAllInPatientList(CommContracts.InHospitalStatusEnum.未入院);
            else if (this.LeaveManageCheck.IsChecked.Value)
                AllWaitList.ItemsSource = myd.GetAllInPatientList(CommContracts.InHospitalStatusEnum.在院中);
            else if (this.RecallManageCheck.IsChecked.Value)
                AllWaitList.ItemsSource = myd.GetAllInPatientList(CommContracts.InHospitalStatusEnum.已出院);
        }
        private void NewInPatient()
        {
            Inpatient = new CommContracts.Inpatient();
            IsEdit = false;

            updateInDateToView();
        }

        private void NoInPatient()
        {
            Inpatient = null;
            IsEdit = false;

            updateInDateToView();
            updateLeaveDateToView();
        }

        private void InpatientRegistrationView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void InHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Inpatient == null)
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToInDate())
            {
                Inpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.在院中;
                if (IsEdit)
                {
                    bool? bResult = vm?.UpdateInPatient(Inpatient);
                    if (bResult.HasValue)
                    {
                        if (bResult.Value)
                        {
                            MessageBox.Show("修改成功！");
                            setInHospitalGridEnable(false);
                            return;
                        }
                    }
                    MessageBox.Show("修改失败！");
                }
                else
                {
                    bool? bResult = vm?.SaveInPatient(Inpatient);
                    if (bResult.HasValue)
                    {
                        if (bResult.Value)
                        {
                            MessageBox.Show("入院成功！");
                            NewInPatient();
                            UpdateAllWait();
                            return;
                        }
                    }
                    MessageBox.Show("入院失败！");
                }
            }
        }


        private void updateInDateToView()
        {
            if (Inpatient != null)
            {
                this.InHospitalNo.Text = Inpatient.No;
                this.CaseNo.Text = Inpatient.CaseNo;
                this.PayTypeEnumCombo.SelectedItem = Inpatient.BaoXianEnum;
                this.YiBaoNo.Text = Inpatient.YiBaoNo;
                if (Inpatient.Patient != null)
                {
                    this.Name.Text = Inpatient.Patient.Name;
                    this.GenderCombo.SelectedItem = Inpatient.Patient.Gender;
                    this.BirthDay.SelectedDate = Inpatient.Patient.BirthDay;
                    this.IDCardNo.Text = Inpatient.Patient.IDCardNo;
                    this.VolkEnumCombo.SelectedItem = Inpatient.Patient.Volk;
                    this.JiGuan.Text = Inpatient.Patient.JiGuan;
                    this.Tel.Text = Inpatient.Patient.Tel;
                }

                this.MarriageEnumCombo.SelectedItem = Inpatient.MarriageEnum;
                this.Job.Text = Inpatient.Job;
                this.WorkUnitAddress.Text = Inpatient.WorkAddress;
                this.ConnectsName.Text = Inpatient.ContactsName;
                this.ConnectsTel.Text = Inpatient.ContactsTel;
                this.ConnectsAddress.Text = Inpatient.ContactsAddress;
                this.InHospitalTime.SelectedDate = Inpatient.InHospitalTime;
                this.IllnesSstateEnumCombo.SelectedItem = Inpatient.IllnesSstateEnum;
                this.InHospitalDiagnosis.Text = Inpatient.InHospitalDiagnoses;
                this.InDepartmentEdit.Text = Inpatient.InHospitalDepartment;
                this.InDoctorEdit.Text = Inpatient.InHospitalDoctorName;
                this.InHospitalYaJin.Text = "_";

                this.InHospitalStatus.Text = Inpatient.InHospitalStatusEnum.ToString();
                if (Inpatient.InPatientUser != null)
                {
                    this.InUserName.Text = Inpatient.InPatientUser.Username;
                }

                this.InHospitalTime.DisplayDateEnd = DateTime.Now;
                this.BirthDay.DisplayDateEnd = DateTime.Now;
            }
            else
            {
                this.InHospitalNo.Text = "";
                this.CaseNo.Text = "";
                this.PayTypeEnumCombo.SelectedItem = "";
                this.YiBaoNo.Text = "";

                this.Name.Text = "";
                this.GenderCombo.SelectedItem = null;
                this.BirthDay.SelectedDate = null;
                this.IDCardNo.Text = "";
                this.VolkEnumCombo.SelectedItem = null;
                this.JiGuan.Text = "";
                this.Tel.Text = "";

                this.MarriageEnumCombo.SelectedItem = "";
                this.Job.Text = "";
                this.WorkUnitAddress.Text = "";
                this.ConnectsName.Text = "";
                this.ConnectsTel.Text = "";
                this.ConnectsAddress.Text = "";
                this.InHospitalTime.SelectedDate = null;
                this.IllnesSstateEnumCombo.SelectedItem = "";
                this.InHospitalDiagnosis.Text = "";
                this.InDepartmentEdit.Text = "";
                this.InDoctorEdit.Text = "";
                this.InHospitalYaJin.Text = "";
            }
        }

        private bool updateViewToInDate()
        {
            if (this.GenderCombo.SelectedItem == null)
                return false;

            if (Inpatient != null)
            {
                Inpatient.No = this.InHospitalNo.Text;
                Inpatient.CaseNo = this.CaseNo.Text;
                Inpatient.BaoXianEnum = (CommContracts.BaoXianEnum)this.PayTypeEnumCombo.SelectedItem;
                Inpatient.YiBaoNo = this.YiBaoNo.Text;

                CommContracts.Patient patient = new CommContracts.Patient();
                if (Inpatient.Patient != null)
                {
                    patient.ID = Inpatient.Patient.ID;
                }
                patient.Name = this.Name.Text;
                patient.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                if (this.BirthDay.SelectedDate.HasValue)
                    patient.BirthDay = this.BirthDay.SelectedDate.Value;
                patient.IDCardNo = this.IDCardNo.Text;
                patient.Volk = (CommContracts.VolkEnum)this.VolkEnumCombo.SelectedItem;
                patient.JiGuan = this.JiGuan.Text;
                patient.Tel = this.Tel.Text;

                Inpatient.Patient = patient;

                Inpatient.MarriageEnum = (CommContracts.MarriageEnum)this.MarriageEnumCombo.SelectedItem;
                Inpatient.Job = this.Job.Text;
                Inpatient.WorkAddress = this.WorkUnitAddress.Text;
                Inpatient.ContactsName = this.ConnectsName.Text;
                Inpatient.ContactsTel = this.ConnectsTel.Text;
                Inpatient.ContactsAddress = this.ConnectsAddress.Text;
                Inpatient.InHospitalTime = this.InHospitalTime.SelectedDate.Value;
                Inpatient.IllnesSstateEnum = (CommContracts.IllnesSstateEnum)this.IllnesSstateEnumCombo.SelectedItem;
                Inpatient.InHospitalDiagnoses = this.InHospitalDiagnosis.Text;
                Inpatient.InHospitalDepartment = this.InDepartmentEdit.Text;
                Inpatient.InHospitalDoctorName = this.InDoctorEdit.Text;
                //"_" = this.InHospitalYaJin.Text;

                Inpatient.InPatientUserID = 3;
            }

            return true;
        }

        private void updateLeaveDateToView()
        {
            if (Inpatient != null)
            {
                if (Inpatient.InHospitalTime != null)
                    this.LeaveHospitalTime.DisplayDateStart = Inpatient.InHospitalTime;
                this.LeaveHospitalTime.DisplayDateEnd = DateTime.Now;

                this.LeaveHospitalDepartment.Text = Inpatient.LeaveHospitalDepartment;
                this.LeaveHospitalDoctor.Text = Inpatient.LeaveHospitalDoctorName;
                this.LeaveHospitalDiagnosis.Text = Inpatient.LeaveHospitalDiagnoses;
                this.LeaveHospitalTime.SelectedDate = Inpatient.LeaveHospitalTime;
            }
            else
            {
                this.LeaveHospitalDepartment.Text = "";
                this.LeaveHospitalDoctor.Text = "";
                this.LeaveHospitalDiagnosis.Text = "";
                this.LeaveHospitalTime.SelectedDate = null;
            }
        }

        public bool updateViewToLeaveDate()
        {
            if (LeaveHospitalTime.SelectedDate == null)
                return false;
            if (string.IsNullOrEmpty(LeaveHospitalDoctor.Text.Trim()))
                return false;
            if (string.IsNullOrEmpty(LeaveHospitalDepartment.Text.Trim()))
                return false;
            if (Inpatient == null)
                return false;

            Inpatient.LeaveHospitalDepartment = this.LeaveHospitalDepartment.Text;
            Inpatient.LeaveHospitalDoctorName = this.LeaveHospitalDoctor.Text;
            Inpatient.LeaveHospitalDiagnoses = this.LeaveHospitalDiagnosis.Text;
            Inpatient.LeaveHospitalTime = this.LeaveHospitalTime.SelectedDate;

            return true;
        }

        // 入院办理
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            NewInPatient();

            LeaveHospitalGrid.Visibility = Visibility.Collapsed;
            Spe.Visibility = Visibility.Collapsed;
            setInHospitalGridEnable();
            UpdateAllWait();
        }

        // 出院办理
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            NoInPatient();

            LeaveHospitalGrid.Visibility = Visibility.Visible;
            Spe.Visibility = Visibility.Visible;
            setInHospitalGridEnable(false);
            LeaveHospitalBtn.Visibility = Visibility.Visible;
            RecallHospitalBtn.Visibility = Visibility.Collapsed;
            LeaveHospitalDiagnosisBtn.IsEnabled = true;
            LeaveHospitalDoctorBtn.IsEnabled = true;
            LeaveHospitalTime.IsEnabled = true;
            UpdateAllWait();

        }

        // 召回办理
        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            NoInPatient();

            LeaveHospitalGrid.Visibility = Visibility.Visible;
            Spe.Visibility = Visibility.Visible;
            setInHospitalGridEnable(false);
            LeaveHospitalBtn.Visibility = Visibility.Collapsed;
            RecallHospitalBtn.Visibility = Visibility.Visible;
            LeaveHospitalDiagnosisBtn.IsEnabled = false;
            LeaveHospitalDoctorBtn.IsEnabled = false;
            LeaveHospitalTime.IsEnabled = false;
            UpdateAllWait();
        }

        private void setInHospitalGridEnable(bool bEnable = true)
        {
            this.InHospitalNo.IsEnabled = false;
            this.CaseNo.IsEnabled = bEnable;
            this.PayTypeEnumCombo.IsEnabled = bEnable;
            this.YiBaoNo.IsEnabled = bEnable;

            this.Name.IsEnabled = bEnable;
            this.GenderCombo.IsEnabled = bEnable;
            this.BirthDay.IsEnabled = bEnable;
            this.IDCardNo.IsEnabled = bEnable;
            this.VolkEnumCombo.IsEnabled = bEnable;
            this.JiGuan.IsEnabled = bEnable;
            this.Tel.IsEnabled = bEnable;
            this.MarriageEnumCombo.IsEnabled = bEnable;
            this.Job.IsEnabled = bEnable;
            this.WorkUnitAddress.IsEnabled = bEnable;
            this.ConnectsName.IsEnabled = bEnable;
            this.ConnectsTel.IsEnabled = bEnable;
            this.ConnectsAddress.IsEnabled = bEnable;
            this.InHospitalTime.IsEnabled = bEnable;
            this.IllnesSstateEnumCombo.IsEnabled = bEnable;
            this.InHospitalDiagnosis.IsEnabled = bEnable;
            this.InDepartmentEdit.IsEnabled = false;
            this.InDoctorEdit.IsEnabled = false;
            this.InDoctorEditBtn.IsEnabled = bEnable;
            this.InHospitalYaJin.IsEnabled = bEnable;

            this.InUserName.IsEnabled = false;
            this.InHospitalDiagnosisBtn.IsEnabled = bEnable;

            if (bEnable)
            {
                this.InHospitalBtn.Visibility = Visibility.Visible;
                this.EditMsgBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.InHospitalBtn.Visibility = Visibility.Collapsed;
                if (RecallManageCheck.IsChecked.Value)
                {
                    this.EditMsgBtn.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.EditMsgBtn.Visibility = Visibility.Visible;
                }

            }
        }

        private void AllWaitList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllWaitList.SelectedItem as CommContracts.Inpatient;
            if (temp == null)
                return;

            Inpatient = temp;

            updateInDateToView();
            updateLeaveDateToView();
        }

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            // 读卡
            var vm = this.DataContext as HISGUIFeeVM;
            if (InManageCheck.IsChecked.Value)
            {
                Inpatient = vm?.ReadNewInPatient(7);
            }
            else if (LeaveManageCheck.IsChecked.Value)
            {
                Inpatient = vm?.ReadCurrentInPatient(9);
            }
            else if (RecallManageCheck.IsChecked.Value)
            {
                Inpatient = vm?.ReadLeavedPatient(9);
            }

            updateInDateToView();
            updateLeaveDateToView();
        }

        private void EditMsgBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Inpatient == null)
                return;
            setInHospitalGridEnable();
            IsEdit = true;
        }

        private void InDoctorEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var tempDoctor = getDoctor();
            if (tempDoctor != null)
            {
                this.InDoctorEdit.Text = tempDoctor.Name;
                this.InDepartmentEdit.Text = tempDoctor.Department.Name;
            }
        }

        private void LeaveHospitalDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Inpatient == null)
                return;

            var tempDoctor = getDoctor();
            if (tempDoctor != null)
            {
                this.LeaveHospitalDoctor.Text = tempDoctor.Name;
                this.LeaveHospitalDepartment.Text = tempDoctor.Department.Name;
            }
        }

        private CommContracts.Employee getDoctor()
        {
            var window = new Window();
            DoctorFind tempview = new DoctorFind();
            window.Content = tempview;
            window.Width = 400;
            window.Height = 300;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();
            if (bResult.Value)
            {
                return tempview.SelectDoctor;
            }
            return null;
        }

        private void LeaveHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Inpatient == null)
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToLeaveDate())
            {
                Inpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.已出院;

                bool? bResult = vm?.UpdateInPatient(Inpatient);
                if (bResult.HasValue)
                {
                    if (bResult.Value)
                    {
                        MessageBox.Show("出院成功！");
                        setInHospitalGridEnable(false);
                        UpdateAllWait();
                        return;
                    }
                }
                MessageBox.Show("出院失败！");
            }
        }

        private void RecallHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Inpatient == null)
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToLeaveDate())
            {
                Inpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.在院中;
                Inpatient.LeaveHospitalTime = null;

                bool? bResult = vm?.UpdateInPatient(Inpatient);
                if (bResult.HasValue)
                {
                    if (bResult.Value)
                    {
                        MessageBox.Show("召回成功！");
                        setInHospitalGridEnable(false);
                        UpdateAllWait();
                        return;
                    }
                }
                MessageBox.Show("召回失败！");
            }
        }

    }
}
