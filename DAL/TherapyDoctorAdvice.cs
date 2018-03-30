using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice”的 XML 注释
    public class TherapyDoctorAdvice : DoctorAdviceBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice.TherapyDoctorAdvice()”的 XML 注释
        public TherapyDoctorAdvice()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice.TherapyDoctorAdvice()”的 XML 注释
        {
            TherapyDoctorAdviceDetails = new List<TherapyDoctorAdviceDetail>();
            TherapyCharges = new List<TherapyCharge>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice.TherapyDoctorAdviceDetails”的 XML 注释
        public virtual ICollection<TherapyDoctorAdviceDetail> TherapyDoctorAdviceDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice.TherapyDoctorAdviceDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice.TherapyCharges”的 XML 注释
        public virtual ICollection<TherapyCharge> TherapyCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyDoctorAdvice.TherapyCharges”的 XML 注释
    }
}
