using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 物品基类，有库存的
    /// </summary>
    public class GoodsBase
    {
        /// <summary>
        /// ID
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// 名
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 拼音简称
        /// </summary>

        public string AbbrPY { get; set; }
        /// <summary>
        /// 五笔简称
        /// </summary>

        public string AbbrWB { get; set; }
        /// <summary>
        /// 单位
        /// </summary>

        public string Unit { get; set; }
        /// <summary>
        /// 规格
        /// </summary>

        public string Specifications { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>

        public string Manufacturer { get; set; }
        /// <summary>
        /// 医保甲乙类
        /// </summary>

        public YiBaoEnum YiBaoEnum { get; set; }
        /// <summary>
        /// 最大库存量
        /// </summary>

        public int MaxNum { get; set; }
        /// <summary>
        /// 最小库存量
        /// </summary>

        public int MinNum { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>

        [DecimalPrecision(18, 4)]       
        public decimal SellPrice { get; set; }
    }
}
