using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class StoreOperateBillBase
    {
        public StoreOperateBillBase()
        {
            NO = "";
            OperateTime = DateTime.Now;
        }
        [DataMember]
        public int ID { get; set; }                     // ID
        [DataMember]
        public string NO { get; set; }                  // 单号 
        [DataMember]
        public decimal SumOfMoney { get; set; }         // 总金额，成本价
        [DataMember]
        public DateTime? OperateTime { get; set; }      // 操作时间
        [DataMember]
        public string Remarks { get; set; }             // 备注
        [DataMember]
        public int OperateUserID { get; set; }          // 操作用户
        [DataMember]
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }      // 审核状态
        [DataMember]
        public int ReCheckUserID { get; set; }         // 复检用户 
        [DataMember]
        public User OperateUser { get; set; }  // 制单用户
    }
}
