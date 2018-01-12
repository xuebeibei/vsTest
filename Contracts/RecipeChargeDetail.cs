using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class RecipeChargeDetail
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StoreRoomMedicineNumID { get; set; }
        [DataMember]
        public decimal SellPrice { get; set; }
        [DataMember]
        public int Num { get; set; }
        [DataMember]
        public int Rebate { get; set; }
        [DataMember]
        public StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }
}
