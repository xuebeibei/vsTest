using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 化验医嘱
    public class AssayDoctorAdvice : DoctorAdviceBase
    {
        public AssayDoctorAdvice()
        {
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
            AssayCharges = new List<AssayCharge>();
        }
        public virtual ICollection<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
        public virtual ICollection<AssayCharge> AssayCharges { get; set; }
    }
}
