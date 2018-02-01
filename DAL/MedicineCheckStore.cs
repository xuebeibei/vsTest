using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品盘存表
    public class MedicineCheckStore : StoreOperateBillBase
    {
        public MedicineCheckStore()
        {
            MedicineCheckStoreDetails = new List<MedicineCheckStoreDetail>();
        }

        public int CheckStoreID { get; set; }        // 盘存库房

        public virtual ICollection<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
    }
}
