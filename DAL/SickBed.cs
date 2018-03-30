using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 病床
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed”的 XML 注释
    public class SickBed
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.Name”的 XML 注释
        public string Name { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.Name”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.Price”的 XML 注释
        public decimal Price { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.Price”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.Unit”的 XML 注释
        public string Unit { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.Unit”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.SickRoomID”的 XML 注释
        public int SickRoomID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.SickRoomID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.Remarks”的 XML 注释
        public string Remarks { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.Remarks”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SickBed.SickRoom”的 XML 注释
        public virtual SickRoom SickRoom { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SickBed.SickRoom”的 XML 注释
    }
}
