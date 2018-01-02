using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class StoreRoomMedicineNum
    {
        [DataMember]
        public int ID { get; set; }   // ID
        [DataMember]
        public int StoreRoomID { get; set; }  // 库房ID
        [DataMember]
        public int MedicineBatchID { get; set; } // 批次ID
        [DataMember]
        public int Num { get; set; }             // 库存
        [DataMember]
        public StoreRoom StoreRoom { get; set; }
        [DataMember]
        public MedicineBatch MedicineBatch { get; set; }
    }
}
