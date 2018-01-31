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
            DoctorAdviceEnum = DoctorAdviceBaseEnum.材料;
        }
        [DataMember]
        public List<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
    }
}
