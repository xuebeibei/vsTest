using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱收费单
    public class TherapyCharge : ChargeBase
    {
        public TherapyCharge()
        {
            TherapyChargeDetails = new List<TherapyChargeDetail>();
        }
        public int TherapyDoctorAdviceID { get; set; }
        public TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
        public virtual ICollection<TherapyChargeDetail> TherapyChargeDetails { get; set; }
    }
}
