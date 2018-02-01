using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品盘存明细
    public class MedicineCheckStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineCheckStoreDetail()
        {

        }

        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        public int NumBeforeCheck { get; set; }          // 出库前数量 

        public int MedicineCheckStoreID { get; set; }    // 盘存单ID

        public virtual MedicineCheckStore MedicineCheckStore { get; set; }   // 盘存单外键
    }
}
