using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class StoreNumBase
    {
        [DataMember]
        public int ID { get; set; }                  // ID
        [DataMember]
        public int StoreRoomID { get; set; }         // 库房ID
        [DataMember]
        public int SupplierID { get; set; }          // 供应商ID
        [DataMember]
        public string Batch { get; set; }            // 批次
        [DataMember]
        public DateTime? ExpirationDate { get; set; } // 有效期
        [DataMember]
        public decimal StorePrice { get; set; }      // 成本价
        [DataMember]
        public int Num { get; set; }                 // 库存
        [DataMember]
        public StoreRoom StoreRoom { get; set; }
        [DataMember]
        public Supplier Supplier { get; set; }
    }
}
