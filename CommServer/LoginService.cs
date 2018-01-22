﻿using System;
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

        public List<CommContracts.Department> getALLDepartment(string strName = "")
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

        public bool UpdateSignalSource(int nSignalSourceID)
        {
            BLL.SignalSource temp = new BLL.SignalSource();
            return temp.UpdateSignalSource(nSignalSourceID);
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

        public bool UpdateChargeStatus(int RecipeID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.Recipe temp = new BLL.Recipe();
            return temp.UpdateChargeStatus(RecipeID, chargeStatusEnum);
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

        // 根据收费单更新库存
        public bool SubdStoreNum(CommContracts.RecipeChargeBill recipeChargeBill)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.SubdStoreNum(recipeChargeBill);
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
    }
}
