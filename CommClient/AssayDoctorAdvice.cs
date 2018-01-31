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
    public class AssayDoctorAdvice : DoctorAdviceBase
    {
        public CommContracts.AssayDoctorAdvice GetAssay(int Id)
        {
            return client.GetAssayDoctorAdvice(Id);
        }

        public bool SaveAssay(CommContracts.AssayDoctorAdvice assayDoctorAdvice)
        {
            return client.SaveAssayDoctorAdvice(assayDoctorAdvice);
        }

        public List<CommContracts.AssayDoctorAdvice> getAllAssay(int RegistrationID)
        {
            return client.getAllAssayDoctorAdvice(RegistrationID);
        }

        public List<CommContracts.AssayDoctorAdvice> getAllInHospitalAssay(int InpatientID)
        {
            return client.getAllInHospitalAssayDoctorAdvice(InpatientID);
        }
    }
}
