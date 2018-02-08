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
            this.ParentID = 0;
            Employees = new List<Employee>();
            SickRooms = new List<SickRoom>();
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
        /// 父科室，弃用
        /// </summary>
        public int ParentID { get; set; }    // 父类科室

        /// <summary>
        /// 员工列表
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
        /// <summary>
        /// 病房列表
        /// </summary>
        public virtual ICollection<SickRoom> SickRooms { get; set; }
    }
}
