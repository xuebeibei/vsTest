using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查医嘱明细
    /// </summary>
    public class InspectDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        /// <summary>
        /// 检查项目ID
        /// </summary>
        public int InspectID { get; set; }
        /// <summary>
        /// 检查医嘱ID
        /// </summary>
        public int InspectDoctorAdviceID { get; set; }

        /// <summary>
        /// 检查医嘱
        /// </summary>
        public virtual InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        /// <summary>
        /// 检查项目
        /// </summary>
        public virtual InspectItem Inspect { get; set; }
    }
}
