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
    public class MyTableBase
    {
        protected ILoginService client;

        public MyTableBase()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(SecurityMode.None),
                new EndpointAddress("net.tcp://192.168.1.114:50557/LoginService"));
        }
    }
}
