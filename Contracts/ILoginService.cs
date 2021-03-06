﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;
using System.Data;

namespace CommContracts
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        CommContracts.Employee UserAuthenticate(string LoginName, string Password, string MachineCode);
        [OperationContract]
        bool UserLogout(Employee login);

        [OperationContract]
        List<CommContracts.EmployeeLoginHistory> GetAllLoginInAndOutRecords(string strName);
        [OperationContract]
        bool UpdateLoginInAndOutRecords(CommContracts.EmployeeLoginHistory LoginInAndOutRecords);
        [OperationContract]
        bool SaveEmployeeLoginHistory(CommContracts.EmployeeLoginHistory LoginInAndOutRecords);
        [OperationContract]
        bool DeleteLoginInAndOutRecords(int LoginInAndOutRecordsID);


        [OperationContract]
        List<CommContracts.PatientCardManage> GetAllPatientCardManage(string strName = "");

        [OperationContract]
        bool UpdatePatientCardManage(CommContracts.PatientCardManage PatientCardManage);

        [OperationContract]
        bool SavePatientCardManage(CommContracts.PatientCardManage PatientCardManage, ref string ErrorMsg);

        [OperationContract]
        bool DeletePatientCardManage(int PatientCardManageID);



        [OperationContract]
        int getAllDepartmentNum();

        [OperationContract]
        List<CommContracts.Department> getALLDepartment(CommContracts.DepartmentEnum departmentEnum);

        [OperationContract]
        List<CommContracts.Department> getALLDepartmentByName(string strName = "");

        [OperationContract]
        bool SaveDepartment(CommContracts.Department department);

        [OperationContract]
        bool UpdateDepartment(CommContracts.Department department);

        [OperationContract]
        bool DeleteDepartment(int departmentID);

        [OperationContract]
        List<CommContracts.WorkPlan> GetAllWorkPlan();

        [OperationContract]
        List<DateTime> getAllWorkPlanDate(int DepartmentID);

        [OperationContract]
        List<int> getAllWorkPlanIntival(int DepartmentID);

        [OperationContract]
        string getWorkPlanTip(int DepartmentID, DateTime dateTime, int TimeIntival);

        [OperationContract]
        bool UpdateWorkPlanHasUsedNum(int nSignalSourceID);
        [OperationContract]
        bool SaveWorkPlanList(List<CommContracts.WorkPlan> list);
        [OperationContract]
        List<CommContracts.WorkPlan> GetWorkPlanList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate, int ClinicVistTimeID);
        [OperationContract]
        bool UpdateWorkPlan(CommContracts.WorkPlan signalSource);

        [OperationContract]
        bool UpdateWorkPlanStatus(int workPlanID, CommContracts.WorkPlanStatus workPlanStatus);

        [OperationContract]
        List<CommContracts.WorkPlanToSignalSource> GetAllWorkPlan111(int DepartmentID, DateTime startDate, DateTime endDate);

        [OperationContract]
        List<CommContracts.Employee> GetAllEmployee(string strName = "");
        [OperationContract]
        bool UpdateEmployee(CommContracts.Employee employee);

        [OperationContract]
        bool SaveEmployee(CommContracts.Employee employee, ref int employeeID);

        [OperationContract]
        bool DeleteEmployee(int employeeID);

        [OperationContract]
        CommContracts.Department GetCurrentDepartment(int employeeID);

        [OperationContract]
        CommContracts.Job GetCurrentJob(int employeeID);

        [OperationContract]
        CommContracts.Medicine GetMedicine(int id);

        [OperationContract]
        List<CommContracts.Medicine> GetOneTypeMedicine(CommContracts.MedicineTypeEnum medicineTypeEnum, string strName = "");

        [OperationContract]
        List<CommContracts.Medicine> GetAllXiChengMedicine(string strName = "");
        [OperationContract]
        List<CommContracts.Medicine> GetAllMedicine(string strName = "");
        [OperationContract]
        bool UpdateMedicine(CommContracts.Medicine Medicine);
        [OperationContract]
        bool SaveMedicine(CommContracts.Medicine Medicine);
        [OperationContract]
        bool DeleteMedicine(int MedicineID);

        [OperationContract]
        bool SaveTriage(int nDoctorID, int nRegistrationID);

        [OperationContract]
        // 根据收费单更新库存
        bool SubdMedicineStoreNumByAdvice(CommContracts.MedicineCharge medicineCharge);

        [OperationContract]
        bool SaveMedicineCharge(CommContracts.MedicineCharge MedicineCharge);

        [OperationContract]
        List<CommContracts.MedicineCharge> GetAllChargeFromMedicineAdvice(int AdviceID);


        [OperationContract]
        bool SaveMedicineDoctorAdvice(CommContracts.MedicineDoctorAdvice MedicineDoctorAdvice);

        [OperationContract]
        List<CommContracts.MedicineDoctorAdvice> getAllXiCheng(int RegistrationID);

        [OperationContract]
        List<CommContracts.MedicineDoctorAdvice> getAllZhong(int RegistrationID);

        [OperationContract]
        List<CommContracts.MedicineDoctorAdvice> getAllInHospitalXiCheng(int InpatientID);

        [OperationContract]
        List<CommContracts.MedicineDoctorAdvice> getAllInHospitalZhong(int InpatientID);

        [OperationContract]
        List<CommContracts.MedicineCharge> GetAllClinicMedicineCharge(int RegistrationID);
        [OperationContract]
        List<CommContracts.MedicineCharge> GetAllInHospitalMedicineCharge(int InpatientID);

        [OperationContract]
        CommContracts.MedicalRecord GetMedicalRecord(int id);

        [OperationContract]
        bool SaveMedicalRecord(CommContracts.MedicalRecord medicalRecord);

        [OperationContract]
        CommContracts.TherapyDoctorAdvice GetTherapyDoctorAdvice(int Id);

        [OperationContract]
        bool SaveTherapyDoctorAdvice(CommContracts.TherapyDoctorAdvice therapy);

        [OperationContract]
        List<CommContracts.TherapyItem> GetAllTherapyItem(string strName);
        [OperationContract]
        bool UpdateTherapyItem(CommContracts.TherapyItem TherapyItem);
        [OperationContract]
        bool SaveTherapyItem(CommContracts.TherapyItem material);
        [OperationContract]
        bool DeleteTherapyItem(int TherapyItemID);

        [OperationContract]
        CommContracts.AssayDoctorAdvice GetAssayDoctorAdvice(int Id);

        [OperationContract]
        List<CommContracts.AssayDoctorAdvice> getAllAssayDoctorAdvice(int RegistrationID);

        [OperationContract]
        List<CommContracts.InspectDoctorAdvice> getAllInspectDoctorAdvice(int RegistrationID);

        [OperationContract]
        List<CommContracts.TherapyDoctorAdvice> getAllTherapyDoctorAdvice(int RegistrationID);

        [OperationContract]
        bool SaveAssayDoctorAdvice(CommContracts.AssayDoctorAdvice assay);

        [OperationContract]
        CommContracts.InspectDoctorAdvice GetInspectDoctorAdvice(int Id);

        [OperationContract]
        bool SaveInspectDoctorAdvice(CommContracts.InspectDoctorAdvice inspect);

        [OperationContract]
        List<CommContracts.AssayItem> GetAllAssayItem(string strName);
        [OperationContract]
        bool UpdateAssayItem(CommContracts.AssayItem AssayItem);
        [OperationContract]
        bool SaveAssayItem(CommContracts.AssayItem AssayItem);
        [OperationContract]
        bool DeleteAssayItem(int AssayItemID);


        [OperationContract]
        List<CommContracts.InspectItem> GetAllInspectItem(string strName = "");
        [OperationContract]
        bool UpdateInspectItem(CommContracts.InspectItem InspectItem);
        [OperationContract]
        bool SaveInspectItem(CommContracts.InspectItem material);
        [OperationContract]
        bool DeleteInspectItem(int InspectItemID);

        [OperationContract]
        List<CommContracts.InHospital> GetAllInHospitalList(int EmployeeID = 0, string strName = "");

        [OperationContract]
        string getInHospitalBMIMsg(int InHospitalID);

        [OperationContract]
        bool SaveInHospital(CommContracts.InHospital InHospital);

        [OperationContract]
        bool UpdateInHospital(CommContracts.InHospital InHospital);

        // 读取未入院患者信息，并新建入院登记
        [OperationContract]
        CommContracts.InHospital ReadNewInHospital(int PatientID);

        // 读取已入院患者信息
        [OperationContract]
        CommContracts.InHospital ReadCurrentInHospital(int InHospitalID);

        // 读取已出院患者信息
        [OperationContract]
        CommContracts.InHospital ReadLeavedPatient(int InHospitalID);

        [OperationContract]
        List<CommContracts.InspectDoctorAdvice> getAllInHospitalInspect(int InpatientID);

        [OperationContract]
        List<CommContracts.TherapyDoctorAdvice> getAllInHospitalTherapyDoctorAdvice(int InpatientID);

        [OperationContract]
        List<CommContracts.AssayDoctorAdvice> getAllInHospitalAssayDoctorAdvice(int InpatientID);

        [OperationContract]
        CommContracts.MaterialDoctorAdvice GetMaterialDoctorAdvice(int Id);

        [OperationContract]
        bool SaveMaterialDoctorAdvice(CommContracts.MaterialDoctorAdvice MaterialDoctorAdvice);

        [OperationContract]
        List<CommContracts.MaterialDoctorAdvice> getAllMaterialDoctorAdvice(int RegistrationID);

        [OperationContract]
        List<CommContracts.MaterialDoctorAdvice> getAllInHospitalMaterialDoctorAdvice(int InpatientID);


        [OperationContract]
        CommContracts.OtherServiceDoctorAdvice GetOtherService(int Id);

        [OperationContract]
        bool SaveOtherService(CommContracts.OtherServiceDoctorAdvice otherService);

        [OperationContract]
        List<CommContracts.OtherServiceDoctorAdvice> getAllOtherService(int RegistrationID);

        [OperationContract]
        List<CommContracts.OtherServiceDoctorAdvice> getAllInHospitalOtherService(int InpatientID);

        [OperationContract]
        List<CommContracts.OtherServiceItem> GetAllOtherServiceItem(string strName);

        [OperationContract]
        bool UpdateOtherServiceItem(CommContracts.OtherServiceItem OtherServiceItem);

        [OperationContract]
        bool SaveOtherServiceItem(CommContracts.OtherServiceItem material);

        [OperationContract]
        bool DeleteOtherServiceItem(int OtherServiceItemID);


        [OperationContract]
        bool SaveMedicineInStock(CommContracts.MedicineInStore medicineInStore);

        [OperationContract]
        bool RecheckMedicineInStock(CommContracts.MedicineInStore medicineInStore);

        [OperationContract]
        List<CommContracts.MedicineInStore> getAllMedicineInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "");

        [OperationContract]
        List<CommContracts.Supplier> GetAllSuppliers(string strFindName);

        [OperationContract]
        bool UpdateSupplier(CommContracts.Supplier supplier);

        [OperationContract]
        bool SaveSupplier(CommContracts.Supplier supplier);

        [OperationContract]
        bool DeleteSupplier(int supplierID);

        [OperationContract]
        bool ReCheckMedicineInStore(CommContracts.MedicineInStore medicineInStore);

        [OperationContract]
        List<CommContracts.StoreRoomMedicineNum> getAllMedicineItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough);

        [OperationContract]
        List<CommContracts.MedicineOutStore> getAllMedicineOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string OutStoreNo = "");

        [OperationContract]
        bool SaveMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore);

        [OperationContract]
        bool RecheckMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore);

        [OperationContract]
        bool RecheckMedicineOutStore(CommContracts.MedicineOutStore medicineOutStore);
        [OperationContract]
        bool ReCheckMedicineCheckStore(CommContracts.MedicineCheckStore medicineCheckStore);

        [OperationContract]
        bool SaveMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore);

        [OperationContract]
        bool RecheckMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore);

        [OperationContract]
        List<CommContracts.MedicineCheckStore> getAllMedicineCheckStore(int StoreID,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "");

        [OperationContract]
        // 得到当前药品的合理库存
        List<CommContracts.StoreRoomMedicineNum> GetStoreFromMedicine(int nMedicineID, int nNum);

        [OperationContract]
        List<CommContracts.Job> GetAllJob(string strName = "");

        [OperationContract]
        List<CommContracts.Job> GetAllTypeJob(CommContracts.JobTypeEnum typeEnum);

        [OperationContract]
        bool UpdateJob(CommContracts.Job job);

        [OperationContract]
        bool DeleteJob(int jobID);

        [OperationContract]
        bool SaveJob(CommContracts.Job job);

        [OperationContract]
        List<CommContracts.StoreRoom> GetAllStoreRoom(string strName = "");

        [OperationContract]
        bool UpdateStoreRoom(CommContracts.StoreRoom storeRoom);

        [OperationContract]
        bool DeleteStoreRoom(int storeRoomID);

        [OperationContract]
        bool SaveStoreRoom(CommContracts.StoreRoom storeRoom);

        [OperationContract]
        List<CommContracts.SickRoom> GetAllSickRoom(string strName = "");

        [OperationContract]
        bool UpdateSickRoom(CommContracts.SickRoom sickRoom);

        [OperationContract]
        bool SaveSickRoom(CommContracts.SickRoom sickRoom);

        [OperationContract]
        bool DeleteSickRoom(int sickRoomID);


        [OperationContract]
        List<CommContracts.SickBed> GetAllSickBed(string strName = "");

        [OperationContract]
        bool UpdateSickBed(CommContracts.SickBed sickBed);

        [OperationContract]
        bool DeleteSickBed(int jobID);

        [OperationContract]
        bool SaveSickBed(CommContracts.SickBed sickBed);

        [OperationContract]
        List<CommContracts.MaterialItem> GetAllMaterialItem(string strName = "");
        [OperationContract]
        bool UpdateMaterialItem(CommContracts.MaterialItem Material);
        [OperationContract]
        bool SaveMaterialItem(CommContracts.MaterialItem Material);
        [OperationContract]
        bool DeleteMaterialItem(int MaterialID);
        [OperationContract]
        CommContracts.PatientCardPrePay GetPrePay(int Id);
        [OperationContract]
        bool SavePrePay(CommContracts.PatientCardPrePay prePay, ref int prePayID, ref string ErrorMsg);
        [OperationContract]
        List<CommContracts.PatientCardPrePay> GetAllPrePay(int PatientID);

        [OperationContract]
        bool DeletePrePay(int PrePayID);

        [OperationContract]
        string getNewPID();

        [OperationContract]
        string getNewPatientCardNum();

        [OperationContract]
        CommContracts.Patient ReadCurrentPatient(int PatientID);

        [OperationContract]
        CommContracts.Patient ReadCurrentPatientByPatientCardNum(string strPatientCardNum, ref string ErrorMsg);

        [OperationContract]
        decimal GetCurrentPatientBalance(int PatientID);

        [OperationContract]
        List<CommContracts.Patient> GetAllPatient(string strName);
        [OperationContract]
        bool UpdatePatient(CommContracts.Patient Patient, ref string ErrorMsg);
        [OperationContract]
        bool SavePatient(CommContracts.Patient Patient);
        [OperationContract]
        bool DeletePatient(int PatientID);

        [OperationContract]
        List<CommContracts.SignalType> GetAllSignalType(string strName = "");
        [OperationContract]
        bool UpdateSignalType(CommContracts.SignalType SignalType);
        [OperationContract]
        bool SaveSignalType(CommContracts.SignalType SignalType);
        [OperationContract]
        bool DeleteSignalType(int SignalTypeID);



        [OperationContract]
        bool SaveMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore);
        [OperationContract]
        bool RecheckMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore);
        [OperationContract]
        List<CommContracts.MaterialCheckStore> getAllMaterialCheckStore(int StoreID,
                    DateTime StartInStoreTime,
                    DateTime EndInStoreTime,
                    string InStoreNo = "");

        [OperationContract]
        bool SaveMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore);
        [OperationContract]
        bool RecheckMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore);
        [OperationContract]
        List<CommContracts.MaterialOutStore> getAllMaterialOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string OutStoreNo = "");

        [OperationContract]
        bool SaveMaterialInStock(CommContracts.MaterialInStore MaterialInStore);

        [OperationContract]
        bool RecheckMaterialInStock(CommContracts.MaterialInStore MaterialInStore);

        [OperationContract]
        List<CommContracts.MaterialInStore> getAllMaterialInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "");

        [OperationContract]
        bool ReCheckMaterialInStore(CommContracts.MaterialInStore MaterialInStore);

        [OperationContract]
        bool RecheckMaterialOutStore(CommContracts.MaterialOutStore MaterialOutStore);

        [OperationContract]
        bool ReCheckMaterialCheckStore(CommContracts.MaterialCheckStore MaterialCheckStore);

        [OperationContract]
        List<CommContracts.StoreRoomMaterialNum> getAllMaterialItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough);
        // 得到当前物资的合理库存
        [OperationContract]
        List<CommContracts.StoreRoomMaterialNum> GetStoreFromMaterial(int nMaterialID, int nNum);

        // 根据收费单更新物资库存
        [OperationContract]
        bool SubdMaterialStoreNum(CommContracts.MaterialCharge materialCharge);

        [OperationContract]
        bool SaveMaterialCharge(CommContracts.MaterialCharge MaterialCharge);
        [OperationContract]
        List<CommContracts.MaterialCharge> GetAllChargeFromMaterialAdvice(int AdviceID);

        [OperationContract]
        List<CommContracts.MaterialCharge> GetAllClinicMaterialCharge(int RegistrationID);

        [OperationContract]
        List<CommContracts.MaterialCharge> GetAllInHospitalMaterialCharge(int InpatientID);

        [OperationContract]
        bool SaveTherapyCharge(CommContracts.TherapyCharge TherapyCharge);

        [OperationContract]
        List<CommContracts.TherapyCharge> GetAllChargeFromTherapyAdvice(int AdviceID);

        [OperationContract]
        List<CommContracts.TherapyCharge> GetAllClinicTherapyCharge(int RegistrationID);

        [OperationContract]
        List<CommContracts.TherapyCharge> GetAllInHospitalTherapyCharge(int InpatientID);

        [OperationContract]
        bool SaveAssayCharge(CommContracts.AssayCharge AssayCharge);

        [OperationContract]
        List<CommContracts.AssayCharge> GetAllChargeFromAssayAdvice(int AdviceID);

        [OperationContract]
        List<CommContracts.AssayCharge> GetAllClinicAssayCharge(int RegistrationID);

        [OperationContract]
        List<CommContracts.AssayCharge> GetAllInHospitalAssayCharge(int InpatientID);

        [OperationContract]
        bool SaveInspectCharge(CommContracts.InspectCharge InspectCharge);

        [OperationContract]
        List<CommContracts.InspectCharge> GetAllChargeFromInspectAdvice(int AdviceID);

        [OperationContract]
        List<CommContracts.InspectCharge> GetAllClinicInspectCharge(int RegistrationID);

        [OperationContract]
        List<CommContracts.InspectCharge> GetAllInHospitalInspectCharge(int InpatientID);

        [OperationContract]
        bool SaveOtherServiceCharge(CommContracts.OtherServiceCharge OtherServiceCharge);

        [OperationContract]
        List<CommContracts.OtherServiceCharge> GetAllChargeFromOtherServiceAdvice(int AdviceID);

        [OperationContract]
        List<CommContracts.OtherServiceCharge> GetAllClinicOtherServiceCharge(int RegistrationID);
        [OperationContract]
        List<CommContracts.OtherServiceCharge> GetAllInHospitalOtherServiceCharge(int InpatientID);

        [OperationContract]
        bool UpdateChargeStatus(int DoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum);

        [OperationContract]
        bool UpdateExecuteEnum(int DoctorAdviceID, CommContracts.ExecuteEnum executeEnum);

        [OperationContract]
        List<CommContracts.InHospitalApply> GetAllInHospitalApply(CommContracts.InHospitalApplyEnum inHospitalApplyEnum, string strName = "");

        [OperationContract]
        bool SaveInHospitalApply(CommContracts.InHospitalApply InHospitalApply);
        [OperationContract]
        bool DeleteInHospitalApply(int InHospitalApplyID);

        [OperationContract]
        bool UpdateInHospitalApply(CommContracts.InHospitalApply InHospitalApply);

        [OperationContract]
        List<CommContracts.LeaveHospital> GetAllLeaveHospitalList(int EmployeeID = 0, string strName = "");

        [OperationContract]
        bool SaveLeaveHospital(CommContracts.LeaveHospital leaveHospital);

        [OperationContract]
        bool UpdateLeaveHospital(CommContracts.LeaveHospital leaveHospital);

        [OperationContract]
        List<CommContracts.RecallHospital> GetAllRecallHospitalList(int EmployeeID = 0, string strName = "");

        [OperationContract]
        bool SaveRecallHospital(CommContracts.RecallHospital recallHospital);

        [OperationContract]
        bool UpdateRecallHospital(CommContracts.RecallHospital recallHospital);

        [OperationContract]
        bool SaveInjectionBill(CommContracts.InjectionBill injectionBill);

        [OperationContract]
        List<CommContracts.InjectionBill> GetAllInjectionBill(int nRegistrationID);
        [OperationContract]
        List<CommContracts.InjectionBill> GetAllInHospitalInjectionBill(int InHospitalID);

        [OperationContract]
        List<CommContracts.SignalTime> GetAllClinicVistTime(string strName = "");

        [OperationContract]
        bool UpdateClinicVistTime(CommContracts.SignalTime ClinicVistTime);

        [OperationContract]
        bool SaveClinicVistTime(CommContracts.SignalTime ClinicVistTime);

        [OperationContract]
        bool DeleteClinicVistTime(int ClinicVistTimeID);

        [OperationContract]
        List<CommContracts.Employee> GetAllDepartmentEmployee(int DepartmentID);

        [OperationContract]
        List<CommContracts.Employee> GetAllDepartmentDoctor(int DepartmentID);

        [OperationContract]
        List<CommContracts.EmployeeDepartmentHistory> GetAllEmployeeDepartmentHistory(int EmployeeID);
        [OperationContract]
        bool SaveEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory);
        [OperationContract]
        bool DeleteEmployeeDepartmentHistory(int EmployeeDepartmentHistoryID);
        [OperationContract]
        bool UpdateEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory);


        [OperationContract]
        List<CommContracts.Employee> GetAllJobEmployee(int JobID);
        [OperationContract]
        List<CommContracts.EmployeeJobHistory> GetAllEmployeeJobHistory(int EmployeeID);
        [OperationContract]
        bool SaveEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory);
        [OperationContract]
        bool DeleteEmployeeJobHistory(int EmployeeJobHistoryID);
        [OperationContract]
        bool UpdateEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory);

        [OperationContract]
        List<CommContracts.Shift> GetAllShift(string strName = "");

        [OperationContract]
        bool UpdateShift(CommContracts.Shift Shift);

        [OperationContract]
        bool SaveShift(CommContracts.Shift Shift);

        [OperationContract]
        bool DeleteShift(int ShiftID);

        [OperationContract]
        List<CommContracts.WorkType> GetAllWorkType(string strName = "");

        [OperationContract]
        bool UpdateWorkType(CommContracts.WorkType WorkType);

        [OperationContract]
        bool SaveWorkType(CommContracts.WorkType WorkType);

        [OperationContract]
        bool DeleteWorkType(int WorkTypeID);


        [OperationContract]
        List<CommContracts.ClinicMedicalRecordModel> GetAllClinicMedicalRecordModel(string strName);
        [OperationContract]
        bool UpdateClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel);
        [OperationContract]
        bool SaveClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel);
        [OperationContract]
        bool DeleteClinicMedicalRecordModel(int ClinicMedicalRecordModelID);

        [OperationContract]
        List<CommContracts.HospitalMsg> GetAllHospitalMsg(string strName = "");

        [OperationContract]
        bool UpdateHospitalMsg(CommContracts.HospitalMsg HospitalMsg);

        [OperationContract]
        bool SaveHospitalMsg(CommContracts.HospitalMsg HospitalMsg);

        [OperationContract]
        bool DeleteHospitalMsg(int HospitalMsgID);

        [OperationContract]
        List<CommContracts.LevelOneDepartment> GetAllLevelOneDepartment(string strName);
        [OperationContract]
        bool UpdateLevelOneDepartment(CommContracts.LevelOneDepartment LevelOneDepartment);
        [OperationContract]
        bool SaveLevelOneDepartment(CommContracts.LevelOneDepartment LevelOneDepartment);
        [OperationContract]
        bool DeleteLevelOneDepartment(int LevelOneDepartmentID);



        [OperationContract]
        List<CommContracts.DoctorClinicWorkPlan> GetAllDoctorClinicWorkPlan(string strName);
        [OperationContract]
        bool UpdateDoctorClinicWorkPlan(CommContracts.DoctorClinicWorkPlan DoctorClinicWorkPlan);
        [OperationContract]
        bool SaveDoctorClinicWorkPlan(CommContracts.DoctorClinicWorkPlan DoctorClinicWorkPlan);
        [OperationContract]
        bool DeleteDoctorClinicWorkPlan(int DoctorClinicWorkPlanID);



        [OperationContract]
        List<CommContracts.ClinicRegistration> GetAllClinicRegistration(string strName);
        [OperationContract]
        bool UpdateClinicRegistration(CommContracts.ClinicRegistration ClinicRegistration);
        [OperationContract]
        bool SaveClinicRegistration(CommContracts.ClinicRegistration ClinicRegistration);
        [OperationContract]
        bool DeleteClinicRegistration(int ClinicRegistrationID);

        [OperationContract]
        List<CommContracts.DiagnoseItem> GetAllDiagnoseItem(string strName);
        [OperationContract]
        bool UpdateDiagnoseItem(CommContracts.DiagnoseItem DiagnoseItem);
        [OperationContract]
        bool SaveDiagnoseItem(CommContracts.DiagnoseItem DiagnoseItem);
        [OperationContract]
        bool DeleteDiagnoseItem(int DiagnoseItemID);

        [OperationContract]
        List<CommContracts.DoctorAdviceItem> GetAllDoctorAdviceItem(string strName);
        [OperationContract]
        bool UpdateDoctorAdviceItem(CommContracts.DoctorAdviceItem DoctorAdviceItem);
        [OperationContract]
        bool SaveDoctorAdviceItem(CommContracts.DoctorAdviceItem DoctorAdviceItem);
        [OperationContract]
        bool DeleteDoctorAdviceItem(int DoctorAdviceItemID);

        [OperationContract]
        List<CommContracts.Frequency> GetAllFrequency(string strName);
        [OperationContract]
        bool UpdateFrequency(CommContracts.Frequency Frequency);
        [OperationContract]
        bool SaveFrequency(CommContracts.Frequency Frequency);
        [OperationContract]
        bool DeleteFrequency(int FrequencyID);



        [OperationContract]
        List<CommContracts.AdministrationRoute> GetAllAdministrationRoute(string strName);
        [OperationContract]
        bool UpdateAdministrationRoute(CommContracts.AdministrationRoute AdministrationRoute);
        [OperationContract]
        bool SaveAdministrationRoute(CommContracts.AdministrationRoute AdministrationRoute);
        [OperationContract]
        bool DeleteAdministrationRoute(int AdministrationRouteID);


        [OperationContract]
        List<CommContracts.DoctorAdviceDetail> GetAllDoctorAdviceDetail(string strName);
        [OperationContract]
        bool UpdateDoctorAdviceDetail(CommContracts.DoctorAdviceDetail DoctorAdviceDetail);
        [OperationContract]
        bool SaveDoctorAdviceDetail(CommContracts.DoctorAdviceDetail DoctorAdviceDetail);
        [OperationContract]
        bool DeleteDoctorAdviceDetail(int DoctorAdviceDetailID);

        [OperationContract]
        List<CommContracts.ClinicDoctorAdvice> GetAllClinicDoctorAdvice(string strName);
        [OperationContract]
        bool UpdateClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice);
        [OperationContract]
        bool SaveClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice);
        [OperationContract]
        bool DeleteClinicDoctorAdvice(int ClinicDoctorAdviceID);
    }
}
