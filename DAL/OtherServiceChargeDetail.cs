using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱收费单明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail”的 XML 注释
    public class OtherServiceChargeDetail : ChargeDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherServiceID”的 XML 注释
        public int OtherServiceID { get; set; }               // 其他项目
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherServiceID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherServiceChargeID”的 XML 注释
        public int OtherServiceChargeID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherServiceChargeID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherServiceCharge”的 XML 注释
        public virtual OtherServiceCharge OtherServiceCharge { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherServiceCharge”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherService”的 XML 注释
        public virtual OtherServiceItem OtherService { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceChargeDetail.OtherService”的 XML 注释
    }
}
