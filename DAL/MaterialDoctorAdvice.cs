using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 材料物资医嘱
    public class MaterialDoctorAdvice : DoctorAdviceBase
    {
        public MaterialDoctorAdvice()
        {
            MaterialDoctorAdviceDetails = new List<MaterialDoctorAdviceDetail>();
            MaterialCharges = new List<MaterialCharge>();
        }
        public virtual ICollection<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
        public virtual ICollection<MaterialCharge> MaterialCharges { get; set; }
    }
}
