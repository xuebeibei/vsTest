using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 门诊医生看诊时间段
    /// </summary>
    [DataContract]
    public class ClinicVistTime
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 时间段名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 看诊起始时间的小时
        /// </summary>
        [DataMember]
        public int StartVistTimeHH { get; set; }

        /// <summary>
        /// 看诊起始时间的分钟
        /// </summary>
        [DataMember]
        public int StartVistTimeMM { get; set; }

        /// <summary>
        /// 看诊起始时间的秒钟
        /// </summary>
        [DataMember]
        public int StartVistTimeSS { get; set; }

        /// <summary>
        /// 看诊结束时间的小时
        /// </summary>
        [DataMember]
        public int EndVistTimeHH { get; set; }

        /// <summary>
        /// 看诊结束时间的分钟
        /// </summary>
        [DataMember]
        public int EndVistTimeMM { get; set; }

        /// <summary>
        /// 看诊结束时间的秒钟
        /// </summary>
        [DataMember]
        public int EndVistTimeSS { get; set; }


        /// <summary>
        /// 候诊起始时间的小时
        /// </summary>
        [DataMember]
        public int StartWaitTimeHH { get; set; }

        /// <summary>
        /// 候诊起始时间的分钟
        /// </summary>
        [DataMember]
        public int StartWaitTimeMM { get; set; }

        /// <summary>
        /// 候诊起始时间的秒钟
        /// </summary>
        [DataMember]
        public int StartWaitTimeSS { get; set; }

        /// <summary>
        /// 候诊结束时间的小时
        /// </summary>
        [DataMember]
        public int EndWaitTimeHH { get; set; }

        /// <summary>
        /// 候诊结束时间的分钟
        /// </summary>
        [DataMember]
        public int EndWaitTimeMM { get; set; }

        /// <summary>
        /// 候诊结束时间的秒钟
        /// </summary>
        [DataMember]
        public int EndWaitTimeSS { get; set; }

        /// <summary>
        /// 当天最后挂号时间的小时
        /// </summary>
        [DataMember]
        public int LastSellTimeHH { get; set; }

        /// <summary>
        /// 当天最后挂号时间的分钟
        /// </summary>
        [DataMember]
        public int LastSellTimeMM { get; set; }

        /// <summary>
        /// 当天最后挂号时间的秒钟
        /// </summary>
        [DataMember]
        public int LastSellTimeSS { get; set; }
    }
}
