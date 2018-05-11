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
using Microsoft.VisualBasic;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("InAndLeaveHospitalView", typeof(InAndLeaveHospitalView))]
    public partial class InAndLeaveHospitalView : HISGUIViewBase
    {
        private CommContracts.InHospital MyCurrentInpatient { get; set; }
        private CommContracts.InHospitalApply MyCurrentInHospitalApply { get; set; }

        private CommContracts.LeaveHospital MyCurrentLeaveHospital { get; set; }

        private CommContracts.RecallHospital MyCurrentRecallHospital { get; set; }
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
            
            if (this.InManageCheck.IsChecked.Value)
            {
                this.AllWaitList.View = this.Resources["inApplyColumn"] as GridView;
                CommClient.InHospitalApply mydApply = new CommClient.InHospitalApply();
                AllWaitList.ItemsSource = mydApply.GetAllInHospitalApply(CommContracts.InHospitalApplyEnum.未处理);
            }
            else if (this.LeaveManageCheck.IsChecked.Value)
            {
                CommClient.InHospital myd = new CommClient.InHospital();
                this.AllWaitList.View = this.Resources["inHospitalColumn"] as GridView;
                AllWaitList.ItemsSource = myd.GetAllInHospitalList();
            }
            else if (this.RecallManageCheck.IsChecked.Value)
            {
                CommClient.LeaveHospital myd = new CommClient.LeaveHospital();
                this.AllWaitList.View = this.Resources["leaveHospitalColumn"] as GridView;
                AllWaitList.ItemsSource = myd.GetAllLeaveHospitalList();
            }

        }
        private void NewInPatient()
        {
            MyCurrentInpatient = new CommContracts.InHospital();
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
                    bool? bResult = vm?.UpdateInHospital(MyCurrentInpatient);
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
                    bool? bResult = vm?.SaveInHospital(MyCurrentInpatient, MyCurrentInHospitalApply);
                    if (bResult.HasValue && bResult.Value)
                    {
                        MessageBox.Show("入院成功！");
                        NewInPatient();
                        UpdateAllWait();
                        return;
                    }
                    MessageBox.Show("入院失败！");
                }
            }
        }


        private void updateInDateToView()
        {
            if (MyCurrentInpatient != null)
            {
                this.InHospitalNo.Text = MyCurrentInpatient.NO;
                this.CaseNo.Text = "";
                //this.PayTypeEnumCombo.SelectedItem = MyCurrentInpatient.BaoXianEnum;
                //this.YiBaoNo.Text = MyCurrentInpatient.YiBaoNo;
                if (MyCurrentInpatient.Patient != null)
                {
                    this.Name.Text = MyCurrentInpatient.Patient.Name;
                    this.GenderCombo.SelectedItem = MyCurrentInpatient.Patient.Gender;
                    this.BirthDay.SelectedDate = MyCurrentInpatient.Patient.BirthDay;
                    this.IDCardNo.Text = MyCurrentInpatient.Patient.ZhengJianNum;
                    this.VolkEnumCombo.SelectedItem = MyCurrentInpatient.Patient.Volk;
                    this.JiGuan.Text = MyCurrentInpatient.Patient.JiGuan_Sheng;
                    this.Tel.Text = MyCurrentInpatient.Patient.Tel;
                }

                //this.MarriageEnumCombo.SelectedItem = MyCurrentInpatient.MarriageEnum;
                //this.Job.Text = MyCurrentInpatient.Job;
                //this.WorkUnitAddress.Text = MyCurrentInpatient.WorkAddress;
                //this.ConnectsName.Text = MyCurrentInpatient.ContactsName;
                //this.ConnectsTel.Text = MyCurrentInpatient.ContactsTel;
                //this.ConnectsAddress.Text = MyCurrentInpatient.ContactsAddress;
                this.InHospitalTime.SelectedDate = MyCurrentInpatient.InTime;
                //this.IllnesSstateEnumCombo.SelectedItem = MyCurrentInpatient.IllnesSstateEnum;
                this.InHospitalDiagnosis.Text = MyCurrentInpatient.Diagnosis;

                if (MyCurrentInpatient.InHospitalPatientDoctors != null && MyCurrentInpatient.InHospitalPatientDoctors.Count() > 0)
                {
                    CommClient.Employee employeeClient = new CommClient.Employee();
                    this.InDepartmentEdit.Text = employeeClient.GetCurrentDepartment(MyCurrentInpatient.InHospitalPatientDoctors.ElementAt(0).Doctor.ID).Name;

                    this.InDoctorEdit.Text = MyCurrentInpatient.InHospitalPatientDoctors.ElementAt(0).Doctor.Name;
                }

                this.InHospitalYaJin.Text = "_";

                this.InHospitalStatus.Text = MyCurrentInpatient.InHospitalStatusEnum.ToString();
                if (MyCurrentInpatient.User != null)
                {
                    this.InUserName.Text = MyCurrentInpatient.User.LoginName;
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

            var vm = this.DataContext as HISGUIFeeVM;

            if (MyCurrentInpatient != null)
            {
                MyCurrentInpatient.NO = this.InHospitalNo.Text;
                //MyCurrentInpatient.CaseNo = this.CaseNo.Text;
                //MyCurrentInpatient.BaoXianEnum = (CommContracts.BaoXianEnum)this.PayTypeEnumCombo.SelectedItem;
                //MyCurrentInpatient.YiBaoNo = this.YiBaoNo.Text;

                CommContracts.Patient patient = new CommContracts.Patient();
                if (MyCurrentInpatient.Patient != null)
                {
                    patient.ID = MyCurrentInpatient.Patient.ID;
                }
                patient.Name = this.Name.Text;
                patient.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                if (this.BirthDay.SelectedDate.HasValue)
                    patient.BirthDay = this.BirthDay.SelectedDate.Value;
                patient.ZhengJianNum = this.IDCardNo.Text;
                patient.Volk = (CommContracts.VolkEnum)this.VolkEnumCombo.SelectedItem;
                patient.JiGuan_Sheng = this.JiGuan.Text;
                patient.Tel = this.Tel.Text;

                MyCurrentInpatient.Patient = patient;

                //MyCurrentInpatient.MarriageEnum = (CommContracts.MarriageEnum)this.MarriageEnumCombo.SelectedItem;
                //MyCurrentInpatient.Job = this.Job.Text;
                //MyCurrentInpatient.WorkAddress = this.WorkUnitAddress.Text;
                //MyCurrentInpatient.ContactsName = this.ConnectsName.Text;
                //MyCurrentInpatient.ContactsTel = this.ConnectsTel.Text;
                //MyCurrentInpatient.ContactsAddress = this.ConnectsAddress.Text;
                MyCurrentInpatient.InTime = this.InHospitalTime.SelectedDate.Value;
                //MyCurrentInpatient.IllnesSstateEnum = (CommContracts.IllnesSstateEnum)this.IllnesSstateEnumCombo.SelectedItem;
                MyCurrentInpatient.Diagnosis = this.InHospitalDiagnosis.Text;
                //MyCurrentInpatient.InHospitalDepartment = this.InDepartmentEdit.Text;
                //MyCurrentInpatient.InHospitalDoctorName = this.InDoctorEdit.Text;
                //"_" = this.InHospitalYaJin.Text;

                MyCurrentInpatient.UserID = vm.CurrentUser.ID;

            }

            return true;
        }

        private void updateLeaveDateToView()
        {

            this.LeaveHospitalDepartment.Text = "";
            this.LeaveHospitalDoctor.Text = "";
            this.LeaveHospitalDiagnosis.Text = "";
            this.LeaveHospitalTime.SelectedDate = null;
            this.LeaveHospitalTime.DisplayDateEnd = DateTime.Now;


            if (MyCurrentInpatient != null)
            {
                if (MyCurrentInpatient.InTime != null)
                    this.LeaveHospitalTime.DisplayDateStart = MyCurrentInpatient.InTime;
                if (MyCurrentInpatient.InHospitalPatientDoctors != null && MyCurrentInpatient.InHospitalPatientDoctors.Count() > 0)
                {
                    CommClient.Employee employeeClient = new CommClient.Employee();
                    this.LeaveHospitalDepartment.Text = employeeClient.GetCurrentDepartment(MyCurrentInpatient.InHospitalPatientDoctors.Last().Doctor.ID).Name;

                    this.LeaveHospitalDoctor.Text = MyCurrentInpatient.InHospitalPatientDoctors.Last().Doctor.Name;
                }
            }

            if (MyCurrentLeaveHospital != null)
            {
                this.LeaveHospitalDiagnosis.Text = MyCurrentLeaveHospital.Diagnosis;
                this.LeaveHospitalTime.SelectedDate = MyCurrentLeaveHospital.LeaveTime;
            }
        }

        private bool updateViewToLeaveDate()
        {
            if (MyCurrentInpatient == null)
                return false;
            if(MyCurrentLeaveHospital == null)
            {
                MyCurrentLeaveHospital = new CommContracts.LeaveHospital();
            }

            var vm = this.DataContext as HISGUIFeeVM;

            MyCurrentLeaveHospital.InHospitalID = MyCurrentInpatient.ID;
            MyCurrentLeaveHospital.LeaveTime = DateTime.Now;
            MyCurrentLeaveHospital.UserID = vm.CurrentUser.ID;
            return true;
        }

        private bool updateViewToRecallDate()
        {
            if (MyCurrentLeaveHospital == null)
                return false;
            if (MyCurrentRecallHospital == null)
            {
                MyCurrentRecallHospital = new CommContracts.RecallHospital();
            }

            var vm = this.DataContext as HISGUIFeeVM;

            MyCurrentRecallHospital.LeaveHospitalID = MyCurrentLeaveHospital.ID;
            MyCurrentRecallHospital.RecallTime = DateTime.Now;
            MyCurrentRecallHospital.UserID = vm.CurrentUser.ID;
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
            //var vm = this.DataContext as HISGUIFeeVM;
            //if (InManageCheck.IsChecked.Value)
            //{
            //    MyCurrentInpatient = vm?.ReadNewInHospital(7);
            //}
            //else if (LeaveManageCheck.IsChecked.Value)
            //{
            //    MyCurrentInpatient = vm?.ReadCurrentInHospital(9);
            //}
            //else if (RecallManageCheck.IsChecked.Value)
            //{
            //    MyCurrentInpatient = vm?.ReadLeavedPatient(9);
            //}

            //updateInDateToView();
            //updateLeaveDateToView();
            String strPatientCardNum = Interaction.InputBox("请输入就诊卡卡号", "读卡", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;

            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Patient tempPatient = new CommContracts.Patient();

            CommClient.Patient patientClient = new CommClient.Patient();

            string ErrorMsg = "";
            tempPatient = patientClient.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);
            vm.CurrentPatient = tempPatient;

            CommClient.InHospital registrationClient = new CommClient.InHospital();
            List<CommContracts.InHospital> InHospitalList = registrationClient.GetAllInHospitalList(0, vm.CurrentPatient.Name);
            if (InHospitalList == null || InHospitalList.Count() <= 0)
                return;

            MyCurrentInpatient = InHospitalList.ElementAt(0);


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

                CommClient.Employee employeeClient = new CommClient.Employee();
                this.InDepartmentEdit.Text = employeeClient.GetCurrentDepartment(tempDoctor.ID).Name;
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
                CommClient.Employee employeeClient = new CommClient.Employee();
                this.LeaveHospitalDepartment.Text = employeeClient.GetCurrentDepartment(tempDoctor.ID).Name;
            }
        }

        private CommContracts.Employee getDoctor()
        {
            var window = new Window();
            DoctorFind tempview = new DoctorFind();
            window.Content = tempview;
            window.Width = 400;
            window.Height = 300;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();
            if (bResult.Value)
            {
                return tempview.SelectDoctor;
            }
            return null;
        }

        private void LeaveHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MyCurrentLeaveHospital == null)
            {
                MyCurrentLeaveHospital = new CommContracts.LeaveHospital();
            }

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToLeaveDate())
            {
                bool? bResult = vm?.SaveLeaveHospital(MyCurrentLeaveHospital);
                if (bResult.HasValue && bResult.Value)
                {
                    MyCurrentInpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.已出院;
                    bResult = vm?.UpdateInHospital(MyCurrentInpatient);
                    if (bResult.HasValue && bResult.Value)
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
            if (MyCurrentRecallHospital == null)
            {
                MyCurrentRecallHospital = new CommContracts.RecallHospital();
            }

            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToRecallDate())
            {
                bool? bResult = vm?.SaveRecallHospital(MyCurrentRecallHospital);
                if (bResult.HasValue)
                {
                    MyCurrentInpatient.InHospitalStatusEnum = CommContracts.InHospitalStatusEnum.在院中;

                    bResult = vm?.UpdateInHospital(MyCurrentInpatient);
                    if (bResult.HasValue && bResult.Value)
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
            var vm = this.DataContext as HISGUIFeeVM;

            if (this.InManageCheck.IsChecked.Value)
            {
                var tempApply = this.AllWaitList.SelectedItem as CommContracts.InHospitalApply;
                if (tempApply == null)
                    return;

                MyCurrentInpatient.PatientID = tempApply.PatientID;
                MyCurrentInpatient.Patient = tempApply.Patient;
                MyCurrentInpatient.InTime = DateTime.Now;

                MyCurrentInHospitalApply = tempApply;

                CommContracts.InHospitalPatientDoctor inHospitalPatientDoctor = new CommContracts.InHospitalPatientDoctor();
                inHospitalPatientDoctor.StartTime = DateTime.Now;
                inHospitalPatientDoctor.DoctorID = tempApply.User.ID;
                inHospitalPatientDoctor.Doctor = tempApply.User;
                inHospitalPatientDoctor.UserID = vm.CurrentUser.ID;

                MyCurrentInpatient.InHospitalPatientDoctors.Add(inHospitalPatientDoctor);

            }
            else if (this.LeaveManageCheck.IsChecked.Value)
            {
                var temp = this.AllWaitList.SelectedItem as CommContracts.InHospital;
                if (temp == null)
                    return;

                MyCurrentInpatient = temp;

                updateLeaveDateToView();
            }
            else
            {
                var temp = this.AllWaitList.SelectedItem as CommContracts.LeaveHospital;
                if (temp == null)
                    return;
                MyCurrentInpatient = temp.InHospital;
                MyCurrentLeaveHospital = temp;

                updateLeaveDateToView();
            }

            updateInDateToView();
        }
    }
}
