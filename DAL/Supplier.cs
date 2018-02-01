using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 供应商
    public class Supplier
    {
        public Supplier()
        {
            MedicineInStores = new List<MedicineInStore>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr1 { get; set; }
        public string Abbr2 { get; set; }
        public string Abbr3 { get; set; }
        public string Address { get; set; }  // 供应商地址
        public string Contents { get; set; } // 供应商联系人
        public string Tel { get; set; }      // 供应商联系方式

        public virtual ICollection<MedicineInStore> MedicineInStores { get; set; }
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
    }
}
