using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class AssayDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        [DataMember]
        public int AssayID { get; set; }               // 化验项目
        [DataMember]
        public int AssayDoctorAdviceID { get; set; }
        [DataMember]
        public AssayItem Assay { get; set; }
    }
}
