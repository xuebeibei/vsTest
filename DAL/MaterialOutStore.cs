using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 物资出库表
    /// </summary>
    public class MaterialOutStore : StoreOperateBillBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialOutStore()
        {
            MaterialOutStoreDetails = new List<MaterialOutStoreDetail>();
        }

        /// <summary>
        /// 出库类型
        /// </summary>
        public OutStoreEnum OutStoreEnum { get; set; }
        /// <summary>
        /// 出库库房ID
        /// </summary>
        public int FromStoreID { get; set; }
        /// <summary>
        /// 接收库房ID
        /// </summary>
        public int ToStoreID { get; set; }
        /// <summary>
        /// 接收医院ID
        /// </summary>
        public int ToOtherHospitalID { get; set; }
        /// <summary>
        /// 供货商退货
        /// </summary>
        public int ToSupplierID { get; set; }

        /// <summary>
        /// 出库单明细列表
        /// </summary>
        public virtual ICollection<MaterialOutStoreDetail> MaterialOutStoreDetails { get; set; }
    }
}
