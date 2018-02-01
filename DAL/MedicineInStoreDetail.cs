using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品入库明细
    public class MedicineInStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineInStoreDetail()
        {

        }
        public int MedicineID { get; set; }          // 对应药品字典
        public int MedicineInStoreID { get; set; }  // 入库单ID

        public virtual Medicine Medicine { get; set; }    // 药品字典外键
        public virtual MedicineInStore MedicineInStore { get; set; }   // 入库单外键
    }
}
