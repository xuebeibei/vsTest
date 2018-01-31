using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class AssayDoctorAdvice : DoctorAdviceBase
    {
        public AssayDoctorAdvice()
        {
            DoctorAdviceEnum = DoctorAdviceBaseEnum.化验;
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
        }
        [DataMember]
        public List<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
    }
}
