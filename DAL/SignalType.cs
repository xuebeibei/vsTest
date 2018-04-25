using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 号别
    /// </summary>
    public class SignalType
    {
        /// <summary>
        /// 号别构造函数
        /// </summary>
        public SignalType()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值班类别ID
        /// </summary>
        public int WorkTypeID { get; set; }


        /// <summary>
        /// 医生职称
        /// </summary>
        public int JobID { get; set; }

        /// <summary>
        /// 门诊医师服务费
        /// </summary>
        [DecimalPrecision(18, 4)]
        public decimal DoctorClinicFee { get; set; }


        /// <summary>
        /// 对应值班类别
        /// </summary>
        public virtual WorkType WorkType { get; set; }

        /// <summary>
        /// 对应职位类别
        /// </summary>
        public virtual Job Job { get; set; }
    }
}
