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
using HISGUIClinicDoctorLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIClinicDoctorLib.ViewModels
{
    [Export]
    [Export("HISGUIClinicDoctorVM", typeof(HISGUIVMBase))]
    class HISGUIClinicDoctorVM : HISGUIVMBase
    {
        public ICommand RecevingOverCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            RecevingOverCommand = new DelegateCommand(RecevintOver);
        }

        //显示分诊界面
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

        // 显示接诊界面
        public void ReceivingNewPatientsManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "ReceivingNewPatientsView");
        }

        public List<CommContracts.Recipe> getAllXiCheng()
        {
            CommClient.Recipe recipe = new CommClient.Recipe();
            return recipe.getAllXiCheng(RegistrationID);
        }

        public List<CommContracts.Recipe> getAllZhong()
        {
            CommClient.Recipe recipe = new CommClient.Recipe();
            return recipe.getAllZhong(RegistrationID);
        }

        public string newRecipe()
        {
            CommContracts.Recipe recipe = new CommContracts.Recipe();
            ClinicRecipe = recipe;
            return ClinicRecipe.ToTipString();
        }

        public string newTherapy()
        {
            CommContracts.Therapy therapy = new CommContracts.Therapy();
            ClinicTherapy = therapy;
            return ClinicTherapy.ToTipString();
        }

        public string newAssay()
        {
            CommContracts.Assay assay = new CommContracts.Assay();
            ClinicAssay = assay;
            return ClinicAssay.ToTipString();
        }

        public string newInspect()
        {
            CommContracts.Inspect inspect = new CommContracts.Inspect();
            ClinicInspect = inspect;
            return ClinicInspect.ToTipString();
        }

        public bool SaveRecipe(CommContracts.RecipeContentEnum recipeContentEnum, List<CommContracts.RecipeDetail> list)
        {
            CommClient.Recipe myd = new CommClient.Recipe();
            ClinicRecipe.MedicalInstitution = "北京市积水潭总院";
            ClinicRecipe.RecipeContentEnum = recipeContentEnum;
            ClinicRecipe.ChargeTypeEnum = 1;
            ClinicRecipe.RegistrationID = RegistrationID;
            ClinicRecipe.ClinicalDiagnosis = "感冒";
            ClinicRecipe.SumOfMoney = 500.00;
            ClinicRecipe.WriteTime = DateTime.Now;
            ClinicRecipe.WriteUserID = 1;

            ClinicRecipe.RecipeDetails = list;
            myd.MyRecipe = ClinicRecipe;

            if (myd.SaveRecipe())
                return true;
            else
                return false;
        }

        public bool SaveTherapy(List<CommContracts.TherapyDetail> list)
        {
            CommClient.Therapy therapy = new CommClient.Therapy();
            ClinicTherapy.NO = "001";
            ClinicTherapy.RegistrationID = RegistrationID;
            ClinicTherapy.SumOfMoney = 300;
            ClinicTherapy.WriteTime = DateTime.Now;
            ClinicTherapy.WriteUserID = 1;

            ClinicTherapy.TherapyDetails = list;
            if (therapy.SaveTherapy(ClinicTherapy))
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
            ClinicAssay.NO = "001";
            ClinicAssay.RegistrationID = RegistrationID;
            ClinicAssay.SumOfMoney = 300;
            ClinicAssay.WriteTime = DateTime.Now;
            ClinicAssay.WriteUserID = 1;

            ClinicAssay.AssayDetails = list;
            if (therapy.SaveAssay(ClinicAssay))
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
            ClinicInspect.NO = "001";
            ClinicInspect.RegistrationID = RegistrationID;
            ClinicInspect.SumOfMoney = 300;
            ClinicInspect.WriteTime = DateTime.Now;
            ClinicInspect.WriteUserID = 1;

            ClinicInspect.InspectDetails = list;
            if (therapy.SaveInspect(ClinicInspect))
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
            CommClient.Registration myd = new CommClient.Registration();
            return myd.getPatientBMIMsg(RegistrationID);
        }


        public bool SaveClinicMedicalRecord(string strTextContent)
        {
            CommClient.MedicalRecord myd = new CommClient.MedicalRecord();

            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            medicalRecord.RegistrationID = RegistrationID;
            medicalRecord.NO = "001";
            medicalRecord.MedicalRecordEnum = CommContracts.MedicalRecordEnum.MenZhen;
            medicalRecord.WriteUserID = 1;
            medicalRecord.WriteTime = DateTime.Now;
            medicalRecord.ContentXml = strTextContent;

            return myd.SaveMedicalRecord(medicalRecord);
        }

        public string RaveClinicMedicalRecord()
        {
            CommClient.MedicalRecord myd = new CommClient.MedicalRecord();

            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            medicalRecord = myd.GetMedicalRecord(RegistrationID);

            return medicalRecord.ContentXml;
        }

        // 当前医生看诊的挂号单ID
        #region RegistrationID
        public static readonly DependencyProperty RegistrationIDProperty = DependencyProperty.Register(
            "RegistrationID", typeof(int), typeof(HISGUIClinicDoctorVM), new PropertyMetadata((sender, e) => { }));

        public int RegistrationID
        {
            get { return (int)GetValue(RegistrationIDProperty); }
            set { SetValue(RegistrationIDProperty, value); }
        }

        #endregion

        // 当前处方单
        #region ClinicRecipe
        public static readonly DependencyProperty ClinicRecipeProperty = DependencyProperty.Register(
            "ClinicRecipe", typeof(CommContracts.Recipe), typeof(HISGUIClinicDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Recipe ClinicRecipe
        {
            get { return (CommContracts.Recipe)GetValue(ClinicRecipeProperty); }
            set { SetValue(ClinicRecipeProperty, value); }
        }

        #endregion

        // 当前治疗单
        #region ClinicTherapy
        public static readonly DependencyProperty ClinicTherapyProperty = DependencyProperty.Register(
            "ClinicTherapy", typeof(CommContracts.Therapy), typeof(HISGUIClinicDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Therapy ClinicTherapy
        {
            get { return (CommContracts.Therapy)GetValue(ClinicTherapyProperty); }
            set { SetValue(ClinicTherapyProperty, value); }
        }
        #endregion

        // 当前治疗单
        #region ClinicAssay
        public static readonly DependencyProperty ClinicAssayProperty = DependencyProperty.Register(
            "ClinicAssay", typeof(CommContracts.Assay), typeof(HISGUIClinicDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Assay ClinicAssay
        {
            get { return (CommContracts.Assay)GetValue(ClinicAssayProperty); }
            set { SetValue(ClinicAssayProperty, value); }
        }
        #endregion


        // 当前治疗单
        #region ClinicInspect
        public static readonly DependencyProperty ClinicInspectProperty = DependencyProperty.Register(
            "ClinicInspect", typeof(CommContracts.Inspect), typeof(HISGUIClinicDoctorVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Inspect ClinicInspect
        {
            get { return (CommContracts.Inspect)GetValue(ClinicInspectProperty); }
            set { SetValue(ClinicInspectProperty, value); }
        }
        #endregion
    }
}
