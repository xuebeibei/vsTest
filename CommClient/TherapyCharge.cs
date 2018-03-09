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
    public class TherapyCharge : MyTableBase
    {
        public TherapyCharge()
        {
        }

        public bool SaveTherapyCharge(CommContracts.TherapyCharge TherapyCharge)
        {
            return client.SaveTherapyCharge(TherapyCharge);
        }

        public List<CommContracts.TherapyCharge> GetAllChargeFromTherapyAdvice(int AdviceID)
        {
            return client.GetAllChargeFromTherapyAdvice(AdviceID);
        }

        public List<CommContracts.TherapyCharge> GetAllClinicTherapyCharge(int RegistrationID)
        {
            return client.GetAllClinicTherapyCharge(RegistrationID);
        }

        public List<CommContracts.TherapyCharge> GetAllInHospitalTherapyCharge(int InpatientID)
        {
            return client.GetAllInHospitalTherapyCharge(InpatientID);
        }
    }
}
