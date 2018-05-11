using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查项目
    /// </summary>
    public class InspectItem
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public InspectItem()
        {
            InspectDoctorAdviceDetail = new List<InspectDoctorAdviceDetail>();
            InspectChargeDetails = new List<InspectChargeDetail>();
        }

        /// <summary>
        /// 主键ID
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
        /// 检查医嘱明细列表
        /// </summary>
        public virtual ICollection<InspectDoctorAdviceDetail> InspectDoctorAdviceDetail { get; set; }
        /// <summary>
        /// 检查医嘱收费明细列表
        /// </summary>
        public virtual ICollection<InspectChargeDetail> InspectChargeDetails { get; set; }
    }
}
