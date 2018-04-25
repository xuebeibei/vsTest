using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 科室
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Department()
        {
            this.Name = "";
            this.Abbr = "";
            this.DepartmentEnum = DepartmentEnum.其他科室;
            SickRooms = new List<SickRoom>();
            EmployeeDepartmentHistorys = new List<EmployeeDepartmentHistory>();
            WorkPlans = new List<WorkPlan>();
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 科室简称
        /// </summary>
        public string Abbr { get; set; }
        /// <summary>
        /// 科室类型
        /// </summary>
        public DepartmentEnum DepartmentEnum { get; set; }

        /// <summary>
        /// 科室楼层指引
        /// </summary>
        public string DepartmentAddress { get; set; }

        /// <summary>
        /// 病房列表
        /// </summary>
        public virtual ICollection<SickRoom> SickRooms { get; set; }

        /// <summary>
        /// 员工部门变更历史
        /// </summary>
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistorys { get; set; }

        /// <summary>
        /// 该部门对应的排班记录
        /// </summary>
        public virtual ICollection<WorkPlan> WorkPlans { get; set; }
    }
}
