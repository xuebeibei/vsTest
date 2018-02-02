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
        private CommContracts.Inpatient MyCurrentInpatient;
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
            {
                CommClient.InHospitalApply mydApply = new CommClient.InHospitalApply();               
                AllWaitList.ItemsSource = mydApply.GetAllInHospitalApply();
            }
                
            else if (this.LeaveManageCheck.IsChecked.Value)
                AllWaitList.ItemsSource = myd.GetAllInPatientList(CommContracts.InHospitalStatusEnum.在院中);
            else if (this.RecallManageCheck.IsChecked.Value)
                AllWaitList.ItemsSource = myd.GetAllInPatientList(CommContracts.InHospitalStatusEnum.已出院);
        }
        private void NewInPatient()
        {
            MyCurrentInpatient = new CommContracts.Inpatient();
            IsEdit = false;

            updateInDateToView();
        }

        private void NoInPatient()
        {
            MyCurrentInpatient = null;
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
            if (MyCurrentInpatient == null)
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToInDate())
            {
                MyCurrentInpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.在院中;
                if (IsEdit)
                {
                    bool? bResult = vm?.UpdateInPatient(MyCurrentInpatient);
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
                    bool? bResult = vm?.SaveInPatient(MyCurrentInpatient);
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
            if (MyCurrentInpatient != null)
            {
                this.InHospitalNo.Text = MyCurrentInpatient.No;
                this.CaseNo.Text = MyCurrentInpatient.CaseNo;
                this.PayTypeEnumCombo.SelectedItem = MyCurrentInpatient.BaoXianEnum;
                this.YiBaoNo.Text = MyCurrentInpatient.YiBaoNo;
                if (MyCurrentInpatient.Patient != null)
                {
                    this.Name.Text = MyCurrentInpatient.Patient.Name;
                    this.GenderCombo.SelectedItem = MyCurrentInpatient.Patient.Gender;
                    this.BirthDay.SelectedDate = MyCurrentInpatient.Patient.BirthDay;
                    this.IDCardNo.Text = MyCurrentInpatient.Patient.IDCardNo;
                    this.VolkEnumCombo.SelectedItem = MyCurrentInpatient.Patient.Volk;
                    this.JiGuan.Text = MyCurrentInpatient.Patient.JiGuan;
                    this.Tel.Text = MyCurrentInpatient.Patient.Tel;
                }

                this.MarriageEnumCombo.SelectedItem = MyCurrentInpatient.MarriageEnum;
                this.Job.Text = MyCurrentInpatient.Job;
                this.WorkUnitAddress.Text = MyCurrentInpatient.WorkAddress;
                this.ConnectsName.Text = MyCurrentInpatient.ContactsName;
                this.ConnectsTel.Text = MyCurrentInpatient.ContactsTel;
                this.ConnectsAddress.Text = MyCurrentInpatient.ContactsAddress;
                this.InHospitalTime.SelectedDate = MyCurrentInpatient.InHospitalTime;
                this.IllnesSstateEnumCombo.SelectedItem = MyCurrentInpatient.IllnesSstateEnum;
                this.InHospitalDiagnosis.Text = MyCurrentInpatient.InHospitalDiagnoses;
                this.InDepartmentEdit.Text = MyCurrentInpatient.InHospitalDepartment;
                this.InDoctorEdit.Text = MyCurrentInpatient.InHospitalDoctorName;
                this.InHospitalYaJin.Text = "_";

                this.InHospitalStatus.Text = MyCurrentInpatient.InHospitalStatusEnum.ToString();
                if (MyCurrentInpatient.InPatientUser != null)
                {
                    this.InUserName.Text = MyCurrentInpatient.InPatientUser.Username;
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

            if (MyCurrentInpatient != null)
            {
                MyCurrentInpatient.No = this.InHospitalNo.Text;
                MyCurrentInpatient.CaseNo = this.CaseNo.Text;
                MyCurrentInpatient.BaoXianEnum = (CommContracts.BaoXianEnum)this.PayTypeEnumCombo.SelectedItem;
                MyCurrentInpatient.YiBaoNo = this.YiBaoNo.Text;

                CommContracts.Patient patient = new CommContracts.Patient();
                if (MyCurrentInpatient.Patient != null)
                {
                    patient.ID = MyCurrentInpatient.Patient.ID;
                }
                patient.Name = this.Name.Text;
                patient.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                if (this.BirthDay.SelectedDate.HasValue)
                    patient.BirthDay = this.BirthDay.SelectedDate.Value;
                patient.IDCardNo = this.IDCardNo.Text;
                patient.Volk = (CommContracts.VolkEnum)this.VolkEnumCombo.SelectedItem;
                patient.JiGuan = this.JiGuan.Text;
                patient.Tel = this.Tel.Text;

                MyCurrentInpatient.Patient = patient;

                MyCurrentInpatient.MarriageEnum = (CommContracts.MarriageEnum)this.MarriageEnumCombo.SelectedItem;
                MyCurrentInpatient.Job = this.Job.Text;
                MyCurrentInpatient.WorkAddress = this.WorkUnitAddress.Text;
                MyCurrentInpatient.ContactsName = this.ConnectsName.Text;
                MyCurrentInpatient.ContactsTel = this.ConnectsTel.Text;
                MyCurrentInpatient.ContactsAddress = this.ConnectsAddress.Text;
                MyCurrentInpatient.InHospitalTime = this.InHospitalTime.SelectedDate.Value;
                MyCurrentInpatient.IllnesSstateEnum = (CommContracts.IllnesSstateEnum)this.IllnesSstateEnumCombo.SelectedItem;
                MyCurrentInpatient.InHospitalDiagnoses = this.InHospitalDiagnosis.Text;
                MyCurrentInpatient.InHospitalDepartment = this.InDepartmentEdit.Text;
                MyCurrentInpatient.InHospitalDoctorName = this.InDoctorEdit.Text;
                //"_" = this.InHospitalYaJin.Text;

                MyCurrentInpatient.InPatientUserID = 3;
            }

            return true;
        }

        private void updateLeaveDateToView()
        {
            if (MyCurrentInpatient != null)
            {
                if (MyCurrentInpatient.InHospitalTime != null)
                    this.LeaveHospitalTime.DisplayDateStart = MyCurrentInpatient.InHospitalTime;
                this.LeaveHospitalTime.DisplayDateEnd = DateTime.Now;

                this.LeaveHospitalDepartment.Text = MyCurrentInpatient.LeaveHospitalDepartment;
                this.LeaveHospitalDoctor.Text = MyCurrentInpatient.LeaveHospitalDoctorName;
                this.LeaveHospitalDiagnosis.Text = MyCurrentInpatient.LeaveHospitalDiagnoses;
                this.LeaveHospitalTime.SelectedDate = MyCurrentInpatient.LeaveHospitalTime;
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
            if (MyCurrentInpatient == null)
                return false;

            MyCurrentInpatient.LeaveHospitalDepartment = this.LeaveHospitalDepartment.Text;
            MyCurrentInpatient.LeaveHospitalDoctorName = this.LeaveHospitalDoctor.Text;
            MyCurrentInpatient.LeaveHospitalDiagnoses = this.LeaveHospitalDiagnosis.Text;
            MyCurrentInpatient.LeaveHospitalTime = this.LeaveHospitalTime.SelectedDate;

            return true;
        }

        // 入院办理
        private void InManageCheck_Click(object sender, RoutedEventArgs e)
        {
            NewInPatient();

            LeaveHospitalGrid.Visibility = Visibility.Collapsed;
            Spe.Visibility = Visibility.Collapsed;
            setInHospitalGridEnable();
            UpdateAllWait();
        }

        // 出院办理
        private void LeaveManageCheck_Click(object sender, RoutedEventArgs e)
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
        private void RecallManageCheck_Click(object sender, RoutedEventArgs e)
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

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            // 读卡
            var vm = this.DataContext as HISGUIFeeVM;
            if (InManageCheck.IsChecked.Value)
            {
                MyCurrentInpatient = vm?.ReadNewInPatient(7);
            }
            else if (LeaveManageCheck.IsChecked.Value)
            {
                MyCurrentInpatient = vm?.ReadCurrentInPatient(9);
            }
            else if (RecallManageCheck.IsChecked.Value)
            {
                MyCurrentInpatient = vm?.ReadLeavedPatient(9);
            }

            updateInDateToView();
            updateLeaveDateToView();
        }

        private void EditMsgBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MyCurrentInpatient == null)
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
            if (MyCurrentInpatient == null)
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
            if (MyCurrentInpatient == null)
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToLeaveDate())
            {
                MyCurrentInpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.已出院;

                bool? bResult = vm?.UpdateInPatient(MyCurrentInpatient);
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
            if (MyCurrentInpatient == null)
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToLeaveDate())
            {
                MyCurrentInpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.在院中;
                MyCurrentInpatient.LeaveHospitalTime = null;

                bool? bResult = vm?.UpdateInPatient(MyCurrentInpatient);
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

        private void AllWaitList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(this.InManageCheck.IsChecked.Value)
            {
                var tempApply = this.AllWaitList.SelectedItem as CommContracts.InHospitalApply;
                if (tempApply == null)
                    return;
                
                MyCurrentInpatient.PatientID = tempApply.PatientID;
                MyCurrentInpatient.Patient = tempApply.Patient;
                MyCurrentInpatient.InHospitalTime = DateTime.Now;
            }
            else
            {
                var temp = this.AllWaitList.SelectedItem as CommContracts.Inpatient;
                if (temp == null)
                    return;

                MyCurrentInpatient = temp;

                updateLeaveDateToView();
            }

            updateInDateToView();
        }
    }
}
