using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 材料物资医嘱
    /// </summary>
    public class MaterialDoctorAdvice : DoctorAdviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialDoctorAdvice()
        {
            MaterialDoctorAdviceDetails = new List<MaterialDoctorAdviceDetail>();
            MaterialCharges = new List<MaterialCharge>();
        }
        /// <summary>
        /// 材料医嘱明细列表
        /// </summary>
        public virtual ICollection<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
        /// <summary>
        /// 材料医嘱对应的收费单列表
        /// </summary>
        public virtual ICollection<MaterialCharge> MaterialCharges { get; set; }
    }
}
