using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品出库明细
    public class MedicineOutStoreDetail : StoreOperateBillDetailBase
    {
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        public int NumBeforeOut { get; set; }            // 出库前数量 
        public int MedicineOutStoreID { get; set; }  // 出库单ID
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
        public virtual MedicineOutStore MedicineOutStore { get; set; }   // 出库单外键
    }
}
