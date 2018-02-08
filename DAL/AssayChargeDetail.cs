using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 化验医嘱收费单明细
    /// </summary>
    public class AssayChargeDetail : ChargeDetailBase
    {
        /// <summary>
        /// 化验项目ID
        /// </summary>
        public int AssayID { get; set; }
        /// <summary>
        /// 化验单ID
        /// </summary>
        public int AssayChargeID { get; set; }
        /// <summary>
        /// 化验单
        /// </summary>
        public virtual AssayCharge AssayCharge { get; set; }
        /// <summary>
        /// 化验项目
        /// </summary>
        public virtual AssayItem Assay { get; set; }
    }
}
