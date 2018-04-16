using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CommContracts;

namespace CommServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“RegistrationService”。
    public class RegistrationService : IRegistrationService
    {
        private MainWindow hostApp;
        public RegistrationService(MainWindow hostApp)
        {
            this.hostApp = hostApp;
        }

        public bool DeleteRegistrationDitch(int RegistrationDitchID)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.DeleteRegistrationDitch(RegistrationDitchID);
        }

        public List<RegistrationDitch> GetAllRegistrationDitch(string strName)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.GetAllRegistrationDitch(strName);
        }

        public bool SaveRegistrationDitch(RegistrationDitch RegistrationDitch)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.SaveRegistrationDitch(RegistrationDitch);
        }

        public bool UpdateRegistrationDitch(RegistrationDitch RegistrationDitch)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.UpdateRegistrationDitch(RegistrationDitch);
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

        // 查找某个患者的挂号记录
        public List<CommContracts.Registration> GetPatientRegistrations(int PatientID, DateTime? DateTime = null)
        {
            BLL.Registration temp = new BLL.Registration();
            return temp.GetPatientRegistrations(PatientID, DateTime);
        }

        public bool SaveCancelRegistration(CancelRegistration cancelRegistration)
        {
            BLL.CancelRegistration temp = new BLL.CancelRegistration();
            return temp.SaveCancelRegistration(cancelRegistration);
        }
    }
}
