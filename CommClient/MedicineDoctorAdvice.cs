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
    public class MedicineDoctorAdvice : DoctorAdviceBase
    {
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
    }
}
