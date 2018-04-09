using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
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
            Registrations = new List<Registration>();
        }

        /// <summary>
        /// 门诊排班记录ID
        /// </summary>
        public int ID { get; set; }                  // 号源ID

        /// <summary>
        /// 门诊医事服务费
        /// </summary>
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }           // 号源单价


        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime? VistDate { get; set; }       // 看诊日期

        /// <summary>
        /// 工作量
        /// </summary>
        public int MaxNum { get; set; }               // 最大号源

        /// <summary>
        /// 门诊坐诊类别ID，即号源类别ID
        /// </summary>
        public int SignalItemID { get; set; }         // 号源种类

        /// <summary>
        /// 排班医生ID
        /// </summary>
        public int EmployeeID { get; set; }           // 值班医生

        /// <summary>
        /// 排班科室ID
        /// </summary>
        public int DepartmentID { get; set; }         // 所属科室

        /// <summary>
        /// 门诊坐诊类别，即号源类别
        /// </summary>
        public virtual SignalItem SignalItem { get; set; }
        
        /// <summary>
        ///  时段ID
        /// </summary>
        public int ClinicVistTimeID { get; set; }

        /// <summary>
        /// 值班时段
        /// </summary>
        public virtual ClinicVistTime ClinicVistTime { get; set; }

        /// <summary>
        /// 所有门诊挂号
        /// </summary>
        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号     
    }
}
