using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方收费单明细
    public class RecipeChargeDetail
    {
        public int ID { get; set; }
        public int StoreRoomMedicineNumID { get; set; }
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }
        public int Num { get; set; }
        public int Rebate { get; set; }
        public virtual RecipeChargeBill RecipeChargeBill { get; set; }
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }
}
