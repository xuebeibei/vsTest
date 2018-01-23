using System;
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

        //[OperationContract]
        //bool SaveRecipe(CommContracts.Recipe recipe);

        //[OperationContract]
        //List<CommContracts.Recipe> getAllXiCheng(int RegistrationID);

        //[OperationContract]
        //List<CommContracts.Recipe> getAllZhong(int RegistrationID);

        //[OperationContract]
        //List<CommContracts.Recipe> getAllInHospitalXiCheng(int InpatientID);

        //[OperationContract]
        //List<CommContracts.Recipe> getAllInHospitalZhong(int InpatientID);

        //[OperationContract]
        //bool UpdateChargeStatus(int RecipeID, CommContracts.ChargeStatusEnum chargeStatusEnum);

        [OperationContract]
        // 根据收费单更新库存
        bool SubdStoreNum(CommContracts.RecipeChargeBill recipeChargeBill);

        [OperationContract]
        bool SaveRecipeChargeBill(CommContracts.RecipeChargeBill recipeChargeBill);

        [OperationContract]
        List<CommContracts.RecipeChargeBill> GetAllChargeFromRecipe(int RecipeID);


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
        bool UpdateChargeStatus(int MedicineDoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum);

        //[OperationContract]
        //// 根据收费单更新库存
        //bool SubdStoreNum(CommContracts.MedicineDoctorAdviceChargeBill MedicineDoctorAdviceChargeBill);

        //[OperationContract]
        //bool SaveMedicineDoctorAdviceChargeBill(CommContracts.MedicineDoctorAdviceChargeBill MedicineDoctorAdviceChargeBill);

        //[OperationContract]
        //List<CommContracts.MedicineDoctorAdviceChargeBill> GetAllChargeFromMedicineDoctorAdvice(int MedicineDoctorAdviceID);

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
        CommContracts.PrePay GetPrePay(int Id);
        [OperationContract]
        bool SavePrePay(CommContracts.PrePay prePay);
        [OperationContract]
        List<CommContracts.PrePay> GetAllPrePay(int PatientID);

        [OperationContract]
        bool DeletePrePay(int PrePayID);

        [OperationContract]
        CommContracts.Patient ReadCurrentPatient(int PatientID);
        [OperationContract]
        decimal GetCurrentPatientBalance(int PatientID);
    }
}
