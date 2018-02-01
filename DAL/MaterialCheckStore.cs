using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资盘存表
    public class MaterialCheckStore : StoreOperateBillBase
    {
        public MaterialCheckStore()
        {
            MaterialCheckStoreDetails = new List<MaterialCheckStoreDetail>();
        }

        public int CheckStoreID { get; set; }        // 盘存库房

        public virtual ICollection<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }
    }
}
