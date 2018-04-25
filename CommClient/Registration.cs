using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class Registration : RegistrationBase
    {
        public Registration()
        {
        }

        public List<CommContracts.Registration> getAllRegistration(int EmployeeID = 0, DateTime? VistTime = null)
        {
            return client.getAllRegistration(EmployeeID, VistTime);
        }

        public List<CommContracts.Registration> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            return client.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        public string getPatientBMIMsg(int RegistrationID)
        {
            return client.getPatientBMIMsg(RegistrationID);
        }

        public List<CommContracts.Registration> GetDepartmentRegistrationList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            return client.GetDepartmentRegistrationList(DepartmentID, EmployeeID, startDate, endDate);
        }

        public bool SaveRegistration(CommContracts.Registration registration)
        {
            return client.SaveRegistration(registration);
        }

        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            return client.UpdateRegistration(registration);
        }

        // 查找某个患者挂号记录
        public List<CommContracts.Registration> GetPatientRegistrations(int PatientID, DateTime? DateTime = null)
        {
            return client.GetPatientRegistrations(PatientID,DateTime);
        }

        public CommContracts.Registration CallNextRegistration(int nDepartmentID, DateTime dateTime)
        {
            return client.CallNextRegistration(nDepartmentID, dateTime);
        }
    }
}
