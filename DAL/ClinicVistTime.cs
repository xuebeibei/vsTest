using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 门诊医生看诊时间段
    /// </summary>
    public class ClinicVistTime
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 时间段名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 看诊起始时间
        /// </summary>
        public DateTime StartVistTime { get; set; }

        /// <summary>
        /// 看诊结束时间
        /// </summary>
        public DateTime EndVistTime { get; set; }

        /// <summary>
        /// 候诊起始时间
        /// </summary>
        public DateTime StartWaitTime { get; set; }

        /// <summary>
        /// 候诊结束时间
        /// </summary>
        public DateTime EndWaitTime { get; set; }

        /// <summary>
        /// 当天最后挂号时间
        /// </summary>
        public DateTime LastSellTime { get; set; }
    }
}
