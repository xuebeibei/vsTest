using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 收费单基类
    public class ChargeBase
    {
        public int ID { get; set; }                               // ID
        public string NO { get; set; }                            // 收费单编号
        public DateTime? ChargeTime { get; set; }                 // 收费时间  
        public int ChargeUserID { get; set; }                     // 收费人员
        public decimal SumOfMoney { get; set; }                   // 收费金额
        public virtual User ChargeUser { get; set; }
    }
}
