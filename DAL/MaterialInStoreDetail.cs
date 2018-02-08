using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 
    /// <summary>
    /// 物资入库明细
    /// </summary>
    public class MaterialInStoreDetail : StoreOperateBillDetailBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialInStoreDetail()
        {

        }
        /// <summary>
        /// 对应物资字典
        /// </summary>
        public int MaterialID { get; set; }
        /// <summary>
        /// 入库单ID
        /// </summary>
        public int MaterialInStoreID { get; set; }

        /// <summary>
        /// 物资字典外键
        /// </summary>
        public virtual MaterialItem Material { get; set; }
        /// <summary>
        /// 入库单外键
        /// </summary>
        public virtual MaterialInStore MaterialInStore { get; set; }
    }
}
