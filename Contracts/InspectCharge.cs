using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InspectCharge : ChargeBase
    {
        public InspectCharge()
        {
            ChargeEnum = ChargeEnum.检查申请;
        }
        [DataMember]
        public int InspectDoctorAdviceID { get; set; }
        [DataMember]
        public InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        [DataMember]
        public List<InspectChargeDetail> InspectChargeDetails { get; set; }
    }
}
