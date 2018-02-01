using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 材料物资医嘱收费单
    public class MaterialCharge : ChargeBase
    {
        public MaterialCharge()
        {
            MaterialChargeDetails = new List<MaterialChargeDetail>();
        }
        public int MaterialDoctorAdviceID { get; set; }                    // 所对应的的物资材料医嘱
        public MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        public virtual ICollection<MaterialChargeDetail> MaterialChargeDetails { get; set; }
    }
}
