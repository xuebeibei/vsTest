using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库存表基类
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase”的 XML 注释
    public class StoreNumBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StoreNumBase()”的 XML 注释
        public StoreNumBase()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StoreNumBase()”的 XML 注释
        {
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.ID”的 XML 注释
        public int ID { get; set; }                  // ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StoreRoomID”的 XML 注释
        public int StoreRoomID { get; set; }         // 库房ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StoreRoomID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.SupplierID”的 XML 注释
        public int SupplierID { get; set; }          // 供应商ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.SupplierID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.Batch”的 XML 注释
        public string Batch { get; set; }            // 批次
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.Batch”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.ExpirationDate”的 XML 注释
        public DateTime? ExpirationDate { get; set; } // 有效期
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.ExpirationDate”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StorePrice”的 XML 注释
        public decimal StorePrice { get; set; }      // 成本价
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StorePrice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.Num”的 XML 注释
        public int Num { get; set; }                 // 库存
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.Num”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StoreRoom”的 XML 注释
        public virtual StoreRoom StoreRoom { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.StoreRoom”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreNumBase.Supplier”的 XML 注释
        public virtual Supplier Supplier { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreNumBase.Supplier”的 XML 注释
    }
}
