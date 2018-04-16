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
    public class RegistrationBase
    {

        protected IRegistrationService client;
        public RegistrationBase()
        {
            client = ChannelFactory<IRegistrationService>.CreateChannel(
                new NetTcpBinding(SecurityMode.None),
                new EndpointAddress("net.tcp://192.168.1.114:50557/RegistrationService"));

        }
    }

    public class RegistrationDitch : RegistrationBase
    {

        public RegistrationDitch()
        {

        }

        public List<CommContracts.RegistrationDitch> GetAllRegistrationDitch(string strName = "")
        {
            return client.GetAllRegistrationDitch(strName);
        }

        public bool UpdateRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch)
        {
            return client.UpdateRegistrationDitch(RegistrationDitch);
        }

        public bool SaveRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch)
        {
            return client.SaveRegistrationDitch(RegistrationDitch);
        }

        public bool DeleteRegistrationDitch(int RegistrationDitchID)
        {
            return client.DeleteRegistrationDitch(RegistrationDitchID);
        }
    }
}
