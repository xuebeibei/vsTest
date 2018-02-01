using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 化验医嘱收费单
    public class AssayCharge : ChargeBase
    {
        public AssayCharge()
        {
            AssayChargeDetails = new List<AssayChargeDetail>();
        }
        public int AssayDoctorAdviceID { get; set; }
        public AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        public virtual ICollection<AssayChargeDetail> AssayChargeDetails { get; set; }
    }
}
