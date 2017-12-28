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
    public class Inpatient
    {
        private ILoginService client;

        public Inpatient()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public Dictionary<int, string> GetAllInPatient()
        {
            return client.GetAllInPatient();
        }
    }
}
