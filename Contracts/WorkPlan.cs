using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 排班表内记录的状态
    /// </summary>
    public enum WorkPlanStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常,
        /// <summary>
        /// 已经删除，不用
        /// </summary>
        停诊,
        /// <summary>
        /// 暂停
        /// </summary>
        暂停
    }

    [DataContract]
    public class WorkPlan
    {
        [DataMember]
        public int ID { get; set; }                  // 号源ID
        [DataMember]
        public decimal Price { get; set; }           // 号源单价
        [DataMember]
        public DateTime? VistDate { get; set; }       // 看诊日期
        [DataMember]
        public int MaxNum { get; set; }               // 最大号源
        [DataMember]
        public int SignalItemID { get; set; }         // 号源种类
        [DataMember]
        public int EmployeeID { get; set; }           // 值班医生
        [DataMember]
        public int DepartmentID { get; set; }         // 所属科室
        [DataMember]
        public SignalItem SignalItem { get; set; }

        /// <summary>
        ///  时段ID
        /// </summary>
        [DataMember]
        public int ClinicVistTimeID { get; set; }

        /// <summary>
        /// 排班记录状态
        /// </summary>
        [DataMember]
        public WorkPlanStatus WorkPlanStatus { get; set; }

        /// <summary>
        /// 值班时段
        /// </summary>
        [DataMember]
        public ClinicVistTime ClinicVistTime { get; set; }

    }
}
