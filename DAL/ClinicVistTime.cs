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
        /// 看诊起始时间的小时
        /// </summary>
        public int StartVistTimeHH { get; set; }

        /// <summary>
        /// 看诊起始时间的分钟
        /// </summary>
        public int StartVistTimeMM { get; set; }

        /// <summary>
        /// 看诊起始时间的秒钟
        /// </summary>
        public int StartVistTimeSS { get; set; }

        /// <summary>
        /// 看诊结束时间的小时
        /// </summary>
        public int EndVistTimeHH { get; set; }

        /// <summary>
        /// 看诊结束时间的分钟
        /// </summary>
        public int EndVistTimeMM { get; set; }

        /// <summary>
        /// 看诊结束时间的秒钟
        /// </summary>
        public int EndVistTimeSS { get; set; }


        /// <summary>
        /// 候诊起始时间的小时
        /// </summary>
        public int StartWaitTimeHH { get; set; }

        /// <summary>
        /// 候诊起始时间的分钟
        /// </summary>
        public int StartWaitTimeMM { get; set; }

        /// <summary>
        /// 候诊起始时间的秒钟
        /// </summary>
        public int StartWaitTimeSS { get; set; }

        /// <summary>
        /// 候诊结束时间的小时
        /// </summary>
        public int EndWaitTimeHH { get; set; }

        /// <summary>
        /// 候诊结束时间的分钟
        /// </summary>
        public int EndWaitTimeMM { get; set; }

        /// <summary>
        /// 候诊结束时间的秒钟
        /// </summary>
        public int EndWaitTimeSS { get; set; }

        /// <summary>
        /// 当天最后挂号时间的小时
        /// </summary>
        public int LastSellTimeHH { get; set; }

        /// <summary>
        /// 当天最后挂号时间的分钟
        /// </summary>
        public int LastSellTimeMM { get; set; }

        /// <summary>
        /// 当天最后挂号时间的秒钟
        /// </summary>
        public int LastSellTimeSS { get; set; }
    }
}
