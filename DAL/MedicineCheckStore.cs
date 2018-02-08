using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 药品盘存表
    /// </summary>
    public class MedicineCheckStore : StoreOperateBillBase
    {
        /// <summary>
        /// 
        /// </summary>
        public MedicineCheckStore()
        {
            MedicineCheckStoreDetails = new List<MedicineCheckStoreDetail>();
        }

        /// <summary>
        /// 盘存库房
        /// </summary>
        public int CheckStoreID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
    }
}
