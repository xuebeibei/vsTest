using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class EmployeeLoginHistory
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        [DataMember]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 登录地址
        /// </summary>
        [DataMember]
        public string LoginMachineCode { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        [DataMember]
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登出时间
        /// </summary>
        [DataMember]
        public DateTime? LoginOutTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
