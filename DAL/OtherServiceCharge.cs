using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱收费单
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge”的 XML 注释
    public class OtherServiceCharge : ChargeBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceCharge()”的 XML 注释
        public OtherServiceCharge()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceCharge()”的 XML 注释
        {
            OtherServiceChargeDetails = new List<OtherServiceChargeDetail>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceDoctorAdviceID”的 XML 注释
        public int OtherServiceDoctorAdviceID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceDoctorAdviceID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceDoctorAdvice”的 XML 注释
        public OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceDoctorAdvice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceChargeDetails”的 XML 注释
        public virtual ICollection<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceCharge.OtherServiceChargeDetails”的 XML 注释
    }
}
