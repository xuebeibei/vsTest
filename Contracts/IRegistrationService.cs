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
        List<CommContracts.RegistrationDitch> GetAllRegistrationDitch(string strName);
        [OperationContract]
        bool UpdateRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch);
        [OperationContract]
        bool SaveRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch);
        [OperationContract]
        bool DeleteRegistrationDitch(int RegistrationDitchID);
    }
}
