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

        // 获得当前医生的患者
        public Dictionary<int, string> GetPatients()
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.getAllRegistration();
        }

        // 获得当前医生的住院患者
        public Dictionary<int, string> GetAllInPatient()
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.GetAllInPatientMsg();
        }

        // 显示接诊界面
        public void ReceivingNewPatientsManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "ReceivingNewPatientsView");
        }

        public List<CommContracts.Recipe> getAllXiCheng()
        {
            CommClient.Recipe recipe = new CommClient.Recipe();
            if (IsClinicOrInHospital)
            {
                return recipe.getAllXiCheng(CurrentRegistrationID);
            }
            else
            {
                return recipe.getAllInHospitalXiCheng(CurrentInpatientID);
            }
        }

        public List<CommContracts.Recipe> getAllZhong()
        {
            CommClient.Recipe recipe = new CommClient.Recipe();
            if (IsClinicOrInHospital)
            {
                return recipe.getAllZhong(CurrentRegistrationID);
            }
            else
            {
                return recipe.getAllInHospitalZhong(CurrentInpatientID);
            }
        }

        public List<CommContracts.Assay> getAllAssay()
        {
            CommClient.Assay assay = new CommClient.Assay();
            if (IsClinicOrInHospital)
            {
                return assay.getAllAssay(CurrentRegistrationID);
            }
            else
            {
                return assay.getAllInHospitalAssay(CurrentInpatientID);
            }
        }

        public List<CommContracts.Therapy> getAllTherapy()
        {
            CommClient.Therapy therapy = new CommClient.Therapy();
            if (IsClinicOrInHospital)
            {
                return therapy.getAllTherapy(CurrentRegistrationID);
            }
            else
            {
                return therapy.getAllInHospitalTherapy(CurrentInpatientID);
            }
        }

        public List<CommContracts.Inspect> getAllInspect()
        {
            CommClient.Inspect inspect = new CommClient.Inspect();
            if (IsClinicOrInHospital)
            {
                return inspect.getAllInspect(CurrentRegistrationID);
            }
            else
            {
                return inspect.getAllInHospitalInspect(CurrentInpatientID);
            }
        }

        public List<CommContracts.MaterialBill> getAllMaterialBill()
        {
            CommClient.MaterialBill materialBill = new CommClient.MaterialBill();
            if (IsClinicOrInHospital)
            {
                return materialBill.getAllMaterialBill(CurrentRegistrationID);
            }
            else
            {
                return materialBill.getAllInHospitalMaterialBill(CurrentInpatientID);
            }
        }

        public List<CommContracts.OtherService> getAllOtherService()
        {
            CommClient.OtherService otherService = new CommClient.OtherService();
            if (IsClinicOrInHospital)
            {
                return otherService.getAllOtherService(CurrentRegistrationID);
            }
            else
            {
                return otherService.getAllInHospitalOtherService(CurrentInpatientID);
            }
        }



        public string newRecipe()
        {
            CommContracts.Recipe recipe = new CommContracts.Recipe();
            CurrentRecipe = recipe;
            return CurrentRecipe.ToTipString();
        }

        public string newTherapy()
        {
            CommContracts.Therapy therapy = new CommContracts.Therapy();
            CurrentTherapy = therapy;
            return CurrentTherapy.ToTipString();
        }

        public string newAssay()
        {
            CommContracts.Assay assay = new CommContracts.Assay();
            CurrentAssay = assay;
            return CurrentAssay.ToTipString();
        }

        public string newInspect()
        {
            CommContracts.Inspect inspect = new CommContracts.Inspect();
            CurrentInspect = inspect;
            return CurrentInspect.ToTipString();
        }

        public string newMaterialBill()
        {
            CommContracts.MaterialBill materialBill = new CommContracts.MaterialBill();
            CurrentMaterialBill = materialBill;
            return CurrentMaterialBill.ToTipString();
        }

        public string newOtherService()
        {
            CommContracts.OtherService otherService = new CommContracts.OtherService();
            CurrentOtherService = otherService;
            return CurrentOtherService.ToTipString();
        }

        public bool SaveRecipe(CommContracts.RecipeContentEnum recipeContentEnum, List<CommContracts.RecipeDetail> list)
        {
            CommClient.Recipe myd = new CommClient.Recipe();
            CurrentRecipe.MedicalInstitution = "北京市积水潭总院";
            CurrentRecipe.RecipeContentEnum = recipeContentEnum;
            CurrentRecipe.ChargeTypeEnum = 1;
            if (IsClinicOrInHospital)
                CurrentRecipe.RegistrationID = CurrentRegistrationID;
            else
                CurrentRecipe.InpatientID = CurrentInpatientID;
            CurrentRecipe.ClinicalDiagnosis = "感冒";
            CurrentRecipe.SumOfMoney = 500.00m;
            CurrentRecipe.WriteTime = DateTime.Now;
            CurrentRecipe.WriteUserID = 1;

            CurrentRecipe.RecipeDetails = list;
            myd.MyRecipe = CurrentRecipe;

            if (myd.SaveRecipe())
                return true;
            else
                return false;
        }

        public bool SaveTherapy(List<CommContracts.TherapyDetail> list)
        {
            CommClient.Therapy therapy = new CommClient.Therapy();
            CurrentTherapy.NO = "001";
            if (IsClinicOrInHospital)
                CurrentTherapy.RegistrationID = CurrentRegistrationID;
            else
                CurrentTherapy.InpatientID = CurrentInpatientID;
            CurrentTherapy.SumOfMoney = 300;
            CurrentTherapy.WriteTime = DateTime.Now;
            CurrentTherapy.WriteUserID = 1;

            CurrentTherapy.TherapyDetails = list;
            if (therapy.SaveTherapy(CurrentTherapy))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveAssay(List<CommContracts.AssayDetail> list)
        {
            CommClient.Assay therapy = new CommClient.Assay();
            CurrentAssay.NO = "001";
            if (IsClinicOrInHospital)
                CurrentAssay.RegistrationID = CurrentRegistrationID;
            else
                CurrentAssay.InpatientID = CurrentInpatientID;
            CurrentAssay.SumOfMoney = 300;
            CurrentAssay.WriteTime = DateTime.Now;
            CurrentAssay.WriteUserID = 1;

            CurrentAssay.AssayDetails = list;
            if (therapy.SaveAssay(CurrentAssay))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveInspect(List<CommContracts.InspectDetail> list)
        {
            CommClient.Inspect therapy = new CommClient.Inspect();
            CurrentInspect.NO = "001";
            if (IsClinicOrInHospital)
                CurrentInspect.RegistrationID = CurrentRegistrationID;
            else
                CurrentInspect.InpatientID = CurrentInpatientID;
            CurrentInspect.SumOfMoney = 300;
            CurrentInspect.WriteTime = DateTime.Now;
            CurrentInspect.WriteUserID = 1;

            CurrentInspect.InspectDetails = list;
            if (therapy.SaveInspect(CurrentInspect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveMaterialBill(List<CommContracts.MaterialBillDetail> list)
        {
            CommClient.MaterialBill materialBill = new CommClient.MaterialBill();
            CurrentMaterialBill.NO = "001";
            if (IsClinicOrInHospital)
                CurrentMaterialBill.RegistrationID = CurrentRegistrationID;
            else
                CurrentMaterialBill.InpatientID = CurrentInpatientID;
            CurrentMaterialBill.SumOfMoney = 300;
            CurrentMaterialBill.WriteTime = DateTime.Now;
            CurrentMaterialBill.WriteUserID = 1;

            CurrentMaterialBill.MaterialBillDetails = list;
            if (materialBill.SaveMaterialBill(CurrentMaterialBill))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveOtherService(List<CommContracts.OtherServiceDetail> list)
        {
            CommClient.OtherService otherService = new CommClient.OtherService();
            CurrentOtherService.NO = "001";
            if (IsClinicOrInHospital)
                CurrentOtherService.RegistrationID = CurrentRegistrationID;
            else
                CurrentOtherService.InpatientID = CurrentInpatientID;
            CurrentOtherService.SumOfMoney = 300;
            CurrentOtherService.WriteTime = DateTime.Now;
            CurrentOtherService.WriteUserID = 1;

            CurrentOtherService.OtherServiceDetails = list;
            if (otherService.SaveOtherService(CurrentOtherService))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getPatientBMIMsg()
        {
            if(IsClinicOrInHospital)
            {
                CommClient.Registration myd = new CommClient.Registration();
                return myd.getPatientBMIMsg(CurrentRegistrationID);
            }
            else
            {
                CommClient.Inpatient inpatient = new CommClient.Inpatient();
                return inpatient.getInPatientBMIMsg(CurrentInpatientID);
            }
        }


        public bool SaveClinicMedicalRecord(string strTextContent)
        {
            CommClient.MedicalRecord myd = new CommClient.MedicalRecord();

            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            medicalRecord.RegistrationID = CurrentRegistrationID;
            medicalRecord.NO = "001";
            medicalRecord.MedicalRecordEnum = CommContracts.MedicalRecordEnum.MenZhen;
            medicalRecord.WriteUserID = 1;
            medicalRecord.WriteTime = DateTime.Now;
            medicalRecord.ContentXml = strTextContent;

            return myd.SaveMedicalRecord(medicalRecord);
        }

        public string GetClinicMedicalRecord()
        {
            CommClient.MedicalRecord myd = new CommClient.MedicalRecord();

            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            medicalRecord = myd.GetMedicalRecord(CurrentRegistrationID);

            return medicalRecord.ContentXml;
        }

        // 当前医生看诊的挂号单ID
        #region CurrentRegistrationID
        public static readonly DependencyProperty CurrentRegistrationIDProperty = DependencyProperty.Register(
            "CurrentRegistrationID", typeof(int), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public int CurrentRegistrationID
        {
            get { return (int)GetValue(CurrentRegistrationIDProperty); }
            set { SetValue(CurrentRegistrationIDProperty, value); }
        }

        #endregion

        // 当前医生看诊的住院号ID
        #region CurrentInpatientID
        public static readonly DependencyProperty CurrentInPatientIDProperty = DependencyProperty.Register(
            "CurrentInpatientID", typeof(int), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public int CurrentInpatientID
        {
            get { return (int)GetValue(CurrentInPatientIDProperty); }
            set { SetValue(CurrentInPatientIDProperty, value); }
        }

        #endregion

        // 当前医生看诊的住院号ID
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
        #region CurrentRecipe
        public static readonly DependencyProperty CurrentRecipeProperty = DependencyProperty.Register(
            "CurrentRecipe", typeof(CommContracts.Recipe), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Recipe CurrentRecipe
        {
            get { return (CommContracts.Recipe)GetValue(CurrentRecipeProperty); }
            set { SetValue(CurrentRecipeProperty, value); }
        }

        #endregion

        // 当前治疗单
        #region CurrentTherapy
        public static readonly DependencyProperty CurrentTherapyProperty = DependencyProperty.Register(
            "CurrentTherapy", typeof(CommContracts.Therapy), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Therapy CurrentTherapy
        {
            get { return (CommContracts.Therapy)GetValue(CurrentTherapyProperty); }
            set { SetValue(CurrentTherapyProperty, value); }
        }
        #endregion

        // 当前治疗单
        #region CurrentAssay
        public static readonly DependencyProperty CurrentAssayProperty = DependencyProperty.Register(
            "CurrentAssay", typeof(CommContracts.Assay), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Assay CurrentAssay
        {
            get { return (CommContracts.Assay)GetValue(CurrentAssayProperty); }
            set { SetValue(CurrentAssayProperty, value); }
        }
        #endregion


        // 当前治疗单
        #region CurrentInspect
        public static readonly DependencyProperty CurrentInspectProperty = DependencyProperty.Register(
            "CurrentInspect", typeof(CommContracts.Inspect), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Inspect CurrentInspect
        {
            get { return (CommContracts.Inspect)GetValue(CurrentInspectProperty); }
            set { SetValue(CurrentInspectProperty, value); }
        }
        #endregion

        // 当前材料单
        #region CurrentMaterialBill
        public static readonly DependencyProperty CurrentMaterialBillProperty = DependencyProperty.Register(
            "CurrentMaterialBill", typeof(CommContracts.MaterialBill), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MaterialBill CurrentMaterialBill
        {
            get { return (CommContracts.MaterialBill)GetValue(CurrentMaterialBillProperty); }
            set { SetValue(CurrentMaterialBillProperty, value); }
        }
        #endregion

        // 当前其他服务单
        #region CurrentOtherService
        public static readonly DependencyProperty CurrentOtherServiceProperty = DependencyProperty.Register(
            "CurrentOtherService", typeof(CommContracts.OtherService), typeof(HISGUIDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.OtherService CurrentOtherService
        {
            get { return (CommContracts.OtherService)GetValue(CurrentOtherServiceProperty); }
            set { SetValue(CurrentOtherServiceProperty, value); }
        }
        #endregion
    }
}
