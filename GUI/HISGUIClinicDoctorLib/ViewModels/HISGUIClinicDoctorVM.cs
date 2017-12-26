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

        public string newRecipe()
        {
            CommContracts.Recipe recipe = new CommContracts.Recipe();
            //recipe.No = "0002";
            //recipe.WriteTime = DateTime.Now;

            ClinicRecipe = recipe;
            return ClinicRecipe.ToTipString();
        }

        public string newTherapy()
        {
            CommContracts.Therapy therapy = new CommContracts.Therapy();
            //recipe.No = "0002";
            //recipe.WriteTime = DateTime.Now;

            ClinicTherapy = therapy;
            return ClinicTherapy.ToString();
        }

        public bool SaveRecipe(List<CommContracts.RecipeDetail> list)
        {
            CommClient.Recipe myd = new CommClient.Recipe();
            ClinicRecipe.MedicalInstitution = "北京市积水潭总院";
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
    }
}
