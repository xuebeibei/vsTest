using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品出库表
    public class MedicineOutStore : StoreOperateBillBase
    {
        public MedicineOutStore()
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
        }

        public OutStoreEnum OutStoreEnum { get; set; }   // 出库类型
        public int FromStoreID { get; set; }
        public int ToStoreID { get; set; }
        public int ToOtherHospitalID { get; set; }
        public int ToSupplierID { get; set; }        // 供货商退货 

        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
    }
}
