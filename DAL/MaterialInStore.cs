using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资入库表
    public class MaterialInStore : StoreOperateBillBase
    {
        public MaterialInStore()
        {
            MaterialInStoreDetails = new List<MaterialInStoreDetail>();
        }
        public InStoreEnum InStoreEnum { get; set; }
        public int FromSupplierID { get; set; }      // 供应商
        public int ToStoreID { get; set; }           // 入库库房

        public virtual Supplier FromSupplier { get; set; }
        public virtual ICollection<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
    }
}
