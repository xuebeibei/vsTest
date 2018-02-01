using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱
    public class OtherServiceDoctorAdvice : DoctorAdviceBase
    {
        public OtherServiceDoctorAdvice()
        {
            OtherServiceDoctorAdviceDetails = new List<OtherServiceDoctorAdviceDetail>();
            OtherServiceCharges = new List<OtherServiceCharge>();
        }
        public virtual ICollection<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
        public virtual ICollection<OtherServiceCharge> OtherServiceCharges { get; set; }
    }
}
