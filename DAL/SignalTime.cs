using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 门诊医生看诊时间段
    /// </summary>
    public class SignalTime
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SignalTime()
        {
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 班次ID
        /// </summary>
        public int ShiftID { get; set; }

        /// <summary>
        /// 候诊起始时间
        /// </summary>
        public string StartWaitTime { get; set; }

        /// <summary>
        /// 候诊结束时间
        /// </summary>
        public string EndWaitTime { get; set; }

        /// <summary>
        /// 当天最后挂号时间
        /// </summary>
        public string LastSellTime { get; set; }

        /// <summary>
        /// 对应班次
        /// </summary>
        public virtual Shift Shift { get; set; }


        /// <summary>
        /// 我们通过如下映射来得到一对一的关系
        /// </summary>
        public class ClinicVistTimeMap : EntityTypeConfiguration<SignalTime>
        {
            /// <summary>
            /// 
            /// </summary>
            public ClinicVistTimeMap()
            {
                HasOptional(p => p.Shift).WithRequired();
            }
        }
    }
}
