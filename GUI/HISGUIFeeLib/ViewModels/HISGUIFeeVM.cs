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
        public Dictionary<int, string> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        // 得到所有需要收费的门诊患者
        public Dictionary<int, string> GetAllInHospitalChargePatient(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.GetAllInPatientMsg();
        }

        // 得到当前门诊患者的所有西成药处方
        public List<CommContracts.MedicineDoctorAdvice> GetAllXiCheng()
        {
            CommClient.MedicineDoctorAdvice recipe = new CommClient.MedicineDoctorAdvice();     // 处方
            List<CommContracts.MedicineDoctorAdvice> list = new List<CommContracts.MedicineDoctorAdvice>();
            if (IsClinicOrInHospital)
            {
                if (CurrentRegistration != null)
                    list = recipe.getAllXiCheng(this.CurrentRegistration.ID);
            }
            else
            {
                if (CurrentInpatient != null)
                    list = recipe.getAllInHospitalXiCheng(this.CurrentInpatient.ID);
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

        // 保存入院登记
        public bool SaveInPatient(CommContracts.Inpatient inpatient)
        {
            if (inpatient == null)
                return false;
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.SaveInPatient(inpatient);
        }

        // 修改入院登记
        public bool UpdateInPatient(CommContracts.Inpatient inpatient)
        {
            if (inpatient == null)
                return false;
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.UpdateInPatient(inpatient);
        }

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.Inpatient ReadNewInPatient(int PatientID)
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.ReadNewInPatient(PatientID);
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
        public CommContracts.Inpatient ReadCurrentInPatient(int InPatientID)
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.ReadCurrentInPatient(InPatientID);
        }

        // 读取已出院患者信息
        public CommContracts.Inpatient ReadLeavedPatient(int InPatientID)
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
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

        // 当前用户
        #region CurrentUser
        public static readonly DependencyProperty CurrentUserProperty = DependencyProperty.Register(
            "CurrentUser", typeof(CommContracts.User), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.User CurrentUser
        {
            get { return (CommContracts.User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        #endregion

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
            "CurrentInpatient", typeof(CommContracts.Inpatient), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Inpatient CurrentInpatient
        {
            get { return (CommContracts.Inpatient)GetValue(CurrentInPatientProperty); }
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
