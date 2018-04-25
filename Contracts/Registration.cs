using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum PayWayEnum
    {
        账户支付,
        现金支付
    }

    public enum SeeDoctorStatusEnum { 未到诊, 候诊中, 接诊中, 接诊结束 , 申请入院 };
    public enum TriageStatusEnum { no, yes };

    [DataContract]    
    public class Registration
    {
        public Registration()
        {

        }
        /// <summary>
        /// 挂号单ID
        /// </summary>
        [DataMember]
        public int ID { get; set; } 
        /// <summary>
        /// 患者ID
        /// </summary>
        [DataMember]
        public int PatientID { get; set; }
        /// <summary>
        /// 挂号科室
        /// </summary>
        [DataMember]
        public int DepartmentID { get; set; }

        /// <summary>
        /// 号日期
        /// </summary>
        [DataMember]
        public DateTime SignalDate { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        [DataMember]
        public int SignalTimeID { get; set; }

        /// <summary>
        /// 号类别
        /// </summary>
        [DataMember]
        public int SignalTypeID { get; set; }
        /// <summary>
        /// 经办人ID
        /// </summary>
        [DataMember]
        public int RegisterUserID { get; set; }
        /// <summary>
        /// 挂号费用
        /// </summary>
        [DataMember]
        public decimal RegisterFee { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [DataMember]
        public DateTime? RegisterTime { get; set; }
        /// <summary>
        /// 看诊状态
        /// </summary>
        [DataMember]
        public SeeDoctorStatusEnum SeeDoctorStatus { get; set; }
        /// <summary>
        /// 分诊状态
        /// </summary>
        [DataMember]
        public TriageStatusEnum TriageStatus { get; set; }
        /// <summary>
        /// 患者
        /// </summary>
        [DataMember]
        public Patient Patient { get; set; }
        ///// <summary>
        ///// 号源
        ///// </summary>
        //[DataMember]
        //public WorkPlan SignalSource { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [DataMember]
        public Employee RegisterUser { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [DataMember]
        public PayWayEnum PayWayEnum { get; set; }
        /// <summary>
        /// 到诊用户ID
        /// </summary>
        [DataMember]
        public int ArriveUserID { get; set; }
        /// <summary>
        /// 到诊时间
        /// </summary>
        [DataMember]
        public DateTime? ArriveTime { get; set; }
        /// <summary>
        /// 开始看诊时间
        /// </summary>
        [DataMember]
        public DateTime? StartSeeDoctorTime { get; set; }
        /// <summary>
        /// 结束看诊时间
        /// </summary>
        [DataMember]
        public DateTime? EndSeeDoctorTime { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [DataMember]
        public virtual Department Department { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        [DataMember]
        public virtual SignalTime SignalTime { get; set; }

        /// <summary>
        /// 号类型
        /// </summary>
        [DataMember]
        public virtual SignalType SignalType { get; set; }

        public override bool Equals(object obj)
        {
            var temp = obj as Registration;
            if (temp == null)
                return false;
            if (temp.ID != this.ID)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
