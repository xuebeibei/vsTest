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
    class Assay
    {
        private ILoginService client;

        public Assay()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.Assay GetAssay(int Id)
        {
            return client.GetAssay(Id);
        }

        public bool SaveAssay(CommContracts.Assay assay)
        {
            return client.SaveAssay(assay);
        }
    }
}
