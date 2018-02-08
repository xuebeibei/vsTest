using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 用药处方医嘱收费单
    /// </summary>
    public class MedicineCharge : ChargeBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MedicineCharge()
        {
            MedicineChargeDetails = new List<MedicineChargeDetail>();
        }

        /// <summary>
        /// 药品医嘱ID
        /// </summary>
        public int MedicineDoctorAdviceID { get; set; }
        /// <summary>
        /// 药品医嘱
        /// </summary>
        public MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        /// <summary>
        /// 药品医嘱明细列表
        /// </summary>
        public virtual ICollection<MedicineChargeDetail> MedicineChargeDetails { get; set; }
    }
}
