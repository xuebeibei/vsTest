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
    public class MedicineCharge : MyTableBase
    {
        public MedicineCharge()
        {
        }

        public bool SaveMedicineCharge(CommContracts.MedicineCharge MedicineCharge)
        {
            return client.SaveMedicineCharge(MedicineCharge);
        }

        public List<CommContracts.MedicineCharge> GetAllChargeFromMedicineAdvice(int AdviceID)
        {
            return client.GetAllChargeFromMedicineAdvice(AdviceID);
        }

        public List<CommContracts.MedicineCharge> GetAllClinicMedicineCharge(int RegistrationID)
        {
            return client.GetAllClinicMedicineCharge(RegistrationID);
        }

        public List<CommContracts.MedicineCharge> GetAllInHospitalMedicineCharge(int InpatientID)
        {
            return client.GetAllInHospitalMedicineCharge(InpatientID);
        }
    }
}
