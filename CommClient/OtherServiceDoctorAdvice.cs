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
    public class OtherServiceDoctorAdvice
    {
        private ILoginService client;

        public OtherServiceDoctorAdvice()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.OtherServiceDoctorAdvice GetOtherService(int Id)
        {
            return client.GetOtherService(Id);
        }

        public bool SaveOtherService(CommContracts.OtherServiceDoctorAdvice otherService)
        {
            return client.SaveOtherService(otherService);
        }

        public List<CommContracts.OtherServiceDoctorAdvice> getAllOtherService(int RegistrationID)
        {
            return client.getAllOtherService(RegistrationID);
        }

        public List<CommContracts.OtherServiceDoctorAdvice> getAllInHospitalOtherService(int InpatientID)
        {
            return client.getAllInHospitalOtherService(InpatientID);
        }

        public bool UpdateOtherServiceChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            return client.UpdateOtherServiceChargeStatus(AdviceID, chargeStatusEnum);
        }
    }
}
