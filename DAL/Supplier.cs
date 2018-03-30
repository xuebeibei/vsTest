using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 供应商
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier”的 XML 注释
    public class Supplier
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Supplier()”的 XML 注释
        public Supplier()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Supplier()”的 XML 注释
        {
            MedicineInStores = new List<MedicineInStore>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Name”的 XML 注释
        public string Name { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Name”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Abbr1”的 XML 注释
        public string Abbr1 { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Abbr1”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Abbr2”的 XML 注释
        public string Abbr2 { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Abbr2”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Abbr3”的 XML 注释
        public string Abbr3 { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Abbr3”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Address”的 XML 注释
        public string Address { get; set; }  // 供应商地址
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Address”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Contents”的 XML 注释
        public string Contents { get; set; } // 供应商联系人
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Contents”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.Tel”的 XML 注释
        public string Tel { get; set; }      // 供应商联系方式
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.Tel”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.MedicineInStores”的 XML 注释
        public virtual ICollection<MedicineInStore> MedicineInStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.MedicineInStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Supplier.StoreRoomMedicineNums”的 XML 注释
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Supplier.StoreRoomMedicineNums”的 XML 注释
    }
}
