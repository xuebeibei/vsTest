using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class RecipeChargeBill
    {
        public RecipeChargeBill()
        {
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NO { get; set; }
        [DataMember]
        public decimal SumOfMoney { get; set; }
        [DataMember]
        public DateTime? ChargeTime { get; set; }
        [DataMember]
        public int RecipeID { get; set; }
        [DataMember]
        public bool Block { get; set; }
        [DataMember]
        public List<RecipeChargeDetail> RecipeChargeDetails { get; set; }
    }
}
