using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方收费单
    public class RecipeChargeBill
    {
        public RecipeChargeBill()
        {
            RecipeChargeDetails = new List<RecipeChargeDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }
        public decimal SumOfMoney { get; set; }
        public DateTime? ChargeTime { get; set; }
        public int MedicineDoctorAdviceID { get; set; }
        public bool Block { get; set; }

        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        public virtual ICollection<RecipeChargeDetail> RecipeChargeDetails { get; set; }
    }
}
