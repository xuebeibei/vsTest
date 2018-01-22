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
    public class PrePay
    {
        private ILoginService client;

        public PrePay()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.PrePay GetPrePay(int Id)
        {
            return client.GetPrePay(Id);
        }

        public bool SavePrePay(CommContracts.PrePay prePay)
        {
            return client.SavePrePay(prePay);
        }

        public List<CommContracts.PrePay> GetAllPrePay(int PatientID)
        {
            return client.GetAllPrePay(PatientID);
        }

        public bool DeletePrePay(int PrePayID)
        {
            return client.DeletePrePay(PrePayID);
        }
    }
}
