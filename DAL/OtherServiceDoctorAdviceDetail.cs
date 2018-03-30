using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail”的 XML 注释
    public class OtherServiceDoctorAdviceDetail : DoctorAdviceDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherServiceID”的 XML 注释
        public int OtherServiceID { get; set; }               // 其他项目
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherServiceID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherServiceDoctorAdviceID”的 XML 注释
        public int OtherServiceDoctorAdviceID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherServiceDoctorAdviceID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherServiceDoctorAdvice”的 XML 注释
        public virtual OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherServiceDoctorAdvice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherService”的 XML 注释
        public virtual OtherServiceItem OtherService { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceDoctorAdviceDetail.OtherService”的 XML 注释
    }
}
