using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class DoctorAdviceDetailBase
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int AllNum { get; set; }
        [DataMember]
        public decimal SellPrice { get; set; }           // 参考价格
        [DataMember]
        public string Remarks { get; set; }
    }
}
