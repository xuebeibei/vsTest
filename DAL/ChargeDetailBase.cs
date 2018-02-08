using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 收费明细基类
    /// </summary>
    public class ChargeDetailBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int AllNum { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int Rebate { get; set; }
    }
}
