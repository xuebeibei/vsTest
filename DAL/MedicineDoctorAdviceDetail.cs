using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方医嘱明细
    public class MedicineDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int MedicineID { get; set; }               // 药品
        public int MedicineDoctorAdviceID { get; set; }

        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
