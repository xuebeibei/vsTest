using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱收费单明细
    public class TherapyChargeDetail : ChargeDetailBase
    {
        public int TherapyID { get; set; }               // 治疗项目
        public int TherapyChargeID { get; set; }

        public virtual TherapyCharge TherapyCharge { get; set; }
        public virtual TherapyItem Therapy { get; set; }
    }
}
