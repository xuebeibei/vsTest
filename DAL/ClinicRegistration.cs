using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 挂号单
    /// </summary>
    public class ClinicRegistration
    {
        /// <summary>
        /// 挂号ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 看诊日期
        /// </summary>
        public DateTime VistDoctorDate { get; set; }

        /// <summary>
        /// 挂号日期
        /// </summary>
        public DateTime RegistrationTime { get; set; }

        /// <summary>
        /// 对应医生工作排班ID
        /// </summary>
        public int DoctorClinicWorkPlanID { get; set; }

        /// <summary>
        /// 患者ID
        /// </summary>
        public int PatientID { get; set; }


        /// <summary>
        /// 就诊患者
        /// </summary>
        public virtual Patient Patient { get; set; }

    }
}
