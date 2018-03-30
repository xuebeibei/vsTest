using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecallHospital”的 XML 注释
    public class RecallHospital : MyTableBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecallHospital”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecallHospital.LeaveHospitalID”的 XML 注释
        public int LeaveHospitalID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecallHospital.LeaveHospitalID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecallHospital.RecallTime”的 XML 注释
        public DateTime RecallTime { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecallHospital.RecallTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecallHospital.Reason”的 XML 注释
        public string Reason { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecallHospital.Reason”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecallHospital.LeaveHospital”的 XML 注释
        public virtual LeaveHospital LeaveHospital { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecallHospital.LeaveHospital”的 XML 注释
    }
}
