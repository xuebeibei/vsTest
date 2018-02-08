using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 材料物资医嘱收费单
    /// </summary>
    public class MaterialCharge : ChargeBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialCharge()
        {
            MaterialChargeDetails = new List<MaterialChargeDetail>();
        }
        /// <summary>
        /// 所对应的的物资材料医嘱ID
        /// </summary>
        public int MaterialDoctorAdviceID { get; set; }
        /// <summary>
        /// 所对应的的物资材料医嘱
        /// </summary>
        public MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        /// <summary>
        /// 材料收费单明细
        /// </summary>
        public virtual ICollection<MaterialChargeDetail> MaterialChargeDetails { get; set; }
    }
}
