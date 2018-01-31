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
    public class OtherServiceCharge
    {
        private ILoginService client;

        public OtherServiceCharge()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveOtherServiceCharge(CommContracts.OtherServiceCharge OtherServiceCharge)
        {
            return client.SaveOtherServiceCharge(OtherServiceCharge);
        }

        public List<CommContracts.OtherServiceCharge> GetAllChargeFromOtherServiceAdvice(int AdviceID)
        {
            return client.GetAllChargeFromOtherServiceAdvice(AdviceID);
        }

        public List<CommContracts.OtherServiceCharge> GetAllClinicOtherServiceCharge(int RegistrationID)
        {
            return client.GetAllClinicOtherServiceCharge(RegistrationID);
        }

        public List<CommContracts.OtherServiceCharge> GetAllInHospitalOtherServiceCharge(int InpatientID)
        {
            return client.GetAllInHospitalOtherServiceCharge(InpatientID);
        }
    }
}
