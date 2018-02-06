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
using HISGUIFeeLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIFeeLib.ViewModels
{
    [Export]
    [Export("HISGUIFeeVM", typeof(HISGUIVMBase))]
    class HISGUIFeeVM : HISGUIVMBase
    {
        // 显示费用管理界面
        public void FeeWorkManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "FeeWorkView");
        }

        // 显示患者的收费单
        public void ShowCharge()
        {
            this.RegionManager.RequestNavigate("DownRegion", "PatientChargesView");
        }

        // 得到所有需要收费的门诊患者
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

        // 得到当前门诊患者的所有药品医嘱收费单
        public List<CommContracts.MedicineCharge> GetAllMedicineCharge()
        {
            CommClient.MedicineCharge charge = new CommClient.MedicineCharge();
            List<CommContracts.MedicineCharge> list = new List<CommContracts.MedicineCharge>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = charge.GetAllClinicMedicineCharge(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = charge.GetAllInHospitalMedicineCharge(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前患者的所有物资材料医嘱收费单
        public List<CommContracts.MaterialCharge> GetAllMaterialCharge()
        {
            CommClient.MaterialCharge charge = new CommClient.MaterialCharge();
            List<CommContracts.MaterialCharge> list = new List<CommContracts.MaterialCharge>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = charge.GetAllClinicMaterialCharge(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = charge.GetAllInHospitalMaterialCharge(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前患者的所有治疗医嘱收费单
        public List<CommContracts.TherapyCharge> GetAllTherapyCharge()
        {
            CommClient.TherapyCharge charge = new CommClient.TherapyCharge();
            List<CommContracts.TherapyCharge> list = new List<CommContracts.TherapyCharge>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = charge.GetAllClinicTherapyCharge(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = charge.GetAllInHospitalTherapyCharge(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前患者的所有化验医嘱收费单
        public List<CommContracts.AssayCharge> GetAllAssayCharge()
        {
            CommClient.AssayCharge charge = new CommClient.AssayCharge();
            List<CommContracts.AssayCharge> list = new List<CommContracts.AssayCharge>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = charge.GetAllClinicAssayCharge(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = charge.GetAllInHospitalAssayCharge(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前患者的所有检查医嘱收费单
        public List<CommContracts.InspectCharge> GetAllInspectCharge()
        {
            CommClient.InspectCharge charge = new CommClient.InspectCharge();
            List<CommContracts.InspectCharge> list = new List<CommContracts.InspectCharge>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = charge.GetAllClinicInspectCharge(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = charge.GetAllInHospitalInspectCharge(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前患者的所有其他医嘱收费单
        public List<CommContracts.OtherServiceCharge> GetAllOtherServiceCharge()
        {
            CommClient.OtherServiceCharge charge = new CommClient.OtherServiceCharge();
            List<CommContracts.OtherServiceCharge> list = new List<CommContracts.OtherServiceCharge>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = charge.GetAllClinicOtherServiceCharge(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = charge.GetAllInHospitalOtherServiceCharge(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前门诊患者的所有西成药处方
        public List<CommContracts.MedicineDoctorAdvice> GetAllXiCheng()
        {
            CommClient.MedicineDoctorAdvice recipe = new CommClient.MedicineDoctorAdvice();     // 处方
            List<CommContracts.MedicineDoctorAdvice> list = new List<CommContracts.MedicineDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = recipe.getAllXiCheng(CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = recipe.getAllInHospitalXiCheng(CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前门诊患者的所有中药处方
        public List<CommContracts.MedicineDoctorAdvice> GetAllZhong()
        {
            CommClient.MedicineDoctorAdvice recipe = new CommClient.MedicineDoctorAdvice();     // 处方
            List<CommContracts.MedicineDoctorAdvice> list = new List<CommContracts.MedicineDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = recipe.getAllZhong(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = recipe.getAllInHospitalZhong(this.CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前门诊患者的所有治疗单
        public List<CommContracts.TherapyDoctorAdvice> GetAllZhiLiao()
        {
            CommClient.TherapyDoctorAdvice therapy = new CommClient.TherapyDoctorAdvice();  // 治疗

            List<CommContracts.TherapyDoctorAdvice> list = new List<CommContracts.TherapyDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = therapy.getAllTherapyDoctorAdvice(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = therapy.getAllInHospitalTherapyDoctorAdvice(this.CurrentInpatient.ID);
            }
            return list;
        }

        public CommContracts.User getUser(int UserID)
        {
            CommClient.User user = new CommClient.User();
            return user.getUser(UserID);
        }

        // 得到当前门诊患者的所有化验申请单
        public List<CommContracts.AssayDoctorAdvice> GetAllJianYan()
        {
            CommClient.AssayDoctorAdvice assay = new CommClient.AssayDoctorAdvice();        // 化验申请

            List<CommContracts.AssayDoctorAdvice> list = new List<CommContracts.AssayDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = assay.getAllAssay(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = assay.getAllInHospitalAssay(this.CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前门诊患者的所有检查申请单
        public List<CommContracts.InspectDoctorAdvice> GetAllJianCha()
        {
            CommClient.InspectDoctorAdvice inspect = new CommClient.InspectDoctorAdvice();  // 检查申请

            List<CommContracts.InspectDoctorAdvice> list = new List<CommContracts.InspectDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = inspect.getAllInspectDoctorAdvice(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = inspect.getAllInHospitalInspect(this.CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前门诊患者的所有材料单
        public List<CommContracts.MaterialDoctorAdvice> GetAllCaiLiao()
        {
            CommClient.MaterialDoctorAdvice materialBill = new CommClient.MaterialDoctorAdvice();   // 材料

            List<CommContracts.MaterialDoctorAdvice> list = new List<CommContracts.MaterialDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = materialBill.getAllMaterialDoctorAdvice(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = materialBill.getAllInHospitalMaterialDoctorAdvice(this.CurrentInpatient.ID);
            }
            return list;
        }



        // 得到当前门诊患者的所其他服务单
        public List<CommContracts.OtherServiceDoctorAdvice> GetAllQiTa()
        {
            CommClient.OtherServiceDoctorAdvice otherService = new CommClient.OtherServiceDoctorAdvice();   // 其他

            List<CommContracts.OtherServiceDoctorAdvice> list = new List<CommContracts.OtherServiceDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = otherService.getAllOtherService(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = otherService.getAllInHospitalOtherService(this.CurrentInpatient.ID);
            }
            return list;
        }

        // 得到当前药品的合理库存
        public List<CommContracts.StoreRoomMedicineNum> GetStoreFromMedicine(int nMedicineID, int nNum)
        {
            CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
            return storeRoomMedicineNum.GetStoreFromMedicine(nMedicineID, nNum);
        }

        // 保存召回
        public bool SaveRecallHospital(CommContracts.RecallHospital recallHospital)
        {
            if (recallHospital == null)
                return false;
            CommClient.RecallHospital myd = new CommClient.RecallHospital();
            return myd.SaveRecallHospital(recallHospital);
        }

        // 保存出院登记
        public bool SaveLeaveHospital(CommContracts.LeaveHospital LeaveHospital)
        {
            if (LeaveHospital == null)
                return false;
            CommClient.LeaveHospital myd = new CommClient.LeaveHospital();
            return myd.SaveLeaveHospital(LeaveHospital);
        }

        // 保存入院登记
        public bool SaveInHospital(CommContracts.InHospital inHospital, CommContracts.InHospitalApply inHospitalApply = null)
        {
            if (inHospital == null)
                return false;
            CommClient.InHospital myd = new CommClient.InHospital();
            if (myd.SaveInHospital(inHospital))
            {
                if (inHospitalApply == null)
                {
                    return true;
                }
                else
                {
                    CommClient.InHospitalApply myd1 = new CommClient.InHospitalApply();
                    inHospitalApply.InHospitalApplyEnum = CommContracts.InHospitalApplyEnum.已处理;
                    if (myd1.UpdateInHospitalApply(inHospitalApply))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        // 修改入院登记
        public bool UpdateInHospital(CommContracts.InHospital inHospital)
        {
            if (inHospital == null)
                return false;
            CommClient.InHospital myd = new CommClient.InHospital();
            return myd.UpdateInHospital(inHospital);
        }

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.InHospital ReadNewInHospital(int PatientID)
        {
            CommClient.InHospital myd = new CommClient.InHospital();
            return myd.ReadNewInHospital(PatientID);
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

        // 读取已入院患者信息
        public CommContracts.InHospital ReadCurrentInHospital(int InPatientID)
        {
            CommClient.InHospital myd = new CommClient.InHospital();
            return myd.ReadCurrentInHospital(InPatientID);
        }

        // 读取已出院患者信息
        public CommContracts.InHospital ReadLeavedPatient(int InPatientID)
        {
            CommClient.InHospital myd = new CommClient.InHospital();
            return myd.ReadLeavedPatient(InPatientID);
        }
        // 得到所有的缴费单
        public List<CommContracts.PrePay> GetAllPrePay(int PatientID)
        {
            CommClient.PrePay myd = new CommClient.PrePay();
            return myd.GetAllPrePay(PatientID);
        }

        public bool SavePrePay(int PatientID, decimal money, int UserID)
        {
            CommClient.PrePay myd = new CommClient.PrePay();
            CommContracts.PrePay prePay = new CommContracts.PrePay();
            prePay.PatientID = PatientID;
            prePay.PrePayMoney = money;
            prePay.PrePayWayEnum = CommContracts.PrePayWayEnum.现金;
            prePay.UserID = UserID;
            prePay.PrePayTime = DateTime.Now;
            return myd.SavePrePay(prePay);
        }

        // 删除缴费单
        public bool DeletePrePay(int PrePayID)
        {
            CommClient.PrePay myd = new CommClient.PrePay();
            return myd.DeletePrePay(PrePayID);
        }

        // 得到所有临床科室
        public List<CommContracts.Department> getAllDepartment(CommContracts.DepartmentEnum departmentEnum = CommContracts.DepartmentEnum.临床科室)
        {
            CommClient.Department myd = new CommClient.Department();
            return myd.getALLDepartment(departmentEnum);
        }
        public List<CommContracts.SignalSource> GetDepartmentSignalSourceList(int DepartmentID, DateTime startDate, DateTime endDate)
        {
            CommClient.SignalSource myd = new CommClient.SignalSource();
            return myd.GetSignalSourceList(DepartmentID, 0, startDate, endDate);
        }

        public List<CommContracts.Registration> GetDepartmentRegistrationList(int DepartmentID, DateTime startDate, DateTime endDate)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.GetDepartmentRegistrationList(DepartmentID, 0, startDate, endDate);
        }

        public bool SaveRegistration(CommContracts.Registration registration)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.SaveRegistration(registration);
        }

        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.UpdateRegistration(registration);
        }

        // 查找某个患者最后一次挂号情况
        public CommContracts.Registration ReadLastRegistration(int PatientID)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.ReadLastRegistration(PatientID);
        }

        // 当前医生收费的挂号单I
        #region CurrentRegistration
        public static readonly DependencyProperty CurrentRegistrationProperty = DependencyProperty.Register(
            "CurrentRegistration", typeof(CommContracts.Registration), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Registration CurrentRegistration
        {
            get { return (CommContracts.Registration)GetValue(CurrentRegistrationProperty); }
            set { SetValue(CurrentRegistrationProperty, value); }
        }

        #endregion

        // 当前住院患者的住院号
        #region CurrentInpatient
        public static readonly DependencyProperty CurrentInPatientProperty = DependencyProperty.Register(
            "CurrentInpatient", typeof(CommContracts.InHospital), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.InHospital CurrentInpatient
        {
            get { return (CommContracts.InHospital)GetValue(CurrentInPatientProperty); }
            set { SetValue(CurrentInPatientProperty, value); }
        }

        #endregion



        // 当前是门诊还是住院收费
        #region IsClinicOrInHospital
        public static readonly DependencyProperty IsClinicOrInHospitalProperty = DependencyProperty.Register(
            "IsClinicOrInHospital", typeof(bool), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public bool IsClinicOrInHospital
        {
            get { return (bool)GetValue(IsClinicOrInHospitalProperty); }
            set { SetValue(IsClinicOrInHospitalProperty, value); }
        }

        #endregion
    }
}
