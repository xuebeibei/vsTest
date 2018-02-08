using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查医嘱
    /// </summary>
    public class InspectDoctorAdvice : DoctorAdviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InspectDoctorAdvice()
        {
            InspectDoctorAdviceDetails = new List<InspectDoctorAdviceDetail>();
            InspectCharges = new List<InspectCharge>();
        }
        /// <summary>
        /// 检查医嘱明细列表
        /// </summary>
        public virtual ICollection<InspectDoctorAdviceDetail> InspectDoctorAdviceDetails { get; set; }
        /// <summary>
        /// 检查医嘱对应收费单列表
        /// </summary>
        public virtual ICollection<InspectCharge> InspectCharges { get; set; }
    }
}
