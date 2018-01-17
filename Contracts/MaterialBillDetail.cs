using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialBillDetail
    {
        public MaterialBillDetail()
        {

        }
        [DataMember]
        public int ID { get; set; }                               // ID
        [DataMember]
        public int MaterialItemID { get; set; }                   // 材料ID
        [DataMember]
        public int Num { get; set; }                              // 次数
        [DataMember]
        public string Illustration { get; set; }                  // 说明
        [DataMember]
        public int MaterialBillID { get; set; }                          // 所属材料单ID
        [DataMember]
        public MaterialItem MaterialItem { get; set; }

    }
}
