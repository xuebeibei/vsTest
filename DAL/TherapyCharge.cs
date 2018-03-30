using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱收费单
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyCharge”的 XML 注释
    public class TherapyCharge : ChargeBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyCharge”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyCharge()”的 XML 注释
        public TherapyCharge()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyCharge()”的 XML 注释
        {
            TherapyChargeDetails = new List<TherapyChargeDetail>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyDoctorAdviceID”的 XML 注释
        public int TherapyDoctorAdviceID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyDoctorAdviceID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyDoctorAdvice”的 XML 注释
        public TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyDoctorAdvice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyChargeDetails”的 XML 注释
        public virtual ICollection<TherapyChargeDetail> TherapyChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyCharge.TherapyChargeDetails”的 XML 注释
    }
}
