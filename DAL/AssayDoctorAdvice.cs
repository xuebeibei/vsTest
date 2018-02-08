using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 化验医嘱
    /// </summary>    
    public class AssayDoctorAdvice : DoctorAdviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssayDoctorAdvice()
        {
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
            AssayCharges = new List<AssayCharge>();
        }
        /// <summary>
        /// 化验医嘱明细列表
        /// </summary>
        public virtual ICollection<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
        /// <summary>
        /// 化验单对应的收费单
        /// </summary>
        public virtual ICollection<AssayCharge> AssayCharges { get; set; }
    }
}
