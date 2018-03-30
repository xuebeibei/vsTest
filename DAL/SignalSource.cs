using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource”的 XML 注释
    public class SignalSource
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.SignalSource()”的 XML 注释
        public SignalSource()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.SignalSource()”的 XML 注释
        {
            Registrations = new List<Registration>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.ID”的 XML 注释
        public int ID { get; set; }                  // 号源ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.ID”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.Price”的 XML 注释
        public decimal Price { get; set; }           // 号源单价
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.Price”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.VistTime”的 XML 注释
        public DateTime? VistTime { get; set; }       // 看诊日期
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.VistTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.MaxNum”的 XML 注释
        public int MaxNum { get; set; }               // 最大号源
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.MaxNum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.SignalItemID”的 XML 注释
        public int SignalItemID { get; set; }         // 号源种类
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.SignalItemID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.EmployeeID”的 XML 注释
        public int EmployeeID { get; set; }           // 值班医生
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.EmployeeID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.DepartmentID”的 XML 注释
        public int DepartmentID { get; set; }         // 所属科室
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.DepartmentID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.SignalItem”的 XML 注释
        public virtual SignalItem SignalItem { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.SignalItem”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“SignalSource.Registrations”的 XML 注释
        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号     
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“SignalSource.Registrations”的 XML 注释
    }
}
