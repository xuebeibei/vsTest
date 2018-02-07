using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 化验医嘱收费单
    /// </summary>
   
    public class AssayCharge : ChargeBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssayCharge()
        {
            AssayChargeDetails = new List<AssayChargeDetail>();
        }
        /// <summary>
        /// 化验医嘱ID
        /// </summary>
        public int AssayDoctorAdviceID { get; set; }
        /// <summary>
        /// 化验医嘱
        /// </summary>
        public AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        /// <summary>
        /// 化验医嘱收费单明细列表
        /// </summary>
        public virtual ICollection<AssayChargeDetail> AssayChargeDetails { get; set; }
    }
}
