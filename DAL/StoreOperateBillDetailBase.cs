using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库存操作明细基类
    public class StoreOperateBillDetailBase
    {
        public int ID { get; set; }                      // ID
        public string Batch { get; set; }                // 批次
        public DateTime? ExpirationDate { get; set; }    // 有效期
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }          // 成本价
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }           // 零售价
        public int Num { get; set; }                     // 数量
    }
}
