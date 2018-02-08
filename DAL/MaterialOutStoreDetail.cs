using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 物资出库明细
    /// </summary>
    public class MaterialOutStoreDetail : StoreOperateBillDetailBase
    {
        /// <summary>
        /// 库存ID
        /// </summary>
        public int StoreRoomMaterialNumID { get; set; }
        /// <summary>
        /// 出库前数量
        /// </summary>
        public int NumBeforeOut { get; set; }
        /// <summary>
        /// 出库单ID
        /// </summary>
        public int MaterialOutStoreID { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public virtual StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
        /// <summary>
        /// 出库单外键
        /// </summary>
        public virtual MaterialOutStore MaterialOutStore { get; set; }
    }
}
