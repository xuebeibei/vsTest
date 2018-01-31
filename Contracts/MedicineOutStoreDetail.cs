using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineOutStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineOutStoreDetail()
        {

        }

        [DataMember]
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        [DataMember]
        public int NumBeforeOut { get; set; }            // 出库前数量 
        [DataMember]
        public int MedicineOutStoreID { get; set; }  // 出库单ID
        [DataMember]
        public StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }
}
