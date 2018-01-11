using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommContracts;
using System.Collections;

namespace CommServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“LoginService”。
    public class LoginService : ILoginService
    {
        private MainWindow hostApp;
        public LoginService(MainWindow hostApp)
        {
            this.hostApp = hostApp;
        }

        public bool UserAuthenticate(LoginUser l)
        {
            // 这里调用BLL中的逻辑
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Authenticate();
        }

        public bool UserLogout(LoginUser l)
        {
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Logout();
        }

        public int getAllDepartmentNum()
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getAllDepartmentNum();
        }

        public List<CommContracts.Department> getALLDepartment()
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getALLDepartment();
        }

        public List<CommContracts.SignalSource> getALLSignalSource(int DepartmentID, DateTime dateTime, int timeInterval)
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.getALLSignalSource(DepartmentID, dateTime, timeInterval);
        }

        public List<DateTime> getAllSignalDate(int DepartmentID)
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.getAllSignalDate(DepartmentID);
        }

        public List<int> getAllSignalTimeIntival(int DepartmentID)
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.getAllSignalTimeIntival(DepartmentID);
        }

        public string getSignalSourceTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
            BLL.SignalSource temp = new BLL.SignalSource();
            return temp.getSignalSourceTip(DepartmentID, dateTime, TimeIntival);
        }

        public bool SaveRegistration(Registration registration)
        {
            BLL.Registration temp = new BLL.Registration(registration);
            return temp.SaveRegistration();
        }

        public Dictionary<int, string> getAllRegistration()
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.getAllRegistration();
        }

        public Dictionary<int, string> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        public string getPatientBMIMsg(int RegistrationID)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.getPatientBMIMsg(RegistrationID);
        }

        public List<CommContracts.Employee> getAllDoctor()
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.getAllDoctor();
        }

        public List<CommContracts.Medicine> getAllMedicine()
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.getAllMedicine();
        }

        public CommContracts.Medicine GetMedicine(int id)
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.GetMedicine(id);
        }

        public bool SaveTriage(int nDoctorID, int nRegistrationID)
        {
            BLL.Triage temp = new BLL.Triage();
            return temp.SaveTriage(nDoctorID, nRegistrationID);
        }

        public bool SaveRecipe(CommContracts.Recipe recipe)
        {
            BLL.Recipe temp = new BLL.Recipe();
            return temp.SaveRecipe(recipe);
        }

        public List<CommContracts.Recipe> getAllXiCheng(int RegistrationID)
        {
            BLL.Recipe temp = new BLL.Recipe();
            return temp.getAllXiCheng(RegistrationID);
        }

        public List<CommContracts.Recipe> getAllZhong(int RegistrationID)
        {
            BLL.Recipe temp = new BLL.Recipe();
            return temp.getAllZhong(RegistrationID);
        }

        public CommContracts.MedicalRecord GetMedicalRecord(int id)
        {
            BLL.MedicalRecord temp = new BLL.MedicalRecord();
            return temp.GetMedicalRecord(id);
        }

        public bool SaveMedicalRecord(CommContracts.MedicalRecord medicalRecord)
        {
            BLL.MedicalRecord temp = new BLL.MedicalRecord();
            return temp.SaveMedicalRecord(medicalRecord);
        }

        public CommContracts.Therapy GetTherapy(int Id)
        {
            BLL.Therapy therapy = new BLL.Therapy();
            return therapy.GetTherapy(Id);
        }

        public bool SaveTherapy(CommContracts.Therapy therapy)
        {
            BLL.Therapy temp = new BLL.Therapy();
            return temp.SaveTherapy(therapy);
        }

        public List<CommContracts.TherapyItem> GetAllTherapyItems(string strName)
        {
            BLL.TherapyItem temp = new BLL.TherapyItem();
            return temp.GetAllTherapyItems(strName);
        }

        public CommContracts.Assay GetAssay(int Id)
        {
            BLL.Assay temp = new BLL.Assay();
            return temp.GetAssay(Id);
        }

        public List<CommContracts.Assay> getAllAssay(int RegistrationID)
        {
            BLL.Assay temp = new BLL.Assay();
            return temp.getAllAssay(RegistrationID);
        }

        public bool SaveAssay(CommContracts.Assay assay)
        {
            BLL.Assay temp = new BLL.Assay();
            return temp.SaveAssay(assay);
        }

        public CommContracts.Inspect GetInspect(int Id)
        {
            BLL.Inspect temp = new BLL.Inspect();
            return temp.GetInspect(Id);
        }

        public bool SaveInspect(CommContracts.Inspect inspect)
        {
            BLL.Inspect temp = new BLL.Inspect();
            return temp.SaveInspect(inspect);
        }

        public List<CommContracts.AssayItem> GetAllAssayItems(string strName)
        {
            BLL.AssayItem temp = new BLL.AssayItem();
            return temp.GetAllAssayItems(strName);
        }

        public List<CommContracts.InspectItem> GetAllInspectItems(string strName)
        {
            BLL.InspectItem temp = new BLL.InspectItem();
            return temp.GetAllInspectItems(strName);
        }

        public List<CommContracts.Inspect> getAllInspect(int RegistrationID)
        {
            BLL.Inspect temp = new BLL.Inspect();
            return temp.getAllInspect(RegistrationID);
        }

        public List<CommContracts.Therapy> getAllTherapy(int RegistrationID)
        {
            BLL.Therapy temp = new BLL.Therapy();
            return temp.getAllTherapy(RegistrationID);
        }

        public Dictionary<int, string> GetAllInPatient()
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.GetAllInPatient();
        }

        public string getInPatientBMIMsg(int InpatientID)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.getInPatientBMIMsg(InpatientID);
        }

        public Dictionary<int, string> GetAllInHospitalChargePatient(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.GetAllInHospitalChargePatient(startDate, endDate, strFindName, HavePay);
        }

        public List<CommContracts.Inspect> getAllInHospitalInspect(int InpatientID)
        {
            BLL.Inspect temp = new BLL.Inspect();
            return temp.getAllInHospitalInspect(InpatientID);
        }

        public List<CommContracts.Therapy> getAllInHospitalTherapy(int InpatientID)
        {
            BLL.Therapy temp = new BLL.Therapy();
            return temp.getAllInHospitalTherapy(InpatientID);
        }

        public List<CommContracts.Assay> getAllInHospitalAssay(int InpatientID)
        {
            BLL.Assay temp = new BLL.Assay();
            return temp.getAllInHospitalAssay(InpatientID);
        }

        public List<CommContracts.Recipe> getAllInHospitalXiCheng(int InpatientID)
        {
            BLL.Recipe temp = new BLL.Recipe();
            return temp.getAllInHospitalXiCheng(InpatientID);
        }

        public List<CommContracts.Recipe> getAllInHospitalZhong(int InpatientID)
        {
            BLL.Recipe temp = new BLL.Recipe();
            return temp.getAllInHospitalZhong(InpatientID);
        }

        public CommContracts.MaterialBill GetMaterialBill(int Id)
        {
            BLL.MaterialBill temp = new BLL.MaterialBill();
            return temp.GetMaterialBill(Id);
        }

        public bool SaveMaterialBill(CommContracts.MaterialBill materialBill)
        {
            BLL.MaterialBill temp = new BLL.MaterialBill();
            return temp.SaveMaterialBill(materialBill);
        }

        public List<CommContracts.MaterialBill> getAllMaterialBill(int RegistrationID)
        {
            BLL.MaterialBill temp = new BLL.MaterialBill();
            return temp.getAllMaterialBill(RegistrationID);
        }

        public List<CommContracts.MaterialBill> getAllInHospitalMaterialBill(int InpatientID)
        {
            BLL.MaterialBill temp = new BLL.MaterialBill();
            return temp.getAllInHospitalMaterialBill(InpatientID);
        }

        public CommContracts.OtherService GetOtherService(int Id)
        {
            BLL.OtherService temp = new BLL.OtherService();
            return temp.GetOtherService(Id);
        }

        public bool SaveOtherService(CommContracts.OtherService otherService)
        {
            BLL.OtherService temp = new BLL.OtherService();
            return temp.SaveOtherService(otherService);
        }

        public List<CommContracts.OtherService> getAllOtherService(int RegistrationID)
        {
            BLL.OtherService temp = new BLL.OtherService();
            return temp.getAllOtherService(RegistrationID);
        }

        public List<CommContracts.OtherService> getAllInHospitalOtherService(int InpatientID)
        {
            BLL.OtherService temp = new BLL.OtherService();
            return temp.getAllInHospitalOtherService(InpatientID);
        }

        public List<CommContracts.OtherServiceItem> GetAllOtherServiceItems(string strName)
        {
            BLL.OtherServiceItem temp = new BLL.OtherServiceItem();
            return temp.GetAllOtherServiceItems(strName);
        }

        public List<CommContracts.MaterialItem> GetAllMaterialItems(string strName)
        {
            BLL.MaterialItem temp = new BLL.MaterialItem();
            return temp.GetAllMaterialItems(strName);
        }

        public bool SaveMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            BLL.MedicineInStore temp = new BLL.MedicineInStore();
            return temp.SaveMedicineInStock(medicineInStore);
        }

        public bool RecheckMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            BLL.MedicineInStore temp = new BLL.MedicineInStore();
            return temp.RecheckMedicineInStock(medicineInStore);
        }

        public List<CommContracts.MedicineInStore> getAllMedicineInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            BLL.MedicineInStore temp = new BLL.MedicineInStore();
            return temp.getAllMedicineInStore(StoreID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        public List<CommContracts.Supplier> GetAllSuppliers(string strFindName)
        {
            BLL.Supplier temp = new BLL.Supplier();
            return temp.GetAllSuppliers(strFindName);
        }

        public bool ReCheckMedicineInStore(CommContracts.MedicineInStore medicineInStore)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.ReCheckMedicineInStore(medicineInStore);
        }

        public List<CommContracts.StoreRoomMedicineNum> getAllMedicineItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.getAllMedicineItemNum(StoreID, ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
        }

        public List<CommContracts.MedicineOutStore> getAllMedicineOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string OutStoreNo = "")
        {
            BLL.MedicineOutStore temp = new BLL.MedicineOutStore();
            return temp.getAllMedicineOutStore(StoreID, outStoreEnum, StartInStoreTime, EndInStoreTime, OutStoreNo);
        }

        public bool SaveMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore)
        {
            BLL.MedicineOutStore temp = new BLL.MedicineOutStore();
            return temp.SaveMedicineOutStock(medicineOutStore);
        }

        public bool RecheckMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore)
        {
            BLL.MedicineOutStore temp = new BLL.MedicineOutStore();
            return temp.RecheckMedicineOutStock(medicineOutStore);
        }

        public bool RecheckMedicineOutStore(CommContracts.MedicineOutStore medicineOutStore)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.RecheckMedicineOutStore(medicineOutStore);
        }

        public bool SaveMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            BLL.MedicineCheckStore temp = new BLL.MedicineCheckStore();
            return temp.SaveMedicineCheckStock(medicineCheckStore);
        }

        public bool RecheckMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            BLL.MedicineCheckStore temp = new BLL.MedicineCheckStore();
            return temp.RecheckMedicineCheckStock(medicineCheckStore);
        }

        public List<CommContracts.MedicineCheckStore> getAllMedicineCheckStore(int StoreID,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            BLL.MedicineCheckStore temp = new BLL.MedicineCheckStore();
            return temp.getAllMedicineCheckStore(StoreID, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到当前药品的合理库存
        public List<CommContracts.StoreRoomMedicineNum> GetStoreFromMedicine(int nMedicineID, int nNum)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.GetStoreFromMedicine(nMedicineID, nNum);
        }

        public bool SaveRecipeChargeBill(CommContracts.RecipeChargeBill recipeChargeBill)
        {
            BLL.RecipeChargeBill temp = new BLL.RecipeChargeBill();
            return temp.SaveRecipeChargeBill(recipeChargeBill);
        }
    }
}
