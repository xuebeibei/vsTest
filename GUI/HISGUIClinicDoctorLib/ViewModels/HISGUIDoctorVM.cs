using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using HISGUIDoctorLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIDoctorLib.ViewModels
{
    [Export]
    [Export("HISGUIDoctorVM", typeof(HISGUIVMBase))]
    class HISGUIDoctorVM : HISGUIVMBase
    {
        public ICommand RecevingOverCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            RecevingOverCommand = new DelegateCommand(RecevintOver);
        }

        //显示工作界面
        public void DoctorWorkManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "DoctorWorkView");
        }

        public void RecevintOver()
        {
            DoctorWorkManage();
        }

        public CommContracts.User getUser(int UserID)
        {
            CommClient.User user = new CommClient.User();
            return user.getUser(UserID);
        }

        // 获得当前医生的门诊患者
        public List<CommContracts.Registration> GetDoctorClinicPatients(int EmployeeID = 0, DateTime? VistTime = null)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.getAllRegistration(EmployeeID, VistTime);
        }

        // 获得当前医生的住院患者
        public List<CommContracts.InHospital> GetDoctorInHospitalPatients(int EmployeeID = 0)
        {
            CommClient.InHospital myd = new CommClient.InHospital();
            return myd.GetAllInHospitalList(CommContracts.InHospitalStatusEnum.在院中, EmployeeID);
        }

        // 显示接诊界面
        public void ReceivingNewPatientsManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "ReceivingNewPatientsView");
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllXiCheng()
        {
            CommClient.MedicineDoctorAdvice MedicineDoctorAdvice = new CommClient.MedicineDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return MedicineDoctorAdvice.getAllXiCheng(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return MedicineDoctorAdvice.getAllInHospitalXiCheng(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllZhong()
        {
            CommClient.MedicineDoctorAdvice MedicineDoctorAdvice = new CommClient.MedicineDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return MedicineDoctorAdvice.getAllZhong(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return MedicineDoctorAdvice.getAllInHospitalZhong(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public List<CommContracts.AssayDoctorAdvice> getAllAssayDoctorAdvice()
        {
            CommClient.AssayDoctorAdvice assay = new CommClient.AssayDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return assay.getAllAssay(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return assay.getAllInHospitalAssay(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllTherapy()
        {
            CommClient.TherapyDoctorAdvice therapy = new CommClient.TherapyDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return therapy.getAllTherapyDoctorAdvice(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return therapy.getAllInHospitalTherapyDoctorAdvice(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInspect()
        {
            CommClient.InspectDoctorAdvice inspect = new CommClient.InspectDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return inspect.getAllInspectDoctorAdvice(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return inspect.getAllInHospitalInspect(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public List<CommContracts.MaterialDoctorAdvice> getAllMaterialDoctorAdvice()
        {
            CommClient.MaterialDoctorAdvice materialBill = new CommClient.MaterialDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return materialBill.getAllMaterialDoctorAdvice(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return materialBill.getAllInHospitalMaterialDoctorAdvice(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public List<CommContracts.OtherServiceDoctorAdvice> getAllOtherService()
        {
            CommClient.OtherServiceDoctorAdvice otherService = new CommClient.OtherServiceDoctorAdvice();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    return otherService.getAllOtherService(CurrentRegistration.ID);
                else
                    return null;
            }
            else
            {
                if (CurrentInpatient != null)
                    return otherService.getAllInHospitalOtherService(CurrentInpatient.ID);
                else
                    return null;
            }
        }

        public string NewMedicineDoctorAdvice()
        {
            CommContracts.MedicineDoctorAdvice recipe = new CommContracts.MedicineDoctorAdvice();
            CurrentMedicineDoctorAdvice = recipe;
            return CurrentMedicineDoctorAdvice.ToString();
        }

        public string newTherapy()
        {
            CommContracts.TherapyDoctorAdvice therapy = new CommContracts.TherapyDoctorAdvice();
            CurrentTherapy = therapy;
            return CurrentTherapy.ToString();
        }

        public string newAssayDoctorAdvice()
        {
            CommContracts.AssayDoctorAdvice assay = new CommContracts.AssayDoctorAdvice();
            CurrentAssayDoctorAdvice = assay;
            return CurrentAssayDoctorAdvice.ToString();
        }

        public string newInspect()
        {
            CommContracts.InspectDoctorAdvice inspect = new CommContracts.InspectDoctorAdvice();
            CurrentInspect = inspect;
            return CurrentInspect.ToString();
        }

        public string newMaterialDoctorAdvice()
        {
            CommContracts.MaterialDoctorAdvice materialBill = new CommContracts.MaterialDoctorAdvice();
            CurrentMaterialDoctorAdvice = materialBill;
            return CurrentMaterialDoctorAdvice.ToString();
        }

        public string newOtherService()
        {
            CommContracts.OtherServiceDoctorAdvice otherService = new CommContracts.OtherServiceDoctorAdvice();
            CurrentOtherService = otherService;
            return CurrentOtherService.ToString();
        }

        public bool SaveMedicineDoctorAdvice(CommContracts.MedicineDoctorAdvice medicineDoctorAdvice)
        {
            CommClient.MedicineDoctorAdvice myd = new CommClient.MedicineDoctorAdvice();
            return myd.SaveMedicineDoctorAdvice(medicineDoctorAdvice);
        }

        public bool SaveTherapyDoctorAdvice(CommContracts.TherapyDoctorAdvice therapyDoctorAdvice)
        {
            CommClient.TherapyDoctorAdvice therapy = new CommClient.TherapyDoctorAdvice();
            return therapy.SaveTherapyDoctorAdvice(therapyDoctorAdvice);
        }

        public bool SaveAssayDoctorAdvice(CommContracts.AssayDoctorAdvice assayDoctorAdvice)
        {
            CommClient.AssayDoctorAdvice therapy = new CommClient.AssayDoctorAdvice();
            return therapy.SaveAssay(assayDoctorAdvice);
        }

        public bool SaveInspectDoctorAdvice(CommContracts.InspectDoctorAdvice inspectDoctorAdvice)
        {
            CommClient.InspectDoctorAdvice therapy = new CommClient.InspectDoctorAdvice();
            return therapy.SaveInspectDoctorAdvice(inspectDoctorAdvice);
        }

        public bool SaveMaterialDoctorAdvice(CommContracts.MaterialDoctorAdvice materialDoctorAdvice)
        {
            CommClient.MaterialDoctorAdvice materialBill = new CommClient.MaterialDoctorAdvice();
            return materialBill.SaveMaterialDoctorAdvice(materialDoctorAdvice);
        }

        public bool SaveOtherServiceDoctorAdvice(CommContracts.OtherServiceDoctorAdvice otherServiceDoctorAdvice)
        {
            CommClient.OtherServiceDoctorAdvice otherService = new CommClient.OtherServiceDoctorAdvice();
            return otherService.SaveOtherService(otherServiceDoctorAdvice);
        }

        public bool SaveClinicMedicalRecord(CommContracts.MedicalRecord medicalRecord)
        {
            CommClient.MedicalRecord myd = new CommClient.MedicalRecord();
            return myd.SaveMedicalRecord(medicalRecord);
        }

        public string GetClinicMedicalRecord()
        {
            CommClient.MedicalRecord myd = new CommClient.MedicalRecord();

            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            if (CurrentRegistration != null)
                medicalRecord = myd.GetMedicalRecord(CurrentRegistration.ID);

            return medicalRecord.ContentXml;
        }

        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.UpdateRegistration(registration);
        }

        public bool SaveSignalSourceList(List<CommContracts.SignalSource> list)
        {
            CommClient.SignalSource myd = new CommClient.SignalSource();
            return myd.SaveSignalSourceList(list);
        }

        public List<CommContracts.SignalSource> GetSignalSourceList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            CommClient.SignalSource myd = new CommClient.SignalSource();
            return myd.GetSignalSourceList(DepartmentID, EmployeeID, startDate, endDate);
        }

        public bool SaveInHospitalApply(CommContracts.InHospitalApply inpatient)
        {
            CommClient.InHospitalApply myd = new CommClient.InHospitalApply();
            return myd.SaveInHospitalApply(inpatient); 
        }

        // 当前用户
        #region CurrentUser
        public static readonly DependencyProperty CurrentUserProperty = DependencyProperty.Register(
            "CurrentUser", typeof(CommContracts.User), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.User CurrentUser
        {
            get { return (CommContracts.User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        #endregion


        // 当前医生看诊的挂号单
        #region CurrentRegistration
        public static readonly DependencyProperty CurrentRegistrationProperty = DependencyProperty.Register(
            "CurrentRegistration", typeof(CommContracts.Registration), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Registration CurrentRegistration
        {
            get { return (CommContracts.Registration)GetValue(CurrentRegistrationProperty); }
            set { SetValue(CurrentRegistrationProperty, value); }
        }

        #endregion

        // 当前医生看诊的住院号
        #region CurrentInpatient
        public static readonly DependencyProperty CurrentInPatientProperty = DependencyProperty.Register(
            "CurrentInpatient", typeof(CommContracts.InHospital), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.InHospital CurrentInpatient
        {
            get { return (CommContracts.InHospital)GetValue(CurrentInPatientProperty); }
            set { SetValue(CurrentInPatientProperty, value); }
        }

        #endregion

        // 当前是门诊还是住院
        #region IsClinicOrInHospital
        public static readonly DependencyProperty IsClinicOrInHospitalProperty = DependencyProperty.Register(
            "IsClinicOrInHospital", typeof(bool), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public bool IsClinicOrInHospital
        {
            get { return (bool)GetValue(IsClinicOrInHospitalProperty); }
            set { SetValue(IsClinicOrInHospitalProperty, value); }
        }

        #endregion


        // 当前处方单
        #region CurrentMedicineDoctorAdvice
        public static readonly DependencyProperty CurrentRecipeProperty = DependencyProperty.Register(
            "CurrentMedicineDoctorAdvice", typeof(CommContracts.MedicineDoctorAdvice), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MedicineDoctorAdvice CurrentMedicineDoctorAdvice
        {
            get { return (CommContracts.MedicineDoctorAdvice)GetValue(CurrentRecipeProperty); }
            set { SetValue(CurrentRecipeProperty, value); }
        }

        #endregion

        // 当前治疗单
        #region CurrentTherapy
        public static readonly DependencyProperty CurrentTherapyProperty = DependencyProperty.Register(
            "CurrentTherapy", typeof(CommContracts.TherapyDoctorAdvice), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.TherapyDoctorAdvice CurrentTherapy
        {
            get { return (CommContracts.TherapyDoctorAdvice)GetValue(CurrentTherapyProperty); }
            set { SetValue(CurrentTherapyProperty, value); }
        }
        #endregion

        // 当前治疗单
        #region CurrentAssayDoctorAdvice
        public static readonly DependencyProperty CurrentAssayDoctorAdviceProperty = DependencyProperty.Register(
            "CurrentAssayDoctorAdvice", typeof(CommContracts.AssayDoctorAdvice), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.AssayDoctorAdvice CurrentAssayDoctorAdvice
        {
            get { return (CommContracts.AssayDoctorAdvice)GetValue(CurrentAssayDoctorAdviceProperty); }
            set { SetValue(CurrentAssayDoctorAdviceProperty, value); }
        }
        #endregion


        // 当前治疗单
        #region CurrentInspect
        public static readonly DependencyProperty CurrentInspectProperty = DependencyProperty.Register(
            "CurrentInspect", typeof(CommContracts.InspectDoctorAdvice), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.InspectDoctorAdvice CurrentInspect
        {
            get { return (CommContracts.InspectDoctorAdvice)GetValue(CurrentInspectProperty); }
            set { SetValue(CurrentInspectProperty, value); }
        }
        #endregion

        // 当前材料单
        #region CurrentMaterialDoctorAdvice
        public static readonly DependencyProperty CurrentMaterialDoctorAdviceProperty = DependencyProperty.Register(
            "CurrentMaterialDoctorAdvice", typeof(CommContracts.MaterialDoctorAdvice), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MaterialDoctorAdvice CurrentMaterialDoctorAdvice
        {
            get { return (CommContracts.MaterialDoctorAdvice)GetValue(CurrentMaterialDoctorAdviceProperty); }
            set { SetValue(CurrentMaterialDoctorAdviceProperty, value); }
        }
        #endregion

        // 当前其他服务单
        #region CurrentOtherService
        public static readonly DependencyProperty CurrentOtherServiceProperty = DependencyProperty.Register(
            "CurrentOtherService", typeof(CommContracts.OtherServiceDoctorAdvice), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.OtherServiceDoctorAdvice CurrentOtherService
        {
            get { return (CommContracts.OtherServiceDoctorAdvice)GetValue(CurrentOtherServiceProperty); }
            set { SetValue(CurrentOtherServiceProperty, value); }
        }
        #endregion
    }
}
