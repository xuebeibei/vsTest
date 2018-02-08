using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查医嘱收费单
    /// </summary>
    public class InspectCharge : ChargeBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InspectCharge()
        {
            InspectChargeDetails = new List<InspectChargeDetail>();
        }
        /// <summary>
        /// 对应检查医嘱ID
        /// </summary>
        public int InspectDoctorAdviceID { get; set; }
        /// <summary>
        /// 对应检查医嘱
        /// </summary>
        public InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        /// <summary>
        /// 检查医嘱收费单明细
        /// </summary>
        public virtual ICollection<InspectChargeDetail> InspectChargeDetails { get; set; }
    }
}
