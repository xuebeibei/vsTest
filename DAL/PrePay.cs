using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 预付单
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay”的 XML 注释
    public class PrePay
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.No”的 XML 注释
        public string No { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.No”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.PrePayTime”的 XML 注释
        public DateTime? PrePayTime { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.PrePayTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.PrePayMoney”的 XML 注释
        public decimal PrePayMoney { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.PrePayMoney”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.PayerName”的 XML 注释
        public string PayerName { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.PayerName”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.PrePayWayEnum”的 XML 注释
        public PrePayWayEnum PrePayWayEnum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.PrePayWayEnum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.PatientID”的 XML 注释
        public int PatientID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.PatientID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.UserID”的 XML 注释
        public int UserID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.UserID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.Patient”的 XML 注释
        public virtual Patient Patient { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.Patient”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PrePay.User”的 XML 注释
        public virtual User User { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PrePay.User”的 XML 注释
    }
}
