using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 病房
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom”的 XML 注释
    public class SickRoom
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.SickRoom()”的 XML 注释
        public SickRoom()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.SickRoom()”的 XML 注释
        {
            SickBeds = new List<SickBed>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.Name”的 XML 注释
        public string Name { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.Name”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.SickRoomEnum”的 XML 注释
        public SickRoomEnum SickRoomEnum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.SickRoomEnum”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.DepartmentID”的 XML 注释
        public int DepartmentID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.DepartmentID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.Address”的 XML 注释
        public string Address { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.Address”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.Department”的 XML 注释
        public virtual Department Department { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.Department”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickRoom.SickBeds”的 XML 注释
        public virtual ICollection<SickBed> SickBeds { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickRoom.SickBeds”的 XML 注释
    }
}
