using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 物资入库表
    /// </summary>
    public class MaterialInStore : StoreOperateBillBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialInStore()
        {
            MaterialInStoreDetails = new List<MaterialInStoreDetail>();
        }
        /// <summary>
        /// 入库数量
        /// </summary>
        public InStoreEnum InStoreEnum { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int FromSupplierID { get; set; }
        /// <summary>
        /// 入库库房ID
        /// </summary>
        public int ToStoreID { get; set; }           

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual Supplier FromSupplier { get; set; }
        /// <summary>
        /// 入库单明细
        /// </summary>
        public virtual ICollection<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
    }
}
