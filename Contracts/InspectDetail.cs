using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InspectDetail
    {
        public InspectDetail()
        {

        }
        [DataMember]
        public int ID { get; set; }                               // ID
        [DataMember]
        public int InspectItemID { get; set; }                    // 治疗ID
        [DataMember]
        public int Num { get; set; }                              // 次数
        [DataMember]
        public string Illustration { get; set; }                  // 说明
        [DataMember]
        public int InspectID { get; set; }                          // 所属检验申请单ID
        [DataMember]
        public virtual Inspect Inspect { get; set; }
        [DataMember]
        public virtual InspectItem InspectItem { get; set; }
    }
}
