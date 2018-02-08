using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 住院登记
    /// </summary>
    public class InHospital : MyTableBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InHospital()
        {
            LeaveHospitals = new List<LeaveHospital>();
            InHospitalPatientDoctors = new List<InHospitalPatientDoctor>();
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 对应患者ID
        /// </summary>
        public int PatientID { get; set; }
        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime InTime { get; set; }
        /// <summary>
        /// 入院诊断
        /// </summary>
        public string Diagnosis { get; set; }
        /// <summary>
        /// 住院状态
        /// </summary>
        public InHospitalStatusEnum InHospitalStatusEnum { get; set; }

        /// <summary>
        /// 对应患者
        /// </summary>
        public virtual Patient Patient { get; set; }
        /// <summary>
        /// 出院列表
        /// </summary>
        public virtual ICollection<LeaveHospital> LeaveHospitals { get; set; }
        /// <summary>
        /// 患者负责工作人员列表
        /// </summary>
        public virtual ICollection<InHospitalPatientDoctor> InHospitalPatientDoctors { get; set; }
    }
}
