using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 物资盘存明细
    /// </summary>
    public class MaterialCheckStoreDetail : StoreOperateBillDetailBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialCheckStoreDetail()
        {

        }

        /// <summary>
        /// 库存ID
        /// </summary>
        public int StoreRoomMaterialNumID { get; set; }
        /// <summary>
        /// 出库前数量
        /// </summary>
        public int NumBeforeCheck { get; set; }

        /// <summary>
        /// 盘存单ID
        /// </summary>
        public int MaterialCheckStoreID { get; set; }

        /// <summary>
        /// 盘存单外键
        /// </summary>
        public virtual MaterialCheckStore MaterialCheckStore { get; set; }
    }
}
