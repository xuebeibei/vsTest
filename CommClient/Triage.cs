using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;

namespace CommClient
{
    public class Triage
    {
        private ILoginService client;

        public Triage()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveTriage(int nDoctorID, int nRegistrationID)
        {
            if (nDoctorID <= 0)
            {
                return false;
            }
            if (nRegistrationID <= 0)
            {
                return false;
            }

            return client.SaveTriage(nDoctorID, nRegistrationID);
        }
    }
}
