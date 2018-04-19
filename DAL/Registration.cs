using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 挂号
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Registration()
        {
            this.RegisterFee = 0.0m;
            this.RegisterTime = DateTime.Now;
            this.SeeDoctorStatus = SeeDoctorStatusEnum.未到诊;
            this.TriageStatus = TriageStatusEnum.no;
            this.MedicalRecords = new List<MedicalRecord>();
        }

        /// <summary>
        /// 挂号单ID
        /// </summary>
        public int ID { get; set; } 

        /// <summary>
        /// 患者ID
        /// </summary>
        public int PatientID { get; set; }

        /// <summary>
        /// 号源ID
        /// </summary>
        public int SignalSourceID { get; set; }
        /// <summary>
        /// 经办人ID
        /// </summary>
        public int RegisterUserID { get; set; }

        /// <summary>
        /// 挂号费用
        /// </summary>
        public decimal RegisterFee { get; set; }

        /// <summary>
        /// 经办时间
        /// </summary>
        public DateTime? RegisterTime { get; set; }

        /// <summary>
        /// 看诊状态
        /// </summary>
        public SeeDoctorStatusEnum SeeDoctorStatus { get; set; }

        /// <summary>
        /// 分诊状态
        /// </summary>
        public TriageStatusEnum TriageStatus { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public PayWayEnum PayWayEnum { get; set; }
 
        /// <summary>
        /// 到诊用户ID
        /// </summary>
        public int ArriveUserID { get; set; }
        /// <summary>
        /// 到诊时间
        /// </summary>
        public DateTime? ArriveTime { get; set; }
        /// <summary>
        /// 开始看诊时间
        /// </summary>
        public DateTime? StartSeeDoctorTime { get; set; }               // 开始看诊时间 
        /// <summary>
        /// 结束看诊时间
        /// </summary>
        public DateTime? EndSeeDoctorTime { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }                      // 
        /// <summary>
        /// 号源
        /// </summary>
        public virtual WorkPlan SignalSource { get; set; }            // 号源
        /// <summary>
        /// 经办人
        /// </summary>
        public virtual Employee RegisterUser { get; set; }                    // 经办人
        /// <summary>
        /// 病例列表
        /// </summary>
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }  // 病历列表
    }
}
