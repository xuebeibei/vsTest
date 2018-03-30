using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyTableBase”的 XML 注释
    public class MyTableBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyTableBase”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyTableBase.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyTableBase.ID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyTableBase.UserID”的 XML 注释
        public int UserID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyTableBase.UserID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyTableBase.CurrentTime”的 XML 注释
        public DateTime CurrentTime { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyTableBase.CurrentTime”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyTableBase.User”的 XML 注释
        public virtual User User { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyTableBase.User”的 XML 注释
    }
}
