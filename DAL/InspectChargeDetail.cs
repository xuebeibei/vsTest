using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查医嘱收费单明细
    /// </summary>
    public class InspectChargeDetail : ChargeDetailBase
    {
        /// <summary>
        /// 检查项目ID
        /// </summary>
        public int InspectID { get; set; }
        /// <summary>
        /// 检查医嘱收费单ID
        /// </summary>
        public int InspectChargeID { get; set; }

        /// <summary>
        /// 检查医嘱收费单
        /// </summary>
        public virtual InspectCharge InspectCharge { get; set; }
        /// <summary>
        /// 检查项
        /// </summary>
        public virtual InspectItem Inspect { get; set; }
    }
}
