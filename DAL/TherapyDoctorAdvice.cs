using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱
    public class TherapyDoctorAdvice : DoctorAdviceBase
    {
        public TherapyDoctorAdvice()
        {
            TherapyDoctorAdviceDetails = new List<TherapyDoctorAdviceDetail>();
            TherapyCharges = new List<TherapyCharge>();
        }
        public virtual ICollection<TherapyDoctorAdviceDetail> TherapyDoctorAdviceDetails { get; set; }
        public virtual ICollection<TherapyCharge> TherapyCharges { get; set; }
    }
}
