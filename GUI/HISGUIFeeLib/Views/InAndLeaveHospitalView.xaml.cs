﻿using System;
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
        public InAndLeaveHospitalView()
        {
            InitializeComponent();
            this.PayTypeEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PayTypeEnum));
            this.GenderCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.GenderEnum));
            this.VolkEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.VolkEnum));
            this.MarriageEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.MarriageEnum));
            this.IllnesSstateEnumCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.IllnesSstateEnum));

            Inpatient = new CommContracts.Inpatient();

            updateDateToView();


            this.Loaded += InpatientRegistrationView_Loaded;
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
            var vm = this.DataContext as HISGUIFeeVM;
            if (updateViewToDate())
            {
                vm.CurrentInpatient = Inpatient;
                bool? bResult = vm?.SaveInPatient();
                if (bResult.HasValue)
                {
                    if (bResult.Value)
                    {
                        MessageBox.Show("入院成功！");
                    }
                }
            }

            MessageBox.Show("入院失败！");
        }

        private void InHospitalCancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateDateToView()
        {
            if (Inpatient != null)
            {
                this.InHospitalNo.Text = Inpatient.No;
                this.CaseNo.Text = "_";
                this.PayTypeEnumCombo.SelectedItem = Inpatient.PayTypeEnum;
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
                this.InDepartmentEdit.Text = "_";
                this.InDoctorEdit.Text = "_";
                this.InHospitalYaJin.Text = "_";
                if (Inpatient.InPatientUser != null)
                {
                    this.InUserName.Text = Inpatient.InPatientUser.Username;
                }
            }
        }

        private bool updateViewToDate()
        {
            if (this.GenderCombo.SelectedItem == null)
                return false;

            if (Inpatient != null)
            {
                Inpatient.No = this.InHospitalNo.Text;
                //"_" = this.CaseNo.Text;
                Inpatient.PayTypeEnum = (CommContracts.PayTypeEnum)this.PayTypeEnumCombo.SelectedItem;
                Inpatient.YiBaoNo = this.YiBaoNo.Text;

                CommContracts.Patient patient = new CommContracts.Patient();
                if (Inpatient.Patient != null)
                {
                    patient.ID = Inpatient.Patient.ID;
                }
                patient.Name = this.Name.Text;
                patient.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
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
                //"_" = this.InDepartmentEdit.Text;
                //"_" = this.InDoctorEdit.Text;
                //"_" = this.InHospitalYaJin.Text;

                Inpatient.InPatientUserID = 3;
            }

            return true;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            LeaveHospitalGrid.Visibility = Visibility.Collapsed;
            Spe.Visibility = Visibility.Collapsed;
            setInHospitalGridEnable();
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            LeaveHospitalGrid.Visibility = Visibility.Visible;
            Spe.Visibility = Visibility.Visible;
            setInHospitalGridEnable(false);
            LeaveHospitalBtn.Visibility = Visibility.Visible;
            RecallHospitalBtn.Visibility = Visibility.Collapsed;
            LeaveHospitalDiagnosisBtn.IsEnabled = true;
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            LeaveHospitalGrid.Visibility = Visibility.Visible;
            Spe.Visibility = Visibility.Visible;
            setInHospitalGridEnable(false);
            LeaveHospitalBtn.Visibility = Visibility.Collapsed;
            RecallHospitalBtn.Visibility = Visibility.Visible;
            LeaveHospitalDiagnosisBtn.IsEnabled = false;
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
            this.InDoctorEdit.IsEnabled = bEnable;
            this.InHospitalYaJin.IsEnabled = bEnable;

            this.InUserName.IsEnabled = false;
            this.InHospitalDiagnosisBtn.IsEnabled = bEnable;

            if(bEnable)
            {
                this.InHospitalBtn.Visibility = Visibility.Visible;
                this.InHospitalCancelBtn.Visibility = Visibility.Visible;
            }
            else
            {
                this.InHospitalBtn.Visibility = Visibility.Collapsed;
                this.InHospitalCancelBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void AllWaitList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}