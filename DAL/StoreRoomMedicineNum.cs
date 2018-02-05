using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品库存
    public class StoreRoomMedicineNum : StoreNumBase
    {
        public StoreRoomMedicineNum()
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
            MedicineChargeDetails = new List<MedicineChargeDetail>();
        }
        public int MedicineID { get; set; }          // 对应药品字典

        public virtual Medicine Medicine { get; set; }
        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
        public virtual ICollection<MedicineChargeDetail> MedicineChargeDetails { get; set; }
    }
}
