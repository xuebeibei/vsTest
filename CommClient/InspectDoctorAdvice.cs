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
    public class InspectDoctorAdvice
    {
        private ILoginService client;

        public InspectDoctorAdvice()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.InspectDoctorAdvice GetInspectDoctorAdvice(int Id)
        {
            return client.GetInspectDoctorAdvice(Id);
        }

        public bool SaveInspectDoctorAdvice(CommContracts.InspectDoctorAdvice inspect)
        {
            return client.SaveInspectDoctorAdvice(inspect);
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInspectDoctorAdvice(int RegistrationID)
        {
            return client.getAllInspectDoctorAdvice(RegistrationID);
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInHospitalInspect(int InpatientID)
        {
            return client.getAllInHospitalInspect(InpatientID);
        }
        public bool UpdateInspectChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            return client.UpdateInspectChargeStatus(AdviceID, chargeStatusEnum);
        }
    }
}
