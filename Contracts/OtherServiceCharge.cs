using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class OtherServiceCharge : ChargeBase
    {
        public OtherServiceCharge()
        {
            ChargeEnum = ChargeEnum.其他;
        }
        [DataMember]
        public int OtherServiceDoctorAdviceID { get; set; }
        [DataMember]
        public OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
        [DataMember]
        public List<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
    }
}
