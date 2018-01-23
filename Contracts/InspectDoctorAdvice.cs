using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InspectDoctorAdvice : DoctorAdviceBase
    {
        public InspectDoctorAdvice()
        {
        }
        [DataMember]
        public List<InspectDoctorAdviceDetail> InspectDoctorAdviceDetails { get; set; }
    }
}
