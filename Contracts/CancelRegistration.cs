using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 退号单
    /// </summary>
    [DataContract]
    public class CancelRegistration
    {
        /// <summary>
        /// 退号ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 退号对应的挂号ID
        /// </summary>
        [DataMember]
        public int RegistrationID { get; set; }
        /// <summary>
        /// 退号对应的挂号单
        /// </summary>
        [DataMember]
        public Registration Registration { get; set; }

        /// <summary>
        /// 退号时间
        /// </summary>
        [DataMember]
        public DateTime CancelTime { get; set; }

        /// <summary>
        /// 此记录最后的更新时间
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTime { get; set; }
    }
}
