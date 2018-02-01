using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 检验医嘱
    public class InspectDoctorAdvice : DoctorAdviceBase
    {
        public InspectDoctorAdvice()
        {
            InspectDoctorAdviceDetails = new List<InspectDoctorAdviceDetail>();
            InspectCharges = new List<InspectCharge>();
        }
        public virtual ICollection<InspectDoctorAdviceDetail> InspectDoctorAdviceDetails { get; set; }
        public virtual ICollection<InspectCharge> InspectCharges { get; set; }
    }
}
