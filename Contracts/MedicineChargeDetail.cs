using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineChargeDetail : ChargeDetailBase
    {
        [DataMember]
        public int StoreRoomMedicineNumID { get; set; }         // 药品库存
        [DataMember]
        public int MedicineChargeID { get; set; }               // 所属收费单
        [DataMember]
        public StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }
}
