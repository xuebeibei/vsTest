using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 化验医嘱明细
    /// </summary>    
    public class AssayDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        /// <summary>
        /// 化验项目ID
        /// </summary>
        public int AssayID { get; set; }
        /// <summary>
        /// 对应化验医嘱ID
        /// </summary>
        public int AssayDoctorAdviceID { get; set; }
        /// <summary>
        /// 对应化验医嘱
        /// </summary>
        public virtual AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        /// <summary>
        /// 化验项目
        /// </summary>
        public virtual AssayItem Assay { get; set; }
    }
}
