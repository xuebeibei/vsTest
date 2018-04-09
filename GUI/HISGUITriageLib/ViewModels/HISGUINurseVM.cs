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
using HISGUINurseLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUINurseLib.ViewModels
{
    [Export]
    [Export("HISGUINurseVM", typeof(HISGUIVMBase))]
    class HISGUINurseVM : HISGUIVMBase
    {
        public override void RegisterCommands()
        {
            base.RegisterCommands();
        }

        //显示分诊界面
        public void TriageManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NurseWorkView");
        }

        // 查找某个患者最后一次挂号情况
        public CommContracts.Registration ReadLastRegistration(int PatientID, DateTime? DateTime = null)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.ReadLastRegistration(PatientID, DateTime);
        }

        // 更新挂号单
        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.UpdateRegistration(registration);
        }

        // 得到某一天所有的号源
        public List<CommContracts.WorkPlan> GetOneDaySignalSourceList(DateTime date)
        {
            CommClient.WorkPlan myd = new CommClient.WorkPlan();
            return myd.GetWorkPlanList(0, 0, date, date);
        }

        // 得到某一天的所有到诊患者
        public List<CommContracts.Registration> GetOneDayRegistrationList(DateTime date)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.GetDepartmentRegistrationList(0, 0, date, date);
        }

        // 得到所有需要执行的门诊患者
        public List<CommContracts.Registration> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        // 得到所有需要收费的住院患者
        public List<CommContracts.InHospital> GetAllInHospitalChargePatient()
        {
            CommClient.InHospital myd = new CommClient.InHospital();
            return myd.GetAllInHospitalList();
        }


        // 读取当前患者信息
        public CommContracts.Patient ReadCurrentPatient(int PatientID)
        {
            CommClient.Patient myd = new CommClient.Patient();
            return myd.ReadCurrentPatient(PatientID);
        }

        // 读取当前患者的余额
        public decimal GetCurrentPatientBalance(int PatientID)
        {
            CommClient.Patient myd = new CommClient.Patient();
            return myd.GetCurrentPatientBalance(PatientID);
        }

        // 得到当前门诊患者的所有处方
        public List<CommContracts.MedicineDoctorAdvice> GetAllMedicineDoctorAdvice()
        {
            CommClient.MedicineDoctorAdvice recipe = new CommClient.MedicineDoctorAdvice();     // 处方
            List<CommContracts.MedicineDoctorAdvice> list = new List<CommContracts.MedicineDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                {
                    list.AddRange(recipe.getAllXiCheng(CurrentRegistration.ID));
                    list.AddRange(recipe.getAllZhong(CurrentRegistration.ID));
                }
                    
            }
            else
            {
                if (CurrentInpatient != null)
                {
                    list = recipe.getAllInHospitalXiCheng(CurrentInpatient.ID);
                    list = recipe.getAllInHospitalXiCheng(CurrentInpatient.ID);
                }
                    
            }
            return list;
        }

        // 得到当前门诊患者的已执行单
        public List<CommContracts.InjectionBill> GetAllInjectionBill()
        {
            CommClient.InjectionBill recipe = new CommClient.InjectionBill();
            List<CommContracts.InjectionBill> list = new List<CommContracts.InjectionBill>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                {
                    list.AddRange(recipe.GetAllInjectionBill(CurrentRegistration.ID));
                }
            }
            else
            {
                if (CurrentInpatient != null)
                {
                    list.AddRange(recipe.GetAllInHospitalInjectionBill(CurrentInpatient.ID));
                }
            }
            return list;
        }

        public CommContracts.User getUser(int UserID)
        {
            CommClient.User user = new CommClient.User();
            return user.getUser(UserID);
        }

        // 更新医嘱
        public bool UpdateDoctorAdvice(CommContracts.DoctorAdviceBase doctorAdvice)
        {
            CommClient.DoctorAdviceBase myd = new CommClient.DoctorAdviceBase();
            return myd.UpdateExecuteEnum(doctorAdvice.ID, doctorAdvice.ExecuteEnum);
        }


        // 当前是门诊还是住院收费
        #region IsClinicOrInHospital
        public static readonly DependencyProperty IsClinicOrInHospitalProperty = DependencyProperty.Register(
            "IsClinicOrInHospital", typeof(bool), typeof(HISGUINurseVM), new PropertyMetadata((sender, e) => { }));

        public bool IsClinicOrInHospital
        {
            get { return (bool)GetValue(IsClinicOrInHospitalProperty); }
            set { SetValue(IsClinicOrInHospitalProperty, value); }
        }

        #endregion

        // 当前住院患者的住院号
        #region CurrentInpatient
        public static readonly DependencyProperty CurrentInPatientProperty = DependencyProperty.Register(
            "CurrentInpatient", typeof(CommContracts.InHospital), typeof(HISGUINurseVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.InHospital CurrentInpatient
        {
            get { return (CommContracts.InHospital)GetValue(CurrentInPatientProperty); }
            set { SetValue(CurrentInPatientProperty, value); }
        }

        #endregion

        // 当前医生收费的挂号单I
        #region CurrentRegistration
        public static readonly DependencyProperty CurrentRegistrationProperty = DependencyProperty.Register(
            "CurrentRegistration", typeof(CommContracts.Registration), typeof(HISGUINurseVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Registration CurrentRegistration
        {
            get { return (CommContracts.Registration)GetValue(CurrentRegistrationProperty); }
            set { SetValue(CurrentRegistrationProperty, value); }
        }
        #endregion
    }
}
