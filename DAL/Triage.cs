using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 分诊表
    /// </summary>
    public class Triage
    {
        // 分诊表，记录分诊结果
        /// <summary>
        /// 构造函数
        /// </summary>
        public Triage()
        {

        }
        /// <summary>
        /// 分诊ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 挂号单ID
        /// </summary>
        public int RegistrationID { get; set; }
        /// <summary>
        /// 分诊医生ID
        /// </summary>
        public int DoctorID { get; set; }
        /// <summary>
        /// 分诊经办人
        /// </summary>
        public Employee User { get; set; }
        /// <summary>
        /// 分诊时间
        /// </summary>
        public DateTime? DateTime { get; set; }
    }
}
