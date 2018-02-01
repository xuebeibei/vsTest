using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 材料物资医嘱收费单明细
    public class MaterialChargeDetail : ChargeDetailBase
    {
        public int StoreRoomMaterialNumID { get; set; }               // 物资材料
        public int MaterialChargeID { get; set; }

        public virtual MaterialCharge MaterialCharge { get; set; }
        public virtual StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
    }
}
