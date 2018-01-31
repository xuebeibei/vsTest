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
    public class DoctorAdviceBase
    {
        protected ILoginService client;

        public DoctorAdviceBase()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool UpdateChargeStatus(int DoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            return client.UpdateChargeStatus(DoctorAdviceID, chargeStatusEnum);
        }
    }
}
