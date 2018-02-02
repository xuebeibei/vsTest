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
    public class InHospitalApply
    {
        private ILoginService client;

        public InHospitalApply()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.InHospitalApply> GetAllInHospitalApply(string strName = "")
        {
            return client.GetAllInHospitalApply(strName);
        }

        public bool UpdateInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            return client.UpdateInHospitalApply(InHospitalApply);
        }

        public bool SaveInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            return client.SaveInHospitalApply(InHospitalApply);
        }

        public bool DeleteInHospitalApply(int InHospitalApplyID)
        {
            return client.DeleteInHospitalApply(InHospitalApplyID);
        }
    }
}
