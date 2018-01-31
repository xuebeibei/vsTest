using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class StoreRoomMedicineNum : StoreNumBase
    {
        [DataMember]
        public int MedicineID { get; set; }          // 对应药品字典

        [DataMember]
        public Medicine Medicine { get; set; }
    }
}
