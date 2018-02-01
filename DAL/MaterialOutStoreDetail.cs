using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资出库明细
    public class MaterialOutStoreDetail : StoreOperateBillDetailBase
    {
        public int StoreRoomMaterialNumID { get; set; }     // 库存ID
        public int NumBeforeOut { get; set; }               // 出库前数量 
        public int MaterialOutStoreID { get; set; }         // 出库单ID
        public virtual StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
        public virtual MaterialOutStore MaterialOutStore { get; set; }   // 出库单外键
    }
}
