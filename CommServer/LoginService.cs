using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommContracts;
using System.Collections;
using System.Data;

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

        public CommContracts.Employee UserAuthenticate(string LoginName, string Password, string MachineCode)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.Authenticate(LoginName, Password, MachineCode);
        }

        public bool UserLogout(Employee user)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.Logout(user);
        }


        public List<CommContracts.EmployeeLoginHistory> GetAllLoginInAndOutRecords(string strName)
        {
            BLL.LoginInAndOutRecords temp = new BLL.LoginInAndOutRecords();
            return temp.GetAllLoginInAndOutRecords(strName);
        }

        public bool UpdateLoginInAndOutRecords(CommContracts.EmployeeLoginHistory LoginInAndOutRecords)
        {
            BLL.LoginInAndOutRecords temp = new BLL.LoginInAndOutRecords();
            return temp.UpdateLoginInAndOutRecords(LoginInAndOutRecords);
        }

        public bool SaveEmployeeLoginHistory(CommContracts.EmployeeLoginHistory LoginInAndOutRecords)
        {
            BLL.LoginInAndOutRecords temp = new BLL.LoginInAndOutRecords();
            return temp.SaveLoginInAndOutRecords(LoginInAndOutRecords);
        }

        public bool DeleteLoginInAndOutRecords(int LoginInAndOutRecordsID)
        {
            BLL.LoginInAndOutRecords temp = new BLL.LoginInAndOutRecords();
            return temp.DeleteLoginInAndOutRecords(LoginInAndOutRecordsID);
        }


        public List<CommContracts.PatientCardManage> GetAllPatientCardManage(string strName = "")
        {
            BLL.PatientCardManage temp = new BLL.PatientCardManage();
            return temp.GetAllPatientCardManage(strName);
        }

        public bool UpdatePatientCardManage(CommContracts.PatientCardManage PatientCardManage)
        {
            BLL.PatientCardManage temp = new BLL.PatientCardManage();
            return temp.UpdatePatientCardManage(PatientCardManage);
        }

        public bool SavePatientCardManage(CommContracts.PatientCardManage PatientCardManage, ref string ErrorMsg)
        {
            BLL.PatientCardManage temp = new BLL.PatientCardManage();
            return temp.SavePatientCardManage(PatientCardManage, ref ErrorMsg);
        }

        public bool DeletePatientCardManage(int PatientCardManageID)
        {
            BLL.PatientCardManage temp = new BLL.PatientCardManage();
            return temp.DeletePatientCardManage(PatientCardManageID);
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

        public List<CommContracts.WorkPlan> GetAllWorkPlan()
        {
            BLL.WorkPlan tempDepart = new BLL.WorkPlan();
            return tempDepart.GetAllWorkPlan();
        }

        public List<DateTime> getAllWorkPlanDate(int DepartmentID)
        {
            BLL.WorkPlan tempDepart = new BLL.WorkPlan();
            return tempDepart.getAllWorkPlanDate(DepartmentID);
        }

        public List<int> getAllWorkPlanIntival(int DepartmentID)
        {
            BLL.WorkPlan tempDepart = new BLL.WorkPlan();
            return tempDepart.getAllWorkPlanIntival(DepartmentID);
        }

        public string getWorkPlanTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.getWorkPlanTip(DepartmentID, dateTime, TimeIntival);
        }

        public bool UpdateWorkPlanHasUsedNum(int nSignalSourceID)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.UpdateWorkPlanHasUsedNum(nSignalSourceID);
        }
        public bool SaveWorkPlanList(List<CommContracts.WorkPlan> list)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.SaveWorkPlanList(list);
        }
        public List<CommContracts.WorkPlan> GetWorkPlanList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate, int ClinicVistTimeID)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.GetWorkPlanList(DepartmentID, EmployeeID, startDate, endDate, ClinicVistTimeID);
        }

        public bool UpdateWorkPlan(CommContracts.WorkPlan signalSource)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.UpdateWorkPlan(signalSource);
        }

        public bool UpdateWorkPlanStatus(int workPlanID, CommContracts.WorkPlanStatus workPlanStatus)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.UpdateWorkPlanStatus(workPlanID, workPlanStatus);
        }

        public List<CommContracts.WorkPlanToSignalSource> GetAllWorkPlan111(int DepartmentID, DateTime startDate, DateTime endDate)
        {
            BLL.WorkPlan temp = new BLL.WorkPlan();
            return temp.GetAllWorkPlan111(DepartmentID, startDate, endDate);
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

        public bool SaveEmployee(CommContracts.Employee employee, ref int employeeID)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.SaveEmployee(employee, ref employeeID);
        }

        public bool DeleteEmployee(int employeeID)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.DeleteEmployee(employeeID);
        }

        public CommContracts.Department GetCurrentDepartment(int employeeID)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.GetCurrentDepartment(employeeID);
        }

        public CommContracts.Job GetCurrentJob(int employeeID)
        {
            BLL.Employee temp = new BLL.Employee();
            return temp.GetCurrentJob(employeeID);
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

        public List<CommContracts.InHospital> GetAllInHospitalList(int EmployeeID = 0, string strName = "")
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.GetAllInHospitalList(EmployeeID, strName);
        }

        public string getInHospitalBMIMsg(int InHospitalID)
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.getInHospitalBMIMsg(InHospitalID);
        }

        public bool SaveInHospital(CommContracts.InHospital InHospital)
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.SaveInHospital(InHospital);
        }

        public bool UpdateInHospital(CommContracts.InHospital InHospital)
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.UpdateInHospital(InHospital);
        }

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.InHospital ReadNewInHospital(int PatientID)
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.ReadNewInHospital(PatientID);
        }

        // 读取已入院患者信息
        public CommContracts.InHospital ReadCurrentInHospital(int InHospitalID)
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.ReadCurrentInHospital(InHospitalID);
        }

        // 读取已出院患者信息
        public CommContracts.InHospital ReadLeavedPatient(int InHospitalID)
        {
            BLL.InHospital temp = new BLL.InHospital();
            return temp.ReadLeavedPatient(InHospitalID);
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInHospitalInspect(int InpatientID)
        {
            BLL.InspectDoctorAdvice temp = new BLL.InspectDoctorAdvice();
            return temp.getAllInHospitalInspectDoctorAdvice(InpatientID);
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllInHospitalTherapyDoctorAdvice(int InpatientID)
        {
            BLL.TherapyDoctorAdvice temp = new BLL.TherapyDoctorAdvice();
            return temp.getAllInHospitalTherapyDoctorAdvice(InpatientID);
        }

        public List<CommContracts.AssayDoctorAdvice> getAllInHospitalAssayDoctorAdvice(int InpatientID)
        {
            BLL.AssayDoctorAdvice temp = new BLL.AssayDoctorAdvice();
            return temp.getAllInHospitalAssayDoctorAdvice(InpatientID);
        }

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

        // 根据收费单更新库存
        public bool SubdMedicineStoreNumByAdvice(CommContracts.MedicineCharge medicineCharge)
        {
            BLL.StoreRoomMedicineNum temp = new BLL.StoreRoomMedicineNum();
            return temp.SubdMedicineStoreNumByAdvice(medicineCharge);
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

        public List<CommContracts.Job> GetAllTypeJob(CommContracts.JobTypeEnum typeEnum)
        {
            BLL.Job temp = new BLL.Job();
            return temp.GetAllTypeJob(typeEnum);
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

        public CommContracts.PatientCardPrePay GetPrePay(int Id)
        {
            BLL.PatientCardPrePay temp = new BLL.PatientCardPrePay();
            return temp.GetPrePay(Id);
        }

        public bool SavePrePay(CommContracts.PatientCardPrePay prePay, ref int prePayID, ref string ErrorMsg)
        {
            BLL.PatientCardPrePay temp = new BLL.PatientCardPrePay();
            return temp.SavePrePay(prePay, ref prePayID, ref ErrorMsg);
        }

        public List<CommContracts.PatientCardPrePay> GetAllPrePay(int PatientID)
        {
            BLL.PatientCardPrePay temp = new BLL.PatientCardPrePay();
            return temp.GetAllPrePay(PatientID);
        }

        public bool DeletePrePay(int PrePayID)
        {
            BLL.PatientCardPrePay temp = new BLL.PatientCardPrePay();
            return temp.DeletePrePay(PrePayID);
        }

        public string getNewPID()
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.getNewPID();
        }

        public string getNewPatientCardNum()
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.getNewPatientCardNum();
        }

        public CommContracts.Patient ReadCurrentPatient(int PatientID)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.ReadCurrentPatient(PatientID);
        }

        public CommContracts.Patient ReadCurrentPatientByPatientCardNum(string strPatientCardNum, ref string ErrorMsg)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);
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

        public List<CommContracts.SignalType> GetAllSignalType(string strName = "")
        {
            BLL.SignalType temp = new BLL.SignalType();
            return temp.GetAllSignalType(strName);
        }

        public bool UpdateSignalType(CommContracts.SignalType SignalType)
        {
            BLL.SignalType temp = new BLL.SignalType();
            return temp.UpdateSignalType(SignalType);
        }

        public bool SaveSignalType(CommContracts.SignalType SignalType)
        {
            BLL.SignalType temp = new BLL.SignalType();
            return temp.SaveSignalType(SignalType);
        }

        public bool DeleteSignalType(int SignalTypeID)
        {
            BLL.SignalType temp = new BLL.SignalType();
            return temp.DeleteSignalType(SignalTypeID);
        }

        public List<CommContracts.Patient> GetAllPatient(string strName = "")
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.GetAllPatient(strName);
        }

        public bool UpdatePatient(CommContracts.Patient patient, ref string ErrorMsg)
        {
            BLL.Patient temp = new BLL.Patient();
            return temp.UpdatePatient(patient, ref ErrorMsg);
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

        public bool UpdateChargeStatus(int DoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            BLL.DoctorAdviceBase temp = new BLL.DoctorAdviceBase();
            return temp.UpdateChargeStatus(DoctorAdviceID, chargeStatusEnum);
        }

        public bool UpdateExecuteEnum(int DoctorAdviceID, CommContracts.ExecuteEnum executeEnum)
        {
            BLL.DoctorAdviceBase temp = new BLL.DoctorAdviceBase();
            return temp.UpdateExecuteEnum(DoctorAdviceID, executeEnum);
        }

        public List<CommContracts.InHospitalApply> GetAllInHospitalApply(CommContracts.InHospitalApplyEnum inHospitalApplyEnum, string strName = "")
        {
            BLL.InHospitalApply temp = new BLL.InHospitalApply();
            return temp.GetAllInHospitalApply(inHospitalApplyEnum, strName);
        }

        public bool SaveInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            BLL.InHospitalApply temp = new BLL.InHospitalApply();
            return temp.SaveInHospitalApply(InHospitalApply);
        }
        public bool DeleteInHospitalApply(int InHospitalApplyID)
        {
            BLL.InHospitalApply temp = new BLL.InHospitalApply();
            return temp.DeleteInHospitalApply(InHospitalApplyID);
        }

        public bool UpdateInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            BLL.InHospitalApply temp = new BLL.InHospitalApply();
            return temp.UpdateInHospitalApply(InHospitalApply);
        }

        public List<CommContracts.LeaveHospital> GetAllLeaveHospitalList(int EmployeeID = 0, string strName = "")
        {
            BLL.LeaveHospital temp = new BLL.LeaveHospital();
            return temp.GetAllLeaveHospitalList(EmployeeID, strName);
        }

        public bool SaveLeaveHospital(CommContracts.LeaveHospital leaveHospital)
        {
            BLL.LeaveHospital temp = new BLL.LeaveHospital();
            return temp.SaveLeaveHospital(leaveHospital);
        }

        public bool UpdateLeaveHospital(CommContracts.LeaveHospital leaveHospital)
        {
            BLL.LeaveHospital temp = new BLL.LeaveHospital();
            return temp.UpdateLeaveHospital(leaveHospital);
        }

        public List<CommContracts.RecallHospital> GetAllRecallHospitalList(int EmployeeID = 0, string strName = "")
        {
            BLL.RecallHospital temp = new BLL.RecallHospital();
            return temp.GetAllRecallHospitalList(EmployeeID, strName);
        }

        public bool SaveRecallHospital(CommContracts.RecallHospital recallHospital)
        {
            BLL.RecallHospital temp = new BLL.RecallHospital();
            return temp.SaveRecallHospital(recallHospital);
        }

        public bool UpdateRecallHospital(CommContracts.RecallHospital recallHospital)
        {
            BLL.RecallHospital temp = new BLL.RecallHospital();
            return temp.UpdateRecallHospital(recallHospital);
        }

        public bool SaveInjectionBill(CommContracts.InjectionBill injectionBill)
        {
            BLL.InjectionBill temp = new BLL.InjectionBill();
            return temp.SaveInjectionBill(injectionBill);
        }

        public List<CommContracts.InjectionBill> GetAllInjectionBill(int nRegistrationID)
        {
            BLL.InjectionBill temp = new BLL.InjectionBill();
            return temp.GetAllInjectionBill(nRegistrationID);
        }

        public List<CommContracts.InjectionBill> GetAllInHospitalInjectionBill(int InHospitalID)
        {
            BLL.InjectionBill temp = new BLL.InjectionBill();
            return temp.GetAllInHospitalInjectionBill(InHospitalID);
        }

        public List<CommContracts.SignalTime> GetAllClinicVistTime(string strName = "")
        {
            BLL.SignalTime temp = new BLL.SignalTime();
            return temp.GetAllClinicVistTime(strName);
        }

        public bool UpdateClinicVistTime(CommContracts.SignalTime ClinicVistTime)
        {
            BLL.SignalTime temp = new BLL.SignalTime();
            return temp.UpdateClinicVistTime(ClinicVistTime);
        }

        public bool SaveClinicVistTime(CommContracts.SignalTime ClinicVistTime)
        {
            BLL.SignalTime temp = new BLL.SignalTime();
            return temp.SaveClinicVistTime(ClinicVistTime);
        }

        public bool DeleteClinicVistTime(int ClinicVistTimeID)
        {
            BLL.SignalTime temp = new BLL.SignalTime();
            return temp.DeleteClinicVistTime(ClinicVistTimeID);
        }

        public List<CommContracts.RegistrationDitch> GetAllRegistrationDitch(string strName)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.GetAllRegistrationDitch(strName);
        }
        public bool UpdateRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.UpdateRegistrationDitch(RegistrationDitch);
        }
        public bool SaveRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.SaveRegistrationDitch(RegistrationDitch);
        }
        public bool DeleteRegistrationDitch(int RegistrationDitchID)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.DeleteRegistrationDitch(RegistrationDitchID);
        }

        public List<CommContracts.Employee> GetAllDepartmentEmployee(int DepartmentID)
        {
            BLL.EmployeeDepartmentHistory temp = new BLL.EmployeeDepartmentHistory();
            return temp.GetAllDepartmentEmployee(DepartmentID);
        }

        public List<CommContracts.Employee> GetAllDepartmentDoctor(int DepartmentID)
        {
            BLL.EmployeeDepartmentHistory temp = new BLL.EmployeeDepartmentHistory();
            return temp.GetAllDepartmentDoctor(DepartmentID);
        }

        public List<CommContracts.EmployeeDepartmentHistory> GetAllEmployeeDepartmentHistory(int EmployeeID)
        {
            BLL.EmployeeDepartmentHistory temp = new BLL.EmployeeDepartmentHistory();
            return temp.GetAllEmployeeDepartmentHistory(EmployeeID);
        }

        public bool SaveEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory)
        {
            BLL.EmployeeDepartmentHistory temp = new BLL.EmployeeDepartmentHistory();
            return temp.SaveEmployeeDepartmentHistory(EmployeeDepartmentHistory);
        }

        public bool DeleteEmployeeDepartmentHistory(int EmployeeDepartmentHistoryID)
        {
            BLL.EmployeeDepartmentHistory temp = new BLL.EmployeeDepartmentHistory();
            return temp.DeleteEmployeeDepartmentHistory(EmployeeDepartmentHistoryID);
        }

        public bool UpdateEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory)
        {
            BLL.EmployeeDepartmentHistory temp = new BLL.EmployeeDepartmentHistory();
            return temp.UpdateEmployeeDepartmentHistory(EmployeeDepartmentHistory);
        }

        public List<CommContracts.Employee> GetAllJobEmployee(int JobID)
        {
            BLL.EmployeeJobHistory temp = new BLL.EmployeeJobHistory();
            return temp.GetAllJobEmployee(JobID);
        }
        public List<CommContracts.EmployeeJobHistory> GetAllEmployeeJobHistory(int EmployeeID)
        {
            BLL.EmployeeJobHistory temp = new BLL.EmployeeJobHistory();
            return temp.GetAllEmployeeJobHistory(EmployeeID);
        }

        public bool SaveEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory)
        {
            BLL.EmployeeJobHistory temp = new BLL.EmployeeJobHistory();
            return temp.SaveEmployeeJobHistory(EmployeeJobHistory);
        }

        public bool DeleteEmployeeJobHistory(int EmployeeJobHistoryID)
        {
            BLL.EmployeeJobHistory temp = new BLL.EmployeeJobHistory();
            return temp.DeleteEmployeeJobHistory(EmployeeJobHistoryID);
        }

        public bool UpdateEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory)
        {
            BLL.EmployeeJobHistory temp = new BLL.EmployeeJobHistory();
            return temp.UpdateEmployeeJobHistory(EmployeeJobHistory);
        }

        public List<CommContracts.Shift> GetAllShift(string strName = "")
        {
            BLL.Shift temp = new BLL.Shift();
            return temp.GetAllShift(strName);
        }

        public bool UpdateShift(CommContracts.Shift Shift)
        {
            BLL.Shift temp = new BLL.Shift();
            return temp.UpdateShift(Shift);
        }

        public bool SaveShift(CommContracts.Shift Shift)
        {
            BLL.Shift temp = new BLL.Shift();
            return temp.SaveShift(Shift);
        }

        public bool DeleteShift(int ShiftID)
        {
            BLL.Shift temp = new BLL.Shift();
            return temp.DeleteShift(ShiftID);
        }


        public List<CommContracts.WorkType> GetAllWorkType(string strName = "")
        {
            BLL.WorkType temp = new BLL.WorkType();
            return temp.GetAllWorkType(strName);
        }

        public bool UpdateWorkType(CommContracts.WorkType WorkType)
        {
            BLL.WorkType temp = new BLL.WorkType();
            return temp.UpdateWorkType(WorkType);
        }

        public bool SaveWorkType(CommContracts.WorkType WorkType)
        {
            BLL.WorkType temp = new BLL.WorkType();
            return temp.SaveWorkType(WorkType);
        }

        public bool DeleteWorkType(int WorkTypeID)
        {
            BLL.WorkType temp = new BLL.WorkType();
            return temp.DeleteWorkType(WorkTypeID);
        }

        public List<CommContracts.ClinicMedicalRecordModel> GetAllClinicMedicalRecordModel(string strName)
        {
            BLL.ClinicMedicalRecordModel temp = new BLL.ClinicMedicalRecordModel();
            return temp.GetAllClinicMedicalRecordModel(strName);
        }

        public bool UpdateClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel)
        {
            BLL.ClinicMedicalRecordModel temp = new BLL.ClinicMedicalRecordModel();
            return temp.UpdateClinicMedicalRecordModel(ClinicMedicalRecordModel);
        }

        public bool SaveClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel)
        {
            BLL.ClinicMedicalRecordModel temp = new BLL.ClinicMedicalRecordModel();
            return temp.SaveClinicMedicalRecordModel(ClinicMedicalRecordModel);
        }

        public bool DeleteClinicMedicalRecordModel(int ClinicMedicalRecordModelID)
        {
            BLL.ClinicMedicalRecordModel temp = new BLL.ClinicMedicalRecordModel();
            return temp.DeleteClinicMedicalRecordModel(ClinicMedicalRecordModelID);
        }
    }
}
