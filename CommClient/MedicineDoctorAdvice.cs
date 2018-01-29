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
    public class MedicineDoctorAdvice
    {
        private ILoginService client;

        //public CommContracts.MedicineDoctorAdvice MyMedicineDoctorAdvice { get; set; }

        public MedicineDoctorAdvice()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));

            //MyMedicineDoctorAdvice = new CommContracts.MedicineDoctorAdvice();
        }

        public bool SaveMedicineDoctorAdvice(CommContracts.MedicineDoctorAdvice medicineDoctorAdvice)
        {
            return client.SaveMedicineDoctorAdvice(medicineDoctorAdvice);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllXiCheng(int RegistrationID)
        {
            return client.getAllXiCheng(RegistrationID);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllZhong(int RegistrationID)
        {
            return client.getAllZhong(RegistrationID);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalXiCheng(int InpatientID)
        {
            return client.getAllInHospitalXiCheng(InpatientID);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalZhong(int InpatientID)
        {
            return client.getAllInHospitalZhong(InpatientID);
        }

        public bool UpdateChargeStatus(int MedicineDoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            return client.UpdateChargeStatus(MedicineDoctorAdviceID, chargeStatusEnum);
        }
    }
}
