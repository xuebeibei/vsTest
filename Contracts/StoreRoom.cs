using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum StoreRoomEnum
    {
        一级库,
        二级库,
        三级库
    }

    [DataContract]
    public class StoreRoom
    {
        public StoreRoom()
        {
        }
        [DataMember]
        public int ID { get; set; }          // ID
        [DataMember]
        public string Name { get; set; }     // 库房名称
        [DataMember]
        public string Address { get; set; }  // 库房地址
        [DataMember]
        public string Contents { get; set; } // 库房联系人
        [DataMember]
        public string Tel { get; set; }      // 库房联系方式
        [DataMember]
        public StoreRoomEnum StoreRoomEnum { get; set; }  // 库房的等级
        [DataMember]
        public List<StoreRoomMedicineNum> StoreRoomMedicineBatchs { get; set; }
    }
}
