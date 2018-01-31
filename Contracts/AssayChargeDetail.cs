using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class AssayChargeDetail : ChargeDetailBase
    {
        [DataMember]
        public int AssayID { get; set; }               // 化验项目
        [DataMember]
        public int AssayChargeID { get; set; }
        [DataMember]
        public AssayItem Assay { get; set; }
    }
}
