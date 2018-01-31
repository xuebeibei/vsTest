using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialItem: GoodsBase
    {
        public MaterialItem()
        {
        }
       
        [DataMember]
        public bool Valuable { get; set; }                      // 是否是贵重
    }
}
