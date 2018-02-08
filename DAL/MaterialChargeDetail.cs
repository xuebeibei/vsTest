using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 材料物资医嘱收费单明细
    /// </summary>
    public class MaterialChargeDetail : ChargeDetailBase
    {
        /// <summary>
        /// 所对应的材料库存信息ID
        /// </summary>
        public int StoreRoomMaterialNumID { get; set; }
        /// <summary>
        /// 材料收费单ID
        /// </summary>
        public int MaterialChargeID { get; set; }

        /// <summary>
        /// 材料收费单
        /// </summary>
        public virtual MaterialCharge MaterialCharge { get; set; }
        /// <summary>
        /// 所对应的材料库存信息
        /// </summary>
        public virtual StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
    }
}
