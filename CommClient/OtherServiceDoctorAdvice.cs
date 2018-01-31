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
    public class OtherServiceDoctorAdvice : DoctorAdviceBase
    {
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
    }
}
