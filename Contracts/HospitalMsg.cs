using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 医院信息
    /// </summary>
    [DataContract]
    public class HospitalMsg
    {
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        [DataMember]
        public string HospitalName { get; set; }

        /// <summary>
        /// 是否是医保定点
        /// </summary>
        [DataMember]
        public bool bIsYiBao { get; set; }

        /// <summary>
        /// 医保号
        /// </summary>
        [DataMember]
        public string YiBaoNo { get; set; }
    }
}
