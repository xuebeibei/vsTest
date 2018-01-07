using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineCheckStoreDetail
    {
        public MedicineCheckStoreDetail()
        {

        }
        [DataMember]
        public int ID { get; set; }                      // ID
        [DataMember]
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        [DataMember]
        public int NumBeforeCheck { get; set; }          // 出库前数量 
        [DataMember]
        public int Num { get; set; }                     // 出库数量
        [DataMember]
        public decimal StorePrice { get; set; }          // 出库前成本价
        [DataMember]
        public decimal SellPrice { get; set; }           // 出库前零售价
        [DataMember]
        public int MedicineCheckStoreID { get; set; }  // 盘存单ID
    }
}
