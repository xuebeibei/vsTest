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
    public class AssayCharge
    {
        private ILoginService client;

        public AssayCharge()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveAssayCharge(CommContracts.AssayCharge AssayCharge)
        {
            return client.SaveAssayCharge(AssayCharge);
        }

        public List<CommContracts.AssayCharge> GetAllChargeFromAssayAdvice(int AdviceID)
        {
            return client.GetAllChargeFromAssayAdvice(AdviceID);
        }

        public List<CommContracts.AssayCharge> GetAllClinicAssayCharge(int RegistrationID)
        {
            return client.GetAllClinicAssayCharge(RegistrationID);
        }

        public List<CommContracts.AssayCharge> GetAllInHospitalAssayCharge(int InpatientID)
        {
            return client.GetAllInHospitalAssayCharge(InpatientID);
        }
    }
}
