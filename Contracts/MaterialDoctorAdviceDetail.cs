using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        [DataMember]
        public int MaterialID { get; set; }               // 物资材料
        [DataMember]
        public int MaterialDoctorAdviceID { get; set; }
        [DataMember]
        public MaterialItem Material { get; set; }
    }
}
