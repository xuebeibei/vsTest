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
    public class OtherService
    {
        private ILoginService client;

        public OtherService()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.OtherService GetOtherService(int Id)
        {
            return client.GetOtherService(Id);
        }

        public bool SaveOtherService(CommContracts.OtherService otherService)
        {
            return client.SaveOtherService(otherService);
        }

        public List<CommContracts.OtherService> getAllOtherService(int RegistrationID)
        {
            return client.getAllOtherService(RegistrationID);
        }

        public List<CommContracts.OtherService> getAllInHospitalOtherService(int InpatientID)
        {
            return client.getAllInHospitalOtherService(InpatientID);
        }
    }
}
