using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail”的 XML 注释
    public class TherapyDoctorAdviceDetail : DoctorAdviceDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.TherapyID”的 XML 注释
        public int TherapyID { get; set; }               // 治疗项目
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.TherapyID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.TherapyDoctorAdviceID”的 XML 注释
        public int TherapyDoctorAdviceID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.TherapyDoctorAdviceID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.TherapyDoctorAdvice”的 XML 注释
        public virtual TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.TherapyDoctorAdvice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.Therapy”的 XML 注释
        public virtual TherapyItem Therapy { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdviceDetail.Therapy”的 XML 注释
    }
}
