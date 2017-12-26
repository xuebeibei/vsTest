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
    public class InspectItem
    {
        private ILoginService client;

        public InspectItem()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.InspectItem> GetAllInspectItems(string strName)
        {
            return client.GetAllInspectItems(strName);
        }
    }
}
