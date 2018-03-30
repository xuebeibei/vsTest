using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗医嘱收费单明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail”的 XML 注释
    public class TherapyChargeDetail : ChargeDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.TherapyID”的 XML 注释
        public int TherapyID { get; set; }               // 治疗项目
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.TherapyID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.TherapyChargeID”的 XML 注释
        public int TherapyChargeID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.TherapyChargeID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.TherapyCharge”的 XML 注释
        public virtual TherapyCharge TherapyCharge { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.TherapyCharge”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.Therapy”的 XML 注释
        public virtual TherapyItem Therapy { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyChargeDetail.Therapy”的 XML 注释
    }
}
