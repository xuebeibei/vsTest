using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 化验项目
    /// </summary>    
    public class AssayItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssayItem()
        {
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
            AssayChargeDetails = new List<AssayChargeDetail>();
        }
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
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
        /// 价格
        /// </summary>
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 医保甲乙类
        /// </summary> 
        public YiBaoEnum YiBaoEnum { get; set; }                
        /// <summary>
        /// 化验医嘱明细
        /// </summary>
        public virtual ICollection<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
        /// <summary>
        /// 化验医嘱收费单明细
        /// </summary>
        public virtual ICollection<AssayChargeDetail> AssayChargeDetails { get; set; }
    }
}
