using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialDoctorAdvice : DoctorAdviceBase
    {
        public MaterialDoctorAdvice()
        {
        }
        [DataMember]
        public string ReCheckName { get; set; }
        [DataMember]
        public List<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
    }
}
