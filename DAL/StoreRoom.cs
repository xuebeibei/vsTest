using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库房
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom”的 XML 注释
    public class StoreRoom
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.StoreRoom()”的 XML 注释
        public StoreRoom()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.StoreRoom()”的 XML 注释
        {
            StoreRoomMedicineBatchs = new List<StoreRoomMedicineNum>();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.ID”的 XML 注释
        public int ID { get; set; }          // ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Name”的 XML 注释
        public string Name { get; set; }     // 库房名称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Name”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Abbr1”的 XML 注释
        public string Abbr1 { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Abbr1”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Abbr2”的 XML 注释
        public string Abbr2 { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Abbr2”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Abbr3”的 XML 注释
        public string Abbr3 { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Abbr3”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Address”的 XML 注释
        public string Address { get; set; }  // 库房地址
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Address”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Contents”的 XML 注释
        public string Contents { get; set; } // 库房联系人
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Contents”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.Tel”的 XML 注释
        public string Tel { get; set; }      // 库房联系方式
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.Tel”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.StoreRoomEnum”的 XML 注释
        public StoreRoomEnum StoreRoomEnum { get; set; }  // 库房的等级
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.StoreRoomEnum”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoom.StoreRoomMedicineBatchs”的 XML 注释
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineBatchs { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoom.StoreRoomMedicineBatchs”的 XML 注释
    }
}
