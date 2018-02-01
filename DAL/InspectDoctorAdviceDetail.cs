using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 检验医嘱明细
    public class InspectDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int InspectID { get; set; }               // 检验项目
        public int InspectDoctorAdviceID { get; set; }

        public virtual InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        public virtual InspectItem Inspect { get; set; }
    }
}
