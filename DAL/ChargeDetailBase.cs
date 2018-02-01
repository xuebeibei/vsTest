using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 收费明细基类
    public class ChargeDetailBase
    {
        public int ID { get; set; }                               // ID
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }                    // 单价
        public int AllNum { get; set; }                           // 数量
        public int Rebate { get; set; }                           // 折扣
    }
}
