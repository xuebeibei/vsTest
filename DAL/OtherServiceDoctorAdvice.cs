using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice”的 XML 注释
    public class OtherServiceDoctorAdvice : DoctorAdviceBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice.OtherServiceDoctorAdvice()”的 XML 注释
        public OtherServiceDoctorAdvice()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice.OtherServiceDoctorAdvice()”的 XML 注释
        {
            OtherServiceDoctorAdviceDetails = new List<OtherServiceDoctorAdviceDetail>();
            OtherServiceCharges = new List<OtherServiceCharge>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice.OtherServiceDoctorAdviceDetails”的 XML 注释
        public virtual ICollection<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice.OtherServiceDoctorAdviceDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice.OtherServiceCharges”的 XML 注释
        public virtual ICollection<OtherServiceCharge> OtherServiceCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdvice.OtherServiceCharges”的 XML 注释
    }
}
