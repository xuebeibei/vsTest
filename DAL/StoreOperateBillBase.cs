using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库存操作表基类
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase”的 XML 注释
    public class StoreOperateBillBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.ID”的 XML 注释
        public int ID { get; set; }                     // ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.NO”的 XML 注释
        public string NO { get; set; }                  // 单号 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.NO”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.SumOfMoney”的 XML 注释
        public decimal SumOfMoney { get; set; }         // 总金额，成本价
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.SumOfMoney”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.OperateTime”的 XML 注释
        public DateTime? OperateTime { get; set; }      // 操作时间
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.OperateTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.Remarks”的 XML 注释
        public string Remarks { get; set; }             // 备注
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.Remarks”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.OperateUserID”的 XML 注释
        public int OperateUserID { get; set; }          // 操作用户
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.OperateUserID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.ReCheckStatusEnum”的 XML 注释
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }      // 审核状态
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.ReCheckStatusEnum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.ReCheckUserID”的 XML 注释
        public int ReCheckUserID { get; set; }         // 复检用户 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.ReCheckUserID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.OperateUser”的 XML 注释
        public virtual Employee OperateUser { get; set; }  // 制单用户
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreOperateBillBase.OperateUser”的 XML 注释
    }
}
