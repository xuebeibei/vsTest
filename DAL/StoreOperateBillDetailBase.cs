using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库存操作明细基类
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase”的 XML 注释
    public class StoreOperateBillDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.ID”的 XML 注释
        public int ID { get; set; }                      // ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.Batch”的 XML 注释
        public string Batch { get; set; }                // 批次
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.Batch”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.ExpirationDate”的 XML 注释
        public DateTime? ExpirationDate { get; set; }    // 有效期
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.ExpirationDate”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.StorePrice”的 XML 注释
        public decimal StorePrice { get; set; }          // 成本价
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.StorePrice”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.SellPrice”的 XML 注释
        public decimal SellPrice { get; set; }           // 零售价
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.SellPrice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.Num”的 XML 注释
        public int Num { get; set; }                     // 数量
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillDetailBase.Num”的 XML 注释
    }
}
