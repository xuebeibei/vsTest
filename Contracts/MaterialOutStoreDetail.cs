using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialOutStoreDetail : StoreOperateBillDetailBase
    {
        [DataMember]
        public int StoreRoomMaterialNumID { get; set; }     // 库存ID
        [DataMember]
        public int NumBeforeOut { get; set; }               // 出库前数量 
        [DataMember]
        public int MaterialOutStoreID { get; set; }         // 出库单ID
        [DataMember]
        public StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
        
    }
}
