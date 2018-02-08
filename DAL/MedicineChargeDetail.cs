using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 用药处方医嘱收费单明细
    /// </summary>
    public class MedicineChargeDetail : ChargeDetailBase
    {
        /// <summary>
        /// 药品库存
        /// </summary>
        public int StoreRoomMedicineNumID { get; set; }
        /// <summary>
        /// 所属收费单ID
        /// </summary>
        public int MedicineChargeID { get; set; }

        /// <summary>
        /// 所属收费单
        /// </summary>
        public virtual MedicineCharge MedicineCharge { get; set; }
        /// <summary>
        /// 消减库存
        /// </summary>
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }
}
