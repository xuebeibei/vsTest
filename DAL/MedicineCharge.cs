using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方医嘱收费单
    public class MedicineCharge : ChargeBase
    {
        public MedicineCharge()
        {
            MedicineChargeDetails = new List<MedicineChargeDetail>();
        }

        public int MedicineDoctorAdviceID { get; set; }                    // 所对应的的用药医嘱
        public MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        public virtual ICollection<MedicineChargeDetail> MedicineChargeDetails { get; set; }
    }
}
