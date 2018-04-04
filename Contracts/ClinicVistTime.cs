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
        /// 看诊起始时间
        /// </summary>
        [DataMember]
        public string StartVistTime { get; set; }

        /// <summary>
        /// 看诊结束时间
        /// </summary>
        [DataMember]
        public string EndVistTime { get; set; }

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
    }
}
