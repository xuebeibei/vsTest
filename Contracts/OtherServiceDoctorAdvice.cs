using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class OtherServiceDoctorAdvice : DoctorAdviceBase
    {
        public OtherServiceDoctorAdvice()
        {
            DoctorAdviceEnum = DoctorAdviceBaseEnum.其他;
        }
        [DataMember]
        public List<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
    }
}
