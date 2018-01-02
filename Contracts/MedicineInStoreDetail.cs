using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineInStoreDetail
    {
        public MedicineInStoreDetail()
        {

        }
        [DataMember]
        public int ID { get; set; }       // ID
        [DataMember]
        public int MedicineBatchID { get; set; } // 批次ID
        [DataMember]
        public int Num { get; set; }             // 入库数量
        [DataMember]
        public decimal StorePrice { get; set; }  // 成本价
        [DataMember]
        public decimal SellPrice { get; set; }   // 零售价
        [DataMember]
        public MedicineInStore MedicineInStore { get; set; }   // 入库单外键
        [DataMember]
        public MedicineBatch MedicineBatch { get; set; }       // 入库批次外键
    }
}
