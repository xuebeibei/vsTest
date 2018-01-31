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

        public bool UserAuthenticate(User l)
        {
            // 这里调用BLL中的逻辑
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Authenticate();
        }

        public CommContracts.User getUser(int UserID)
        {
            BLL.Login login = new BLL.Login();
            return login.getUser(UserID);
        }

        public List<CommContracts.User> GetAllLoginUser(string strName = "")
        {
            BLL.Login login = new BLL.Login();
            return login.GetAllLoginUser(strName);
        }

        public bool UpdateLoginUser(CommContracts.User job)
        {
            BLL.Login login = new BLL.Login();
            return login.UpdateLoginUser(job);
        }

        public bool SaveLoginUser(CommContracts.User job)
        {
            BLL.Login login = new BLL.Login();
            return login.SaveLoginUser(job);
        }

        public bool DeleteLoginUser(int jobID)
        {
            BLL.Login login = new BLL.Login();
            return login.DeleteLoginUser(jobID);
        }

        public bool UserLogout(User l)
        {
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Logout();
        }

        public int getAllDepartmentNum()
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getAllDepartmentNum();
        }

        public List<CommContracts.Department> getALLDepartment(CommContracts.DepartmentEnum departmentEnum)
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getALLDepartment(departmentEnum);
        }

        public List<CommContracts.Department> getALLDepartmentByName(string strName = "")
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getALLDepartment(strName);
        }

        public bool SaveDepartment(CommContracts.Department department)
        {
            BLL.Department temp = new BLL.Department();
            return temp.SaveDepartment(department);
        }

        public bool UpdateDepartment(CommContracts.Department department)
        {
            BLL.Department temp = new BLL.Department();
            return temp.UpdateDepartment(department);
        }

        public bool DeleteDepartment(int departmentID)
        {
            BLL.Department temp = new BLL.Department();
            return temp.DeleteDepartment(departmentID);
        }

        public List<CommContracts.SignalSource> GetAllSignalSource()
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.GetAllSignalSource();
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

        public bool UpdateSignalSource(int nSignalSourceID)
        {
            BLL.SignalSource temp = new BLL.SignalSource();
            return temp.UpdateSignalSource(nSignalSourceID);
        }
        public bool SaveSignalSourceList(List<CommContracts.SignalSource> list)
        {
            BLL.SignalSource temp = new BLL.SignalSource();
            return temp.SaveSignalSourceList(list);
        }
        public List<CommContracts.SignalSource> GetSignalSourceList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            BLL.SignalSource temp = new BLL.SignalSource();
            return temp.GetSignalSourceList(DepartmentID, EmployeeID, startDate, endDate);
        }

        public bool SaveRegistration(Registration registration)
        {
            BLL.Registration temp = new BLL.Registration(registration);
            return temp.SaveRegistration();
        }

        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.UpdateRegistration(registration);
        }

        public List<CommContracts.Registration> getAllRegistration(int EmployeeID = 0, DateTime? VistTime = null)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.getAllRegistration(EmployeeID, VistTime);
        }

        public List<CommContracts.Registration> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        public string getPatientBMIMsg(int RegistrationID)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.getPatientBMIMsg(RegistrationID);
        }
        public List<CommContracts.Registration> GetDepartmentRegistrationList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.GetDepartmentRegistrationList(DepartmentID, EmployeeID, startDate, endDate);
        }

        public List<CommContracts.Employee> getAllDoctor(int DepartmentID)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.getAllDoctor(DepartmentID);
        }


        public List<CommContracts.Employee> GetAllEmployee(string strName = "")
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.GetAllEmployee(strName);
        }

        public bool UpdateEmployee(CommContracts.Employee employee)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.UpdateEmployee(employee);
        }

        public bool SaveEmployee(CommContracts.Employee employee)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.SaveEmployee(employee);
        }

        public bool DeleteEmployee(int employeeID)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.DeleteEmployee(employeeID);
        }

        public CommContracts.Medicine GetMedicine(int id)
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.GetMedicine(id);
        }

        public List<CommContracts.Medicine> GetOneTypeMedicine(CommContracts.MedicineTypeEnum medicineTypeEnum, string strName = "")
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.GetAllMedicine(medicineTypeEnum, strName);
        }

        public List<CommContracts.Medicine> GetAllXiChengMedicine(string strName = "")
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.GetAllXiChengMedicine(strName);
        }

        public List<CommContracts.Medicine> GetAllMedicine(string strName = "")
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.GetAllMedicine(strName);
        }

        public bool UpdateMedicine(CommContracts.Medicine Medicine)
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.UpdateMedicine(Medicine);
        }

        public bool SaveMedicine(CommContracts.Medicine Medicine)
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.SaveMedicine(Medicine);
        }

        public bool DeleteMedicine(int MedicineID)
        {
            BLL.Medicine temp = new BLL.Medicine();
            return temp.DeleteMedicine(MedicineID);
        }

        public bool SaveTriage(int nDoctorID, int nRegistrationID)
        {
            BLL.Triage temp = new BLL.Triage();
            return temp.SaveTriage(nDoctorID, nRegistrationID);
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

        public CommContracts.TherapyDoctorAdvice GetTherapyDoctorAdvice(int Id)
        {
            BLL.TherapyDoctorAdvice therapy = new BLL.TherapyDoctorAdvice();
            return therapy.GetTherapy(Id);
        }

        public bool SaveTherapyDoctorAdvice(CommContracts.TherapyDoctorAdvice therapy)
        {
            BLL.TherapyDoctorAdvice temp = new BLL.TherapyDoctorAdvice();
            return temp.SaveTherapy(therapy);
        }

        public List<CommContracts.TherapyItem> GetAllTherapyItem(string strName)
        {
            BLL.TherapyItem temp = new BLL.TherapyItem();
            return temp.GetAllTherapyItem(strName);
        }

        public bool UpdateTherapyItem(CommContracts.TherapyItem TherapyItem)
        {
            BLL.TherapyItem temp = new BLL.TherapyItem();
            return temp.UpdateTherapyItem(TherapyItem);
        }

        public bool SaveTherapyItem(CommContracts.TherapyItem material)
        {
            BLL.TherapyItem temp = new BLL.TherapyItem();
            return temp.SaveTherapyItem(material);
        }

        public bool DeleteTherapyItem(int TherapyItemID)
        {
            BLL.TherapyItem temp = new BLL.TherapyItem();
            return temp.DeleteTherapyItem(TherapyItemID);
        }

        public CommContracts.AssayDoctorAdvice GetAssayDoctorAdvice(int Id)
        {
            BLL.AssayDoctorAdvice temp = new BLL.AssayDoctorAdvice();
            return temp.GetAssayDoctorAdvice(Id);
        }

        public List<CommContracts.AssayDoctorAdvice> getAllAssayDoctorAdvice(int RegistrationID)
        {
            BLL.AssayDoctorAdvice temp = new BLL.AssayDoctorAdvice();
            return temp.getAllAssayDoctorAdvice(RegistrationID);
        }

        public bool SaveAssayDoctorAdvice(CommContracts.AssayDoctorAdvice assay)
        {
            BLL.AssayDoctorAdvice temp = new BLL.AssayDoctorAdvice();
            return temp.SaveAssayDoctorAdvice(assay);
        }

        public CommContracts.InspectDoctorAdvice GetInspectDoctorAdvice(int Id)
        {
            BLL.InspectDoctorAdvice temp = new BLL.InspectDoctorAdvice();
            return temp.GetInspectDoctorAdvice(Id);
        }

        public bool SaveInspectDoctorAdvice(CommContracts.InspectDoctorAdvice inspect)
        {
            BLL.InspectDoctorAdvice temp = new BLL.InspectDoctorAdvice();
            return temp.SaveInspectDoctorAdvice(inspect);
        }

        public List<CommContracts.AssayItem> GetAllAssayItem(string strName)
        {
            BLL.AssayItem temp = new BLL.AssayItem();
            return temp.GetAllAssayItem(strName);
        }

        public bool UpdateAssayItem(CommContracts.AssayItem AssayItem)
        {
            BLL.AssayItem temp = new BLL.AssayItem();
            return temp.UpdateAssayItem(AssayItem);
        }

        public bool SaveAssayItem(CommContracts.AssayItem AssayItem)
        {
            BLL.AssayItem temp = new BLL.AssayItem();
            return temp.SaveAssayItem(AssayItem);
        }

        public bool DeleteAssayItem(int AssayItemID)
        {
            BLL.AssayItem temp = new BLL.AssayItem();
            return temp.DeleteAssayItem(AssayItemID);
        }

        public List<CommContracts.InspectItem> GetAllInspectItem(string strName = "")
        {
            BLL.InspectItem temp = new BLL.InspectItem();
            return temp.GetAllInspectItem(strName);
        }

        public bool UpdateInspectItem(CommContracts.InspectItem InspectItem)
        {
            BLL.InspectItem temp = new BLL.InspectItem();
            return temp.UpdateInspectItem(InspectItem);
        }

        public bool SaveInspectItem(CommContracts.InspectItem material)
        {
            BLL.InspectItem temp = new BLL.InspectItem();
            return temp.SaveInspectItem(material);
        }

        public bool DeleteInspectItem(int InspectItemID)
        {
            BLL.InspectItem temp = new BLL.InspectItem();
            return temp.DeleteInspectItem(InspectItemID);
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInspectDoctorAdvice(int RegistrationID)
        {
            BLL.InspectDoctorAdvice temp = new BLL.InspectDoctorAdvice();
            return temp.getAllInspectDoctorAdvice(RegistrationID);
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllTherapyDoctorAdvice(int RegistrationID)
        {
            BLL.TherapyDoctorAdvice temp = new BLL.TherapyDoctorAdvice();
            return temp.getAllTherapy(RegistrationID);
        }

        public List<CommContracts.Inpatient> GetAllInPatientList(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, string strName = "")
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.GetAllInPatientList(inHospitalStatusEnum, strName);
        }

        public string getInPatientBMIMsg(int InpatientID)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.getInPatientBMIMsg(InpatientID);
        }

        public bool SaveInPatient(CommContracts.Inpatient inpatient)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.SaveInPatient(inpatient);
        }

        public bool UpdateInPatient(CommContracts.Inpatient inpatient)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.UpdateInPatient(inpatient);
        }

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.Inpatient ReadNewInPatient(int PatientID)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.ReadNewInPatient(PatientID);
        }

        // 读取已入院患者信息
        public CommContracts.Inpatient ReadCurrentInPatient(int InPatientID)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.ReadCurrentInPatient(InPatientID);
        }

        // 读取已出院患者信息
        public CommContracts.Inpatient ReadLeavedPatient(int InPatientID)
        {
            BLL.Inpatient temp = new BLL.Inpatient();
            return temp.ReadLeavedPatient(InPatientID);
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInHospitalInspect(int InpatientID)
        {
            BLL.InspectDoctorAdvice temp = new BLL.InspectDoctorAdvice();
            return temp.getAllInHospitalInspectDoctorAdvice(InpatientID);
        }

        public bool UpdateInspectChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.InspectDoctorAdvice temp = new BLL.InspectDoctorAdvice();
            return temp.UpdateInspectChargeStatus(AdviceID, chargeStatusEnum);
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllInHospitalTherapyDoctorAdvice(int InpatientID)
        {
            BLL.TherapyDoctorAdvice temp = new BLL.TherapyDoctorAdvice();
            return temp.getAllInHospitalTherapyDoctorAdvice(InpatientID);
        }
        public bool UpdateTherapyChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.TherapyDoctorAdvice temp = new BLL.TherapyDoctorAdvice();
            return temp.UpdateTherapyChargeStatus(AdviceID, chargeStatusEnum);
        }

        public List<CommContracts.AssayDoctorAdvice> getAllInHospitalAssayDoctorAdvice(int InpatientID)
        {
            BLL.AssayDoctorAdvice temp = new BLL.AssayDoctorAdvice();
            return temp.getAllInHospitalAssayDoctorAdvice(InpatientID);
        }

        public bool UpdateAssayChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.AssayDoctorAdvice temp = new BLL.AssayDoctorAdvice();
            return temp.UpdateAssayChargeStatus(AdviceID, chargeStatusEnum);
        }

        //public List<CommContracts.Recipe> getAllInHospitalXiCheng(int InpatientID)
        //{
        //    BLL.Recipe temp = new BLL.Recipe();
        //    return temp.getAllInHospitalXiCheng(InpatientID);
        //}

        //public List<CommContracts.Recipe> getAllInHospitalZhong(int InpatientID)
        //{
        //    BLL.Recipe temp = new BLL.Recipe();
        //    return temp.getAllInHospitalZhong(InpatientID);
        //}

        //public bool UpdateChargeStatus(int RecipeID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        //{
        //    BLL.Recipe temp = new BLL.Recipe();
        //    return temp.UpdateChargeStatus(RecipeID, chargeStatusEnum);
        //}


        public CommContracts.MaterialDoctorAdvice GetMaterialDoctorAdvice(int Id)
        {
            BLL.MaterialDoctorAdvice temp = new BLL.MaterialDoctorAdvice();
            return temp.GetMaterialDoctorAdvice(Id);
        }

        public bool SaveMaterialDoctorAdvice(CommContracts.MaterialDoctorAdvice MaterialDoctorAdvice)
        {
            BLL.MaterialDoctorAdvice temp = new BLL.MaterialDoctorAdvice();
            return temp.SaveMaterialDoctorAdvice(MaterialDoctorAdvice);
        }

        public List<CommContracts.MaterialDoctorAdvice> getAllMaterialDoctorAdvice(int RegistrationID)
        {
            BLL.MaterialDoctorAdvice temp = new BLL.MaterialDoctorAdvice();
            return temp.getAllMaterialDoctorAdvice(RegistrationID);
        }

        public List<CommContracts.MaterialDoctorAdvice> getAllInHospitalMaterialDoctorAdvice(int InpatientID)
        {
            BLL.MaterialDoctorAdvice temp = new BLL.MaterialDoctorAdvice();
            return temp.getAllInHospitalMaterialDoctorAdvice(InpatientID);
        }

        public bool UpdateMaterialChargeStatus(int MaterialDoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.MaterialDoctorAdvice temp = new BLL.MaterialDoctorAdvice();
            return temp.UpdateMaterialChargeStatus(MaterialDoctorAdviceID, chargeStatusEnum);
        }
        public CommContracts.OtherServiceDoctorAdvice GetOtherService(int Id)
        {
            BLL.OtherServiceDoctorAdvice temp = new BLL.OtherServiceDoctorAdvice();
            return temp.GetOtherService(Id);
        }

        public bool SaveOtherService(CommContracts.OtherServiceDoctorAdvice otherService)
        {
            BLL.OtherServiceDoctorAdvice temp = new BLL.OtherServiceDoctorAdvice();
            return temp.SaveOtherService(otherService);
        }

        public List<CommContracts.OtherServiceDoctorAdvice> getAllOtherService(int RegistrationID)
        {
            BLL.OtherServiceDoctorAdvice temp = new BLL.OtherServiceDoctorAdvice();
            return temp.getAllOtherService(RegistrationID);
        }

        public List<CommContracts.OtherServiceDoctorAdvice> getAllInHospitalOtherService(int InpatientID)
        {
            BLL.OtherServiceDoctorAdvice temp = new BLL.OtherServiceDoctorAdvice();
            return temp.getAllInHospitalOtherService(InpatientID);
        }

        public bool UpdateOtherServiceChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.OtherServiceDoctorAdvice temp = new BLL.OtherServiceDoctorAdvice();
            return temp.UpdateOtherServiceChargeStatus(AdviceID, chargeStatusEnum);
        }

        public List<CommContracts.OtherServiceItem> GetAllOtherServiceItem(string strName)
        {
            BLL.OtherServiceItem temp = new BLL.OtherServiceItem();
            return temp.GetAllOtherServiceItems(strName);
        }

        public bool UpdateOtherServiceItem(CommContracts.OtherServiceItem OtherServiceItem)
        {
            BLL.OtherServiceItem temp = new BLL.OtherServiceItem();
            return temp.UpdateOtherServiceItem(OtherServiceItem);
        }

        public bool SaveOtherServiceItem(CommContracts.OtherServiceItem material)
        {
            BLL.OtherServiceItem temp = new BLL.OtherServiceItem();
            return temp.SaveOtherServiceItem(material);
        }

        public bool DeleteOtherServiceItem(int OtherServiceItemID)
        {
            BLL.OtherServiceItem temp = new BLL.OtherServiceItem();
            return temp.DeleteOtherServiceItem(OtherServiceItemID);
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

        public bool UpdateSupplier(CommContracts.Supplier supplier)
        {
            BLL.Supplier temp = new BLL.Supplier();
            return temp.UpdateSupplier(supplier);
        }

        public bool SaveSupplier(CommContracts.Supplier supplier)
        {
            BLL.Supplier temp = new BLL.Supplier();
            return temp.SaveSupplier(supplier);
        }

        public bool DeleteSupplier(int supplierID)
        {
            BLL.Supplier temp = new BLL.Supplier();
            return temp.DeleteSupplier(supplierID);
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
        public bool ReCheckMedicineCheckStore(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.ReCheckMedicineCheckStore(medicineCheckStore);
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

        // 根据收费单更新库存， 将要废弃
        public bool SubdMedicineStoreNum(CommContracts.RecipeChargeBill recipeChargeBill)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.SubdMedicineStoreNum(recipeChargeBill);
        }

        // 根据收费单更新库存
        public bool SubdMedicineStoreNumByAdvice(CommContracts.MedicineCharge medicineCharge)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.SubdMedicineStoreNumByAdvice(medicineCharge);
        }

        

        public bool SaveRecipeChargeBill(CommContracts.RecipeChargeBill recipeChargeBill)
        {
            BLL.RecipeChargeBill temp = new BLL.RecipeChargeBill();
            return temp.SaveRecipeChargeBill(recipeChargeBill);
        }

        public List<CommContracts.RecipeChargeBill> GetAllChargeFromRecipe(int RecipeID)
        {
            BLL.RecipeChargeBill temp = new BLL.RecipeChargeBill();
            return temp.GetAllChargeFromRecipe(RecipeID);
        }

        public bool SaveMedicineCharge(CommContracts.MedicineCharge MedicineCharge)
        {
            BLL.MedicineCharge temp = new BLL.MedicineCharge();
            return temp.SaveMedicineCharge(MedicineCharge);
        }

        public List<CommContracts.MedicineCharge> GetAllChargeFromMedicineAdvice(int AdviceID)
        {
            BLL.MedicineCharge temp = new BLL.MedicineCharge();
            return temp.GetAllChargeFromMedicineAdvice(AdviceID);
        }

        public List<CommContracts.Job> GetAllJob(string strName = "")
        {
            BLL.Job temp = new BLL.Job();
            return temp.GetAllJob(strName);
        }

        public bool UpdateJob(CommContracts.Job job)
        {
            BLL.Job temp = new BLL.Job();
            return temp.UpdateJob(job);
        }

        public bool DeleteJob(int jobID)
        {
            BLL.Job temp = new BLL.Job();
            return temp.DeleteJob(jobID);
        }

        public bool SaveJob(CommContracts.Job job)
        {
            BLL.Job temp = new BLL.Job();
            return temp.SaveJob(job);
        }


        public List<CommContracts.StoreRoom> GetAllStoreRoom(string strName = "")
        {
            BLL.StoreRoom temp = new BLL.StoreRoom();
            return temp.GetAllStoreRoom(strName);
        }

        public bool UpdateStoreRoom(CommContracts.StoreRoom storeRoom)
        {
            BLL.StoreRoom temp = new BLL.StoreRoom();
            return temp.UpdateStoreRoom(storeRoom);
        }

        public bool DeleteStoreRoom(int storeRoomID)
        {
            BLL.StoreRoom temp = new BLL.StoreRoom();
            return temp.DeleteStoreRoom(storeRoomID);
        }

        public bool SaveStoreRoom(CommContracts.StoreRoom storeRoom)
        {
            BLL.StoreRoom temp = new BLL.StoreRoom();
            return temp.SaveStoreRoom(storeRoom);
        }

        public List<CommContracts.SickRoom> GetAllSickRoom(string strName = "")
        {
            BLL.SickRoom temp = new BLL.SickRoom();
            return temp.GetAllSickRoom(strName);
        }

        public bool UpdateSickRoom(CommContracts.SickRoom sickRoom)
        {
            BLL.SickRoom temp = new BLL.SickRoom();
            return temp.UpdateSickRoom(sickRoom);
        }

        public bool SaveSickRoom(CommContracts.SickRoom sickRoom)
        {
            BLL.SickRoom temp = new BLL.SickRoom();
            return temp.SaveSickRoom(sickRoom);
        }

        public bool DeleteSickRoom(int sickRoomID)
        {
            BLL.SickRoom temp = new BLL.SickRoom();
            return temp.DeleteSickRoom(sickRoomID);
        }

        public List<CommContracts.SickBed> GetAllSickBed(string strName = "")
        {
            BLL.SickBed temp = new BLL.SickBed();
            return temp.GetAllSickBed(strName);
        }

        public bool UpdateSickBed(CommContracts.SickBed sickBed)
        {
            BLL.SickBed temp = new BLL.SickBed();
            return temp.UpdateSickBed(sickBed);
        }

        public bool DeleteSickBed(int jobID)
        {
            BLL.SickBed temp = new BLL.SickBed();
            return temp.DeleteSickBed(jobID);
        }

        public bool SaveSickBed(CommContracts.SickBed sickBed)
        {
            BLL.SickBed temp = new BLL.SickBed();
            return temp.SaveSickBed(sickBed);
        }

        public List<CommContracts.MaterialItem> GetAllMaterialItem(string strName = "")
        {
            BLL.MaterialItem temp = new BLL.MaterialItem();
            return temp.GetAllMaterialItem(strName);
        }

        public bool UpdateMaterialItem(CommContracts.MaterialItem Material)
        {
            BLL.MaterialItem temp = new BLL.MaterialItem();
            return temp.UpdateMaterialItem(Material);
        }

        public bool SaveMaterialItem(CommContracts.MaterialItem Material)
        {
            BLL.MaterialItem temp = new BLL.MaterialItem();
            return temp.SaveMaterialItem(Material);
        }

        public bool DeleteMaterialItem(int MaterialID)
        {
            BLL.MaterialItem temp = new BLL.MaterialItem();
            return temp.DeleteMaterialItem(MaterialID);
        }

        public CommContracts.PrePay GetPrePay(int Id)
        {
            BLL.PrePay temp = new BLL.PrePay();
            return temp.GetPrePay(Id);
        }

        public bool SavePrePay(CommContracts.PrePay prePay)
        {
            BLL.PrePay temp = new BLL.PrePay();
            return temp.SavePrePay(prePay);
        }

        public List<CommContracts.PrePay> GetAllPrePay(int PatientID)
        {
            BLL.PrePay temp = new BLL.PrePay();
            return temp.GetAllPrePay(PatientID);
        }

        public bool DeletePrePay(int PrePayID)
        {
            BLL.PrePay temp = new BLL.PrePay();
            return temp.DeletePrePay(PrePayID);
        }

        public CommContracts.Patient ReadCurrentPatient(int PatientID)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.ReadCurrentPatient(PatientID);
        }

        public decimal GetCurrentPatientBalance(int PatientID)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.GetCurrentPatientBalance(PatientID);
        }


        public bool SaveMedicineDoctorAdvice(CommContracts.MedicineDoctorAdvice MedicineDoctorAdvice)
        {
            BLL.MedicineDoctorAdvice temp = new BLL.MedicineDoctorAdvice();
            return temp.SaveMedicineDoctorAdvice(MedicineDoctorAdvice);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllXiCheng(int RegistrationID)
        {
            BLL.MedicineDoctorAdvice temp = new BLL.MedicineDoctorAdvice();
            return temp.getAllXiCheng(RegistrationID);
        }


        public List<CommContracts.MedicineDoctorAdvice> getAllZhong(int RegistrationID)
        {
            BLL.MedicineDoctorAdvice temp = new BLL.MedicineDoctorAdvice();
            return temp.getAllZhong(RegistrationID);
        }


        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalXiCheng(int InpatientID)
        {
            BLL.MedicineDoctorAdvice temp = new BLL.MedicineDoctorAdvice();
            return temp.getAllInHospitalXiCheng(InpatientID);
        }


        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalZhong(int InpatientID)
        {
            BLL.MedicineDoctorAdvice temp = new BLL.MedicineDoctorAdvice();
            return temp.getAllInHospitalZhong(InpatientID);
        }


        public bool UpdateMedicineChargeStatus(int MedicineDoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.MedicineDoctorAdvice temp = new BLL.MedicineDoctorAdvice();
            return temp.UpdateChargeStatus(MedicineDoctorAdviceID, chargeStatusEnum);
        }

        public List<CommContracts.MedicineCharge> GetAllClinicMedicineCharge(int RegistrationID)
        {
            BLL.MedicineCharge temp = new BLL.MedicineCharge();
            return temp.GetAllClinicMedicineCharge(RegistrationID);
        }

        public List<CommContracts.MedicineCharge> GetAllInHospitalMedicineCharge(int InpatientID)
        {
            BLL.MedicineCharge temp = new BLL.MedicineCharge();
            return temp.GetAllInHospitalMedicineCharge(InpatientID);
        }

        public List<CommContracts.SignalItem> GetAllSignalItem(string strName = "")
        {
            BLL.SignalItem temp = new BLL.SignalItem();
            return temp.GetAllSignalItem(strName);
        }

        public bool UpdateSignalItem(CommContracts.SignalItem signalItem)
        {
            BLL.SignalItem temp = new BLL.SignalItem();
            return temp.UpdateSignalItem(signalItem);
        }

        public bool SaveSignalItem(CommContracts.SignalItem signalItem)
        {
            BLL.SignalItem temp = new BLL.SignalItem();
            return temp.SaveSignalItem(signalItem);
        }

        public bool DeleteSignalItem(int signalItemID)
        {
            BLL.SignalItem temp = new BLL.SignalItem();
            return temp.DeleteSignalItem(signalItemID);
        }

        public List<CommContracts.Patient> GetAllPatient(string strName = "")
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.GetAllPatient(strName);
        }

        public bool UpdatePatient(CommContracts.Patient patient)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.UpdatePatient(patient);
        }

        public bool SavePatient(CommContracts.Patient patient)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.SavePatient(patient);
        }

        public bool DeletePatient(int PatientID)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.DeletePatient(PatientID);
        }

        // 查找某个患者最后一次挂号情况
        public CommContracts.Registration ReadLastRegistration(int PatientID, DateTime? DateTime = null)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.ReadLastRegistration(PatientID, DateTime);
        }

        public bool SaveMaterialInStock(CommContracts.MaterialInStore MaterialInStore)
        {
            BLL.MaterialInStore temp = new BLL.MaterialInStore();
            return temp.SaveMaterialInStock(MaterialInStore);
        }

        public bool RecheckMaterialInStock(CommContracts.MaterialInStore MaterialInStore)
        {
            BLL.MaterialInStore temp = new BLL.MaterialInStore();
            return temp.RecheckMaterialInStock(MaterialInStore);
        }

        public List<CommContracts.MaterialInStore> getAllMaterialInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            BLL.MaterialInStore temp = new BLL.MaterialInStore();
            return temp.getAllMaterialInStore(StoreID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        public bool SaveMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore)
        {
            BLL.MaterialOutStore temp = new BLL.MaterialOutStore();
            return temp.SaveMaterialOutStock(MaterialOutStore);
        }

        public bool RecheckMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore)
        {
            BLL.MaterialOutStore temp = new BLL.MaterialOutStore();
            return temp.RecheckMaterialOutStock(MaterialOutStore);
        }

        public List<CommContracts.MaterialOutStore> getAllMaterialOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string OutStoreNo = "")
        {
            BLL.MaterialOutStore temp = new BLL.MaterialOutStore();
            return temp.getAllMaterialOutStore(StoreID, outStoreEnum, StartInStoreTime, EndInStoreTime, OutStoreNo);
        }

        public bool SaveMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            BLL.MaterialCheckStore temp = new BLL.MaterialCheckStore();
            return temp.SaveMaterialCheckStock(MaterialCheckStore);
        }

        public bool RecheckMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            BLL.MaterialCheckStore temp = new BLL.MaterialCheckStore();
            return temp.RecheckMaterialCheckStock(MaterialCheckStore);
        }

        public List<CommContracts.MaterialCheckStore> getAllMaterialCheckStore(int StoreID,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            BLL.MaterialCheckStore temp = new BLL.MaterialCheckStore();
            return temp.getAllMaterialCheckStore(StoreID, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        public bool ReCheckMaterialInStore(CommContracts.MaterialInStore MaterialInStore)
        {
            BLL.StoreRoomMaterialNum temp = new BLL.StoreRoomMaterialNum();
            return temp.ReCheckMaterialInStore(MaterialInStore);
        }

        public bool RecheckMaterialOutStore(CommContracts.MaterialOutStore MaterialOutStore)
        {
            BLL.StoreRoomMaterialNum temp = new BLL.StoreRoomMaterialNum();
            return temp.RecheckMaterialOutStore(MaterialOutStore);
        }

        public bool ReCheckMaterialCheckStore(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            BLL.StoreRoomMaterialNum temp = new BLL.StoreRoomMaterialNum();
            return temp.ReCheckMaterialCheckStore(MaterialCheckStore);
        }

        public List<CommContracts.StoreRoomMaterialNum> getAllMaterialItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            BLL.StoreRoomMaterialNum temp = new BLL.StoreRoomMaterialNum();
            return temp.getAllMaterialItemNum(StoreID, ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
        }

        // 得到当前物资的合理库存
        public List<CommContracts.StoreRoomMaterialNum> GetStoreFromMaterial(int nMaterialID, int nNum)
        {
            BLL.StoreRoomMaterialNum temp = new BLL.StoreRoomMaterialNum();
            return temp.GetStoreFromMaterial(nMaterialID, nNum);
        }

        // 根据收费单更新物资库存
        public bool SubdMaterialStoreNum(CommContracts.MaterialCharge materialCharge)
        {
            BLL.StoreRoomMaterialNum temp = new BLL.StoreRoomMaterialNum();
            return temp.SubdMaterialStoreNum(materialCharge);
        }

        public bool SaveMaterialCharge(CommContracts.MaterialCharge MaterialCharge)
        {
            BLL.MaterialCharge temp = new BLL.MaterialCharge();
            return temp.SaveMaterialCharge(MaterialCharge);
        }

        public List<CommContracts.MaterialCharge> GetAllChargeFromMaterialAdvice(int AdviceID)
        {
            BLL.MaterialCharge temp = new BLL.MaterialCharge();
            return temp.GetAllChargeFromMaterialAdvice(AdviceID);
        }

        public List<CommContracts.MaterialCharge> GetAllClinicMaterialCharge(int RegistrationID)
        {
            BLL.MaterialCharge temp = new BLL.MaterialCharge();
            return temp.GetAllClinicMaterialCharge(RegistrationID);
        }

        public List<CommContracts.MaterialCharge> GetAllInHospitalMaterialCharge(int InpatientID)
        {
            BLL.MaterialCharge temp = new BLL.MaterialCharge();
            return temp.GetAllInHospitalMaterialCharge(InpatientID);
        }

        public bool SaveTherapyCharge(CommContracts.TherapyCharge TherapyCharge)
        {
            BLL.TherapyCharge temp = new BLL.TherapyCharge();
            return temp.SaveTherapyCharge(TherapyCharge);
        }

        public List<CommContracts.TherapyCharge> GetAllChargeFromTherapyAdvice(int AdviceID)
        {
            BLL.TherapyCharge temp = new BLL.TherapyCharge();
            return temp.GetAllChargeFromTherapyAdvice(AdviceID);
        }

        public List<CommContracts.TherapyCharge> GetAllClinicTherapyCharge(int RegistrationID)
        {
            BLL.TherapyCharge temp = new BLL.TherapyCharge();
            return temp.GetAllClinicTherapyCharge(RegistrationID);
        }

        public List<CommContracts.TherapyCharge> GetAllInHospitalTherapyCharge(int InpatientID)
        {
            BLL.TherapyCharge temp = new BLL.TherapyCharge();
            return temp.GetAllInHospitalTherapyCharge(InpatientID);
        }

        public bool SaveAssayCharge(CommContracts.AssayCharge AssayCharge)
        {
            BLL.AssayCharge temp = new BLL.AssayCharge();
            return temp.SaveAssayCharge(AssayCharge);
        }

        public List<CommContracts.AssayCharge> GetAllChargeFromAssayAdvice(int AdviceID)
        {
            BLL.AssayCharge temp = new BLL.AssayCharge();
            return temp.GetAllChargeFromAssayAdvice(AdviceID);
        }

        public List<CommContracts.AssayCharge> GetAllClinicAssayCharge(int RegistrationID)
        {
            BLL.AssayCharge temp = new BLL.AssayCharge();
            return temp.GetAllClinicAssayCharge(RegistrationID);
        }

        public List<CommContracts.AssayCharge> GetAllInHospitalAssayCharge(int InpatientID)
        {
            BLL.AssayCharge temp = new BLL.AssayCharge();
            return temp.GetAllInHospitalAssayCharge(InpatientID);
        }

        public bool SaveInspectCharge(CommContracts.InspectCharge InspectCharge)
        {
            BLL.InspectCharge temp = new BLL.InspectCharge();
            return temp.SaveInspectCharge(InspectCharge);
        }

        public List<CommContracts.InspectCharge> GetAllChargeFromInspectAdvice(int AdviceID)
        {
            BLL.InspectCharge temp = new BLL.InspectCharge();
            return temp.GetAllChargeFromInspectAdvice(AdviceID);
        }

        public List<CommContracts.InspectCharge> GetAllClinicInspectCharge(int RegistrationID)
        {
            BLL.InspectCharge temp = new BLL.InspectCharge();
            return temp.GetAllClinicInspectCharge(RegistrationID);
        }

        public List<CommContracts.InspectCharge> GetAllInHospitalInspectCharge(int InpatientID)
        {
            BLL.InspectCharge temp = new BLL.InspectCharge();
            return temp.GetAllInHospitalInspectCharge(InpatientID);
        }

        public bool SaveOtherServiceCharge(CommContracts.OtherServiceCharge OtherServiceCharge)
        {
            BLL.OtherServiceCharge temp = new BLL.OtherServiceCharge();
            return temp.SaveOtherServiceCharge(OtherServiceCharge);
        }

        public List<CommContracts.OtherServiceCharge> GetAllChargeFromOtherServiceAdvice(int AdviceID)
        {
            BLL.OtherServiceCharge temp = new BLL.OtherServiceCharge();
            return temp.GetAllChargeFromOtherServiceAdvice(AdviceID);
        }

        public List<CommContracts.OtherServiceCharge> GetAllClinicOtherServiceCharge(int RegistrationID)
        {
            BLL.OtherServiceCharge temp = new BLL.OtherServiceCharge();
            return temp.GetAllClinicOtherServiceCharge(RegistrationID);
        }

        public List<CommContracts.OtherServiceCharge> GetAllInHospitalOtherServiceCharge(int InpatientID)
        {
            BLL.OtherServiceCharge temp = new BLL.OtherServiceCharge();
            return temp.GetAllInHospitalOtherServiceCharge(InpatientID);
        }
    }
}
