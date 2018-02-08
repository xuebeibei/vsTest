using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{ 
    /// <summary>
    /// 物资盘存表
    /// </summary>
    public class MaterialCheckStore : StoreOperateBillBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialCheckStore()
        {
            MaterialCheckStoreDetails = new List<MaterialCheckStoreDetail>();
        }

        /// <summary>
        /// 盘存库房ID
        /// </summary>
        public int CheckStoreID { get; set; }

        /// <summary>
        /// 盘存详细物资信息列表
        /// </summary>
        public virtual ICollection<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }
    }
}
