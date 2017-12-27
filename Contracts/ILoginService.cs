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
        bool SaveRecipeDetail();

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
        bool SaveAssay(CommContracts.Assay assay);

        [OperationContract]
        CommContracts.Inspect GetInspect(int Id);

        [OperationContract]
        bool SaveInspect(CommContracts.Inspect inspect);

        [OperationContract]
        List<CommContracts.AssayItem> GetAllAssayItems(string strName);

        [OperationContract]
        List<CommContracts.InspectItem> GetAllInspectItems(string strName);
    }
}
