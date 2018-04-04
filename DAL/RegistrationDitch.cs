using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 放号渠道
    /// </summary>
    public class RegistrationDitch
    {
        /// <summary>
        /// 放号渠道ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 放号渠道名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 放号渠道优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 放号渠道占比
        /// </summary>
        public int Proportion { get; set; }
        /// <summary>
        /// 放号渠道状态
        /// </summary>
        public bool Status { get; set; }

    }
}
