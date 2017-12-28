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
    public class Inspect
    {
        private ILoginService client;

        public Inspect()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.Inspect GetInspect(int Id)
        {
            return client.GetInspect(Id);
        }

        public bool SaveInspect(CommContracts.Inspect inspect)
        {
            return client.SaveInspect(inspect);
        }

        public List<CommContracts.Inspect> getAllInspect(int RegistrationID)
        {
            return client.getAllInspect(RegistrationID);
        }

        public List<CommContracts.Inspect> getAllInHospitalInspect(int InpatientID)
        {
            return client.getAllInHospitalInspect(InpatientID);
        }
    }
}
