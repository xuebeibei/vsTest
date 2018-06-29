using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
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
        public ClinicDoctorAdvice ClinicDoctorAdvice { get; set; }
        /// <summary>
        /// 组别内的医嘱明细
        /// </summary>
        public List<DoctorAdviceDetail> DoctorAdviceItems { get; set; }

    }
}
