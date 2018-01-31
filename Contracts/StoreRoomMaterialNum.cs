using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class StoreRoomMaterialNum : StoreNumBase
    {
        public StoreRoomMaterialNum()
        {

        }
        [DataMember]
        public int MaterialItemID { get; set; }          // 对应药品字典
        [DataMember]
        public virtual MaterialItem MaterialItem { get; set; }
    }
}
