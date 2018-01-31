using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class ChargeDetailBase
    {
        [DataMember]
        public int ID { get; set; }                               // ID
        [DataMember]
        public decimal SellPrice { get; set; }                    // 单价
        [DataMember]
        public int AllNum { get; set; }                           // 数量
        [DataMember]
        public int Rebate { get; set; }                           // 折扣
    }
}
