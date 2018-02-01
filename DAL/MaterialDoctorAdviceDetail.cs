using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 材料物资医嘱明细
    public class MaterialDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int MaterialID { get; set; }               // 物资材料
        public int MaterialDoctorAdviceID { get; set; }

        public virtual MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        public virtual MaterialItem Material { get; set; }
    }
}
