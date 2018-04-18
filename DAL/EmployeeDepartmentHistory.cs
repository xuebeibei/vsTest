using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 员工部门变更表
    /// </summary>
    public class EmployeeDepartmentHistory
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }


        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Department { get; set; }
    }
}
