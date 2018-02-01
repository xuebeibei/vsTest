using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库房
    public class StoreRoom
    {
        public StoreRoom()
        {
            StoreRoomMedicineBatchs = new List<StoreRoomMedicineNum>();
        }

        public int ID { get; set; }          // ID
        public string Name { get; set; }     // 库房名称
        public string Abbr1 { get; set; }
        public string Abbr2 { get; set; }
        public string Abbr3 { get; set; }
        public string Address { get; set; }  // 库房地址
        public string Contents { get; set; } // 库房联系人
        public string Tel { get; set; }      // 库房联系方式
        public StoreRoomEnum StoreRoomEnum { get; set; }  // 库房的等级

        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineBatchs { get; set; }
    }
}
