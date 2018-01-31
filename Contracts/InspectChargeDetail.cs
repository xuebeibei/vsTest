using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InspectChargeDetail : ChargeDetailBase
    {
        [DataMember]
        public int InspectID { get; set; }               // 检查项目
        [DataMember]
        public int InspectChargeID { get; set; }
        [DataMember]
        public InspectItem Inspect { get; set; }
    }

}
