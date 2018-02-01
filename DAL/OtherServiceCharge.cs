using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱收费单
    public class OtherServiceCharge : ChargeBase
    {
        public OtherServiceCharge()
        {
            OtherServiceChargeDetails = new List<OtherServiceChargeDetail>();
        }
        public int OtherServiceDoctorAdviceID { get; set; }
        public OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
        public virtual ICollection<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
    }
}
