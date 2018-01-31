using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class AssayCharge : ChargeBase
    {
        public AssayCharge()
        {
            ChargeEnum = ChargeEnum.化验申请;
        }
        [DataMember]
        public int AssayDoctorAdviceID { get; set; }
        [DataMember]
        public AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        [DataMember]
        public List<AssayChargeDetail> AssayChargeDetails { get; set; }
    }
}
