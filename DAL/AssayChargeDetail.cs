using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 化验医嘱收费单明细
    public class AssayChargeDetail : ChargeDetailBase
    {
        public int AssayID { get; set; }               // 化验项目
        public int AssayChargeID { get; set; }

        public virtual AssayCharge AssayCharge { get; set; }
        public virtual AssayItem Assay { get; set; }
    }
}
