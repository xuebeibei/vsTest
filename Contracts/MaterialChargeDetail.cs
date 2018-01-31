using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialChargeDetail : ChargeDetailBase
    {
        [DataMember]
        public int StoreRoomMaterialNumID { get; set; }               // 物资材料
        [DataMember]
        public int MaterialChargeID { get; set; }
        [DataMember]
        public StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
    }
}
