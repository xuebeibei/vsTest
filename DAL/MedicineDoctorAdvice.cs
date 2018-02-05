using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方医嘱
    public class MedicineDoctorAdvice : DoctorAdviceBase
    {
        public MedicineDoctorAdvice()
        {
            MedicineDoctorAdviceDetails = new List<MedicineDoctorAdviceDetail>();
            MedicineCharges = new List<MedicineCharge>();
        }
        public DoctorAdviceContentEnum RecipeContentEnum { get; set; }
        public virtual ICollection<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }

        public virtual ICollection<MedicineCharge> MedicineCharges { get; set; }
        public virtual ICollection<InjectionBill> InjectionBills { get; set; }
    }
}
