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
    public class MaterialDoctorAdvice : DoctorAdviceBase
    {
        public CommContracts.MaterialDoctorAdvice GetMaterialDoctorAdvice(int Id)
        {
            return client.GetMaterialDoctorAdvice(Id);
        }

        public bool SaveMaterialDoctorAdvice(CommContracts.MaterialDoctorAdvice materialDoctorAdvice)
        {
            return client.SaveMaterialDoctorAdvice(materialDoctorAdvice);
        }

        public List<CommContracts.MaterialDoctorAdvice> getAllMaterialDoctorAdvice(int RegistrationID)
        {
            return client.getAllMaterialDoctorAdvice(RegistrationID);
        }

        public List<CommContracts.MaterialDoctorAdvice> getAllInHospitalMaterialDoctorAdvice(int InpatientID)
        {
            return client.getAllInHospitalMaterialDoctorAdvice(InpatientID);
        }
    }
}
