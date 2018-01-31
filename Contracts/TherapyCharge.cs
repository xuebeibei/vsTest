using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class TherapyCharge : ChargeBase
    {
        public TherapyCharge()
        {
            ChargeEnum = ChargeEnum.治疗单;
        }
        [DataMember]
        public int TherapyDoctorAdviceID { get; set; }
        [DataMember]
        public TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
        [DataMember]
        public List<TherapyChargeDetail> TherapyChargeDetails { get; set; }
    }
}
