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
    public class TherapyCharge
    {
        private ILoginService client;

        public TherapyCharge()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveTherapyCharge(CommContracts.TherapyCharge TherapyCharge)
        {
            return client.SaveTherapyCharge(TherapyCharge);
        }

        public List<CommContracts.TherapyCharge> GetAllChargeFromTherapyAdvice(int AdviceID)
        {
            return client.GetAllChargeFromTherapyAdvice(AdviceID);
        }

        public List<CommContracts.TherapyCharge> GetAllClinicTherapyCharge(int RegistrationID)
        {
            return client.GetAllClinicTherapyCharge(RegistrationID);
        }

        public List<CommContracts.TherapyCharge> GetAllInHospitalTherapyCharge(int InpatientID)
        {
            return client.GetAllInHospitalTherapyCharge(InpatientID);
        }
    }
}
