using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    /// <summary>
    /// 收费单基类
    /// </summary>
    public class ChargeBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 收费单编号
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 收费时间
        /// </summary>
        public DateTime? ChargeTime { get; set; }
        /// <summary>
        /// 收费人员ID
        /// </summary>
        public int ChargeUserID { get; set; }
        /// <summary>
        /// 收费金额
        /// </summary>
        public decimal SumOfMoney { get; set; }
        /// <summary>
        /// 支付方式 0账户支付,1现金支付
        /// </summary>
        public PayWayEnum PayWayEnum { get; set; }
        /// <summary>
        /// 收费人员
        /// </summary>
        public virtual User ChargeUser { get; set; }
    }
}
