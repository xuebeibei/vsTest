using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 放号渠道
    /// </summary>
    [DataContract]
    public class RegistrationDitch
    {
        /// <summary>
        /// 放号渠道ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 放号渠道名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 放号渠道优先级
        /// </summary>
        [DataMember]
        public int Priority { get; set; }
        /// <summary>
        /// 放号渠道占比
        /// </summary>
        [DataMember]
        public int Proportion { get; set; }
        /// <summary>
        /// 放号渠道状态
        /// </summary>
        [DataMember]
        public bool Status { get; set; }

    }
}
