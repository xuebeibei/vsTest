using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 给药频次
    /// </summary>
    public class Frequency
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Frequency()
        {
            DoctorAdviceDetailGroups = new List<DoctorAdviceDetailGroup>();
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 给药频次名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 拼音简写，用来搜索
        /// </summary>
        public string Abbr { get; set; }
        /// <summary>
        /// 五笔简写，用来搜索
        /// </summary>
        public string WuBi { get; set; }
        /// <summary>
        /// 实际计算参数
        /// </summary>
        public decimal CoefficientNum { get; set; }

        /// <summary>
        /// 医嘱明细组列表
        /// </summary>
        public ICollection<DoctorAdviceDetailGroup> DoctorAdviceDetailGroups { get; set; }
    }
}
