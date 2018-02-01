using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 化验医嘱明细
    public class AssayDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int AssayID { get; set; }               // 化验项目
        public int AssayDoctorAdviceID { get; set; }

        public virtual AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        public virtual AssayItem Assay { get; set; }
    }
}
