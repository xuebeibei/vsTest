using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CommContracts
{
    [ServiceContract]
    public interface IRegistrationService 
    {
        [OperationContract]
        bool SaveCancelRegistration(CancelRegistration cancelRegistration);

        [OperationContract]
        bool SaveRegistration(Registration registration);
        [OperationContract]
        bool UpdateRegistration(CommContracts.Registration registration);

        [OperationContract]
        List<CommContracts.Registration> getAllRegistration(int EmployeeID = 0, DateTime? VistTime = null);

        [OperationContract]
        List<CommContracts.Registration> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false);

        [OperationContract]
        string getPatientBMIMsg(int RegistrationID);

        [OperationContract]
        List<CommContracts.Registration> GetDepartmentRegistrationList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate);

        /// <summary>
        ///  查找某个患者的挂号记录
        /// </summary>
        /// <param name="PatientID"></param>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommContracts.Registration> GetPatientRegistrations(int PatientID, DateTime? DateTime = null);


        [OperationContract]
        List<CommContracts.RegistrationDitch> GetAllRegistrationDitch(string strName);
        [OperationContract]
        bool UpdateRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch);
        [OperationContract]
        bool SaveRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch);
        [OperationContract]
        bool DeleteRegistrationDitch(int RegistrationDitchID);

        [OperationContract]
        CommContracts.Registration CallNextRegistration(int nDepartmentID, DateTime dateTime);
    }
}
