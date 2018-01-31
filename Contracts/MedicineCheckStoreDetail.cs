using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineCheckStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineCheckStoreDetail()
        {

        }
        [DataMember]
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        [DataMember]
        public int NumBeforeCheck { get; set; }          // 出库前数量 
        [DataMember]
        public int MedicineCheckStoreID { get; set; }  // 盘存单ID
    }
}
