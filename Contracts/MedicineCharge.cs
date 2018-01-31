using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineCharge : ChargeBase
    {
        public MedicineCharge()
        {
            ChargeEnum = ChargeEnum.处方单;
        }
        [DataMember]
        public int MedicineDoctorAdviceID { get; set; }                    // 所对应的的用药医嘱
        [DataMember]
        public MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        [DataMember]
        public List<MedicineChargeDetail> MedicineChargeDetails { get; set; }

    }
}
