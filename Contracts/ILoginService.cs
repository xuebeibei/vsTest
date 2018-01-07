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
        bool UserAuthenticate(LoginUser login);

        [OperationContract]
        bool UserLogout(LoginUser login);

        [OperationContract]
        int getAllDepartmentNum();

        [OperationContract]
        List<CommContracts.Department> getALLDepartment();

        [OperationContract]
        List<CommContracts.SignalSource> getALLSignalSource(int DepartmentID, DateTime dateTime, int timeInterval);

        [OperationContract]
        List<DateTime> getAllSignalDate(int DepartmentID);

        [OperationContract]
        List<int> getAllSignalTimeIntival(int DepartmentID);

        [OperationContract]
        string getSignalSourceTip(int DepartmentID, DateTime dateTime, int TimeIntival);

        [OperationContract]
        bool SaveRegistration(Registration registration);

        [OperationContract]
        Dictionary<int, string> getAllRegistration();

        [OperationContract]
        string getPatientBMIMsg(int RegistrationID);

        [OperationContract]
        List<CommContracts.Employee> getAllDoctor();

        [OperationContract]
        List<CommContracts.Medicine> getAllMedicine();

        [OperationContract]
        CommContracts.Medicine GetMedicine(int id);

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
        List<CommContracts.TherapyItem> GetAllTherapyItems(string strName);

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
        List<CommContracts.AssayItem> GetAllAssayItems(string strName);

        [OperationContract]
        List<CommContracts.InspectItem> GetAllInspectItems(string strName);

        [OperationContract]
        Dictionary<int, string> GetAllInPatient();

        [OperationContract]
        string getInPatientBMIMsg(int InpatientID);

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
        List<CommContracts.OtherServiceItem> GetAllOtherServiceItems(string strName);

        [OperationContract]
        List<CommContracts.MaterialItem> GetAllMaterialItems(string strName);

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
    }
}
