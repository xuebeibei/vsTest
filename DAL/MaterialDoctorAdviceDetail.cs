using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 材料物资医嘱明细
    /// </summary>
    public class MaterialDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        /// <summary>
        /// 物资材料ID
        /// </summary>
        public int MaterialID { get; set; }
        /// <summary>
        /// 材料医嘱ID
        /// </summary>
        public int MaterialDoctorAdviceID { get; set; }

        /// <summary>
        /// 材料医嘱
        /// </summary>
        public virtual MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        /// <summary>
        /// 物资材料
        /// </summary>
        public virtual MaterialItem Material { get; set; }
    }
}
