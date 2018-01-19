﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;

namespace CommContracts
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool UserAuthenticate(User login);
        [OperationContract]
        List<CommContracts.User> GetAllLoginUser(string strName = "");
        [OperationContract]
        bool UpdateLoginUser(CommContracts.User job);
        [OperationContract]
        bool SaveLoginUser(CommContracts.User job);
        [OperationContract]
        bool DeleteLoginUser(int jobID);

        [OperationContract]
        bool UserLogout(User login);

        [OperationContract]
        int getAllDepartmentNum();

        [OperationContract]
        List<CommContracts.Department> getALLDepartment(string strName = "");

        [OperationContract]
        bool SaveDepartment(CommContracts.Department department);

        [OperationContract]
        bool UpdateDepartment(CommContracts.Department department);

        [OperationContract]
        bool DeleteDepartment(int departmentID);

        [OperationContract]
        List<CommContracts.SignalSource> getALLSignalSource(int DepartmentID, DateTime dateTime, int timeInterval);

        [OperationContract]
        List<DateTime> getAllSignalDate(int DepartmentID);

        [OperationContract]
        List<int> getAllSignalTimeIntival(int DepartmentID);

        [OperationContract]
        string getSignalSourceTip(int DepartmentID, DateTime dateTime, int TimeIntival);

        [OperationContract]
        bool UpdateSignalSource(int nSignalSourceID);

        [OperationContract]
        bool SaveRegistration(Registration registration);

        [OperationContract]
        Dictionary<int, string> getAllRegistration();

        [OperationContract]
        Dictionary<int, string> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false);

        [OperationContract]
        string getPatientBMIMsg(int RegistrationID);

        [OperationContract]
        List<CommContracts.Employee> getAllDoctor();

        [OperationContract]
        List<CommContracts.Employee> GetAllEmployee(string strName = "");
        [OperationContract]
        bool UpdateEmployee(CommContracts.Employee employee);

        [OperationContract]
        bool SaveEmployee(CommContracts.Employee employee);

        [OperationContract]
        bool DeleteEmployee(int employeeID);

        [OperationContract]
        CommContracts.Medicine GetMedicine(int id);

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
        bool SaveRecipe(CommContracts.Recipe recipe);

        [OperationContract]
        List<CommContracts.Recipe> getAllXiCheng(int RegistrationID);

        [OperationContract]
        List<CommContracts.Recipe> getAllZhong(int RegistrationID);

        [OperationContract]
        CommContracts.MedicalRecord GetMedicalRecord(int id);

        [OperationContract]
        bool SaveMedicalRecord(CommContracts.MedicalRecord medicalRecord);

        [OperationContract]
        CommContracts.Therapy GetTherapy(int Id);

        [OperationContract]
        bool SaveTherapy(CommContracts.Therapy therapy);

        [OperationContract]
        List<CommContracts.TherapyItem> GetAllTherapyItem(string strName);
        [OperationContract]
        bool UpdateTherapyItem(CommContracts.TherapyItem TherapyItem);
        [OperationContract]
        bool SaveTherapyItem(CommContracts.TherapyItem material);
        [OperationContract]
        bool DeleteTherapyItem(int TherapyItemID);

        [OperationContract]
        CommContracts.Assay GetAssay(int Id);

        [OperationContract]
        List<CommContracts.Assay> getAllAssay(int RegistrationID);

        [OperationContract]
        List<CommContracts.Inspect> getAllInspect(int RegistrationID);

        [OperationContract]
        List<CommContracts.Therapy> getAllTherapy(int RegistrationID);

        [OperationContract]
        bool SaveAssay(CommContracts.Assay assay);

        [OperationContract]
        CommContracts.Inspect GetInspect(int Id);

        [OperationContract]
        bool SaveInspect(CommContracts.Inspect inspect);

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
        List<CommContracts.Inpatient> GetAllInPatientList(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, string strName = "");

        [OperationContract]
        string getInPatientBMIMsg(int InpatientID);

        [OperationContract]
        bool SaveInPatient(CommContracts.Inpatient inpatient);

        [OperationContract]
        bool UpdateInPatient(CommContracts.Inpatient inpatient);

        // 读取未入院患者信息，并新建入院登记
        [OperationContract]
        CommContracts.Inpatient ReadNewInPatient(int PatientID);

        // 读取已入院患者信息
        [OperationContract]
        CommContracts.Inpatient ReadCurrentInPatient(int InPatientID);

        // 读取已出院患者信息
        [OperationContract]
        CommContracts.Inpatient ReadLeavedPatient(int InPatientID);

        [OperationContract]
        List<CommContracts.Inspect> getAllInHospitalInspect(int InpatientID);

        [OperationContract]
        List<CommContracts.Therapy> getAllInHospitalTherapy(int InpatientID);

        [OperationContract]
        List<CommContracts.Assay> getAllInHospitalAssay(int InpatientID);

        [OperationContract]
        List<CommContracts.Recipe> getAllInHospitalXiCheng(int InpatientID);

        [OperationContract]
        List<CommContracts.Recipe> getAllInHospitalZhong(int InpatientID);

        [OperationContract]
        bool UpdateChargeStatus(int RecipeID, CommContracts.ChargeStatusEnum chargeStatusEnum);

        [OperationContract]
        CommContracts.MaterialBill GetMaterialBill(int Id);

        [OperationContract]
        bool SaveMaterialBill(CommContracts.MaterialBill materialBill);

        [OperationContract]
        List<CommContracts.MaterialBill> getAllMaterialBill(int RegistrationID);

        [OperationContract]
        List<CommContracts.MaterialBill> getAllInHospitalMaterialBill(int InpatientID);

        [OperationContract]
        CommContracts.OtherService GetOtherService(int Id);

        [OperationContract]
        bool SaveOtherService(CommContracts.OtherService otherService);

        [OperationContract]
        List<CommContracts.OtherService> getAllOtherService(int RegistrationID);

        [OperationContract]
        List<CommContracts.OtherService> getAllInHospitalOtherService(int InpatientID);

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
        // 根据收费单更新库存
        bool SubdStoreNum(CommContracts.RecipeChargeBill recipeChargeBill);

        [OperationContract]
        bool SaveRecipeChargeBill(CommContracts.RecipeChargeBill recipeChargeBill);

        [OperationContract]
        List<CommContracts.RecipeChargeBill> GetAllChargeFromRecipe(int RecipeID);

        [OperationContract]
        List<CommContracts.Job> GetAllJob(string strName = "");

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
    }
}
