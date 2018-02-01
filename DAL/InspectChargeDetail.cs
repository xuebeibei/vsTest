using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 检查医嘱收费单明细
    public class InspectChargeDetail : ChargeDetailBase
    {
        public int InspectID { get; set; }               // 检查项目
        public int InspectChargeID { get; set; }

        public virtual InspectCharge InspectCharge { get; set; }
        public virtual InspectItem Inspect { get; set; }
    }
}
