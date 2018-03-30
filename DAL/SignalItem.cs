using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem”的 XML 注释
    public class SignalItem
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.SignalItem()”的 XML 注释
        public SignalItem()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.SignalItem()”的 XML 注释
        {
            SignalSources = new List<SignalSource>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.Name”的 XML 注释
        public string Name { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.Name”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.SignalTimeEnum”的 XML 注释
        public SignalTimeEnum SignalTimeEnum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.SignalTimeEnum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.MaxNum”的 XML 注释
        public int MaxNum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.MaxNum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.SellPrice”的 XML 注释
        public decimal SellPrice { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.SellPrice”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalItem.SignalSources”的 XML 注释
        public virtual ICollection<SignalSource> SignalSources { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalItem.SignalSources”的 XML 注释
    }
}
