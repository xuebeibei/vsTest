using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InspectDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public InspectDoctorAdviceDetail()
        {
            
        }
        [DataMember]
        public int InspectID { get; set; }               // 检验项目
        [DataMember]
        public int InspectDoctorAdviceID { get; set; }
        [DataMember]
        public InspectItem Inspect { get; set; }

    }
}
