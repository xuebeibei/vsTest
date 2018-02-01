using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方医嘱收费单明细
    public class MedicineChargeDetail : ChargeDetailBase
    {
        public int StoreRoomMedicineNumID { get; set; }         // 药品库存
        public int MedicineChargeID { get; set; }               // 所属收费单

        public virtual MedicineCharge MedicineCharge { get; set; }
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }
}
