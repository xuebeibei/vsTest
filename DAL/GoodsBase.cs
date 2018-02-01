using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GoodsBase
    {
        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        public string Unit { get; set; }                            // 单位
        public string Specifications { get; set; }                  // 规格
        public string Manufacturer { get; set; }                    // 生产厂家
        public YiBaoEnum YiBaoEnum { get; set; }                    // 医保甲乙类
        public int MaxNum { get; set; }                             // 最大库存量
        public int MinNum { get; set; }                             // 最小库存量
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }                      // 零售价
    }
}
