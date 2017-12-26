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

        public bool SaveRecipeDetail()
        {
            BLL.RecipeDetail temp = new BLL.RecipeDetail();
            return temp.SaveRecipeDetail();
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
    }
}
