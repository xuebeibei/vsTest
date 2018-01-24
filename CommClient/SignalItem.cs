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
    public class SignalItem
    {
        private ILoginService client;

        public SignalItem()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.SignalItem> GetAllSignalItem(string strName = "")
        {
            return client.GetAllSignalItem(strName);
        }

        public bool UpdateSignalItem(CommContracts.SignalItem signalItem)
        {
            return client.UpdateSignalItem(signalItem);
        }

        public bool SaveSignalItem(CommContracts.SignalItem signalItem)
        {
            return client.SaveSignalItem(signalItem);
        }

        public bool DeleteSignalItem(int signalItemID)
        {
            return client.DeleteSignalItem(signalItemID);
        }
    }
}
