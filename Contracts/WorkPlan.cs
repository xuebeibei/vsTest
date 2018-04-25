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
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 门诊排班记录ID
        /// </summary>
        [DataMember]
        public int DepartmentID { get; set; }

        /// <summary>
        /// 值班人员ID
        /// </summary>
        [DataMember]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 排班日期
        /// </summary>
        [DataMember]
        public DateTime? WorkPlanDate { get; set; }

        /// <summary>
        ///  时段ID
        /// </summary>
        [DataMember]
        public int ShiftID { get; set; }

        /// <summary>
        /// 值班类别
        /// </summary>
        [DataMember]
        public int WorkTypeID { get; set; }

        /// <summary>
        /// 工作量
        /// </summary>
        [DataMember]
        public int MaxNum { get; set; }

        /// <summary>
        /// 排班记录状态
        /// </summary>
        [DataMember]
        public WorkPlanStatus WorkPlanStatus { get; set; }


        /// <summary>
        /// 排班科室
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 值班人员
        /// </summary>
        public virtual Employee Employee { get; set; }

        [DataMember]
        public WorkType WorkType { get; set; }

        /// <summary>
        /// 值班时段
        /// </summary>
        [DataMember]
        public Shift Shift { get; set; }

    }
}
