using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum ChargeEnum
    {
        处方单,
        物资材料单,
        治疗单,
        化验申请,
        检查申请,
        其他
    }

    [DataContract]
    public class ChargeBase
    {
        public ChargeBase()
        {
            PayWayEnum = PayWayEnum.账户支付;
        }
        [DataMember]
        public int ID { get; set; }                               // ID
        [DataMember]
        public string NO { get; set; }                            // 收费单编号
        [DataMember]
        public DateTime? ChargeTime { get; set; }                 // 收费时间  
        [DataMember]
        public int ChargeUserID { get; set; }                     // 收费人员
        [DataMember]
        public decimal SumOfMoney { get; set; }                   // 收费金额
        [DataMember]
        public User ChargeUser { get; set; }
        [DataMember]
        public ChargeEnum ChargeEnum { get; set; }
        [DataMember]
        public PayWayEnum PayWayEnum { get; set; }
    }
}
