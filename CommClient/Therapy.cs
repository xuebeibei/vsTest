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
    public class Therapy
    {
        private ILoginService client;

        public Therapy()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.Therapy GetTherapy(int Id)
        {
            return client.GetTherapy(Id);
        }

        public bool SaveTherapy(CommContracts.Therapy therapy)
        {
            return client.SaveTherapy(therapy);
        }

        public List<CommContracts.Therapy> getAllTherapy(int RegistrationID)
        {
            return client.getAllTherapy(RegistrationID);
        }

        public List<CommContracts.Therapy> getAllInHospitalTherapy(int InpatientID)
        {
            return client.getAllInHospitalTherapy(InpatientID);
        }
    }
}
