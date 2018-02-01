using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱明细
    public class TherapyDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int TherapyID { get; set; }               // 治疗项目
        public int TherapyDoctorAdviceID { get; set; }

        public virtual TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
        public virtual TherapyItem Therapy { get; set; }
    }
}
