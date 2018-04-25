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
    public class SignalTime
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 班次ID
        /// </summary>
        [DataMember]
        public int ShiftID { get; set; }

        /// <summary>
        /// 候诊起始时间
        /// </summary>
        [DataMember]
        public string StartWaitTime { get; set; }

        /// <summary>
        /// 候诊结束时间
        /// </summary>
        [DataMember]
        public string EndWaitTime { get; set; }

        /// <summary>
        /// 当天最后挂号时间
        /// </summary>
        [DataMember]
        public string LastSellTime { get; set; }


        /// <summary>
        /// 对应班次
        /// </summary>
        [DataMember]
        public Shift Shift { get; set; }

    }
}
