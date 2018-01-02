using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineBatch
    {
        public MedicineBatch()
        {
        }

        [DataMember]
        public int ID { get; set; }                  // ID
        [DataMember]
        public int MedicineID { get; set; }          // 对应药品字典
        [DataMember]
        public string Batch { get; set; }            // 批次
        [DataMember]
        public DateTime ExpirationDate { get; set; } // 有效期
        [DataMember]
        public decimal StorePrice { get; set; }      // 成本价
        [DataMember]
        public decimal SellPrice { get; set; }       // 零售价
        [DataMember]
        public List<StoreRoomMedicineNum> StoreRoomMedicineBatchs { get; set; }
        [DataMember]
        public List<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
    }
}
