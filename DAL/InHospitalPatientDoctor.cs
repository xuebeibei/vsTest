using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 住院患者负责工作人员对应表
    /// </summary>
    public class InHospitalPatientDoctor : MyTableBase
    {
        /// <summary>
        /// 住院ID
        /// </summary>
        public int InHospitalID { get; set; }
        /// <summary>
        /// 工作人员ID
        /// </summary>
        public int DoctorID { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间，可为空，如果为空，则为当前负责
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 住院登记信息
        /// </summary>
        public virtual InHospital InHospital { get; set; }

        /// <summary>
        /// 工作人员信息
        /// </summary>
        public virtual Employee Doctor { get; set; }
    }
}
