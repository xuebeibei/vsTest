using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库存操作表基类
    public class StoreOperateBillBase
    {
        public int ID { get; set; }                     // ID
        public string NO { get; set; }                  // 单号 
        public decimal SumOfMoney { get; set; }         // 总金额，成本价
        public DateTime? OperateTime { get; set; }      // 操作时间
        public string Remarks { get; set; }             // 备注
        public int OperateUserID { get; set; }          // 操作用户
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }      // 审核状态
        public int ReCheckUserID { get; set; }         // 复检用户 

        public virtual User OperateUser { get; set; }  // 制单用户
    }
}
