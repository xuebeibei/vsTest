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
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
        }
        [DataMember]
        public string ReCheckName { get; set; }
        [DataMember]
        public List<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
    }
}
