using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 医嘱组
    /// </summary>
    public class DoctorAdviceDetailGroup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DoctorAdviceDetailGroup()
        {
            DoctorAdviceItems = new List<DoctorAdviceDetail>();
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 组别号码
        /// </summary>
        public int GroupNum { get; set; }

        /// <summary>
        /// 医嘱外键ID
        /// </summary>
        public int ClinicDoctorAdviceID { get; set; }
        /// <summary>
        /// 医嘱外键
        /// </summary>
        public virtual ClinicDoctorAdvice ClinicDoctorAdvice { get; set; }

        /// <summary>
        /// 组别内的医嘱明细
        /// </summary>
        public ICollection<DoctorAdviceDetail> DoctorAdviceItems { get; set; }

    }
}
