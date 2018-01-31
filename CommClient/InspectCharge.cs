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
    public class InspectCharge
    {
        private ILoginService client;

        public InspectCharge()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveInspectCharge(CommContracts.InspectCharge InspectCharge)
        {
            return client.SaveInspectCharge(InspectCharge);
        }

        public List<CommContracts.InspectCharge> GetAllChargeFromInspectAdvice(int AdviceID)
        {
            return client.GetAllChargeFromInspectAdvice(AdviceID);
        }

        public List<CommContracts.InspectCharge> GetAllClinicInspectCharge(int RegistrationID)
        {
            return client.GetAllClinicInspectCharge(RegistrationID);
        }

        public List<CommContracts.InspectCharge> GetAllInHospitalInspectCharge(int InpatientID)
        {
            return client.GetAllInHospitalInspectCharge(InpatientID);
        }
    }
}
