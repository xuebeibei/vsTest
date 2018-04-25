using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 排班表内记录的状态
    /// </summary>
    public enum WorkPlanStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        eIsOk,
        /// <summary>
        /// 已经删除，不用
        /// </summary>
        eIsDelete,
        /// <summary>
        /// 暂停
        /// </summary>
        eIsTempStop
    }

    /// <summary>
    /// 门诊排班表
    /// </summary>
    public class WorkPlan
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkPlan()
        {
        }

        /// <summary>
        /// 门诊排班记录ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 排班科室ID
        /// </summary>
        public int DepartmentID { get; set; }


        /// <summary>
        /// 值班人员ID
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime? WorkPlanDate { get; set; }

        /// <summary>
        ///  时段ID
        /// </summary>
        public int ShiftID { get; set; }

        /// <summary>
        /// 值班类别ID，即号源类别ID
        /// </summary>
        public int WorkTypeID { get; set; }

        /// <summary>
        /// 工作量
        /// </summary>
        public int MaxNum { get; set; }

        /// <summary>
        /// 排班记录状态
        /// </summary>
        public WorkPlanStatus WorkPlanStatus { get; set; }



        ///////////////////外键/////////////////////



        /// <summary>
        /// 排班科室
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 值班人员
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 值班类别，是门诊值班还是住院值班还是急诊值班
        /// </summary>
        public virtual WorkType WorkType { get; set; }

        /// <summary>
        /// 值班时段
        /// </summary>
        public virtual Shift Shift { get; set; }
    }
}
