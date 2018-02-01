using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资盘存明细
    public class MaterialCheckStoreDetail : StoreOperateBillDetailBase
    {
        public MaterialCheckStoreDetail()
        {

        }

        public int StoreRoomMaterialNumID { get; set; }  // 库存ID
        public int NumBeforeCheck { get; set; }          // 出库前数量 

        public int MaterialCheckStoreID { get; set; }    // 盘存单ID

        public virtual MaterialCheckStore MaterialCheckStore { get; set; }   // 盘存单外键
    }
}
