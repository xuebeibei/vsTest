using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 检查医嘱收费单
    public class InspectCharge : ChargeBase
    {
        public InspectCharge()
        {
            InspectChargeDetails = new List<InspectChargeDetail>();
        }
        public int InspectDoctorAdviceID { get; set; }
        public InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        public virtual ICollection<InspectChargeDetail> InspectChargeDetails { get; set; }
    }
}
