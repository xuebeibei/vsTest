using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品入库表
    public class MedicineInStore : StoreOperateBillBase
    {
        public MedicineInStore()
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
        }
        public InStoreEnum InStoreEnum { get; set; }
        public int FromSupplierID { get; set; }      // 供应商
        public int ToStoreID { get; set; }           // 入库库房

        public virtual Supplier FromSupplier { get; set; }
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
    }
}
