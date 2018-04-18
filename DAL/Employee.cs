using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Employee()
        {
            Name = "";
            Users = new List<User>();
            InHospitalPatientDoctors = new List<InHospitalPatientDoctor>();
            EmployeeDepartmentHistorys = new List<EmployeeDepartmentHistory>();
            EmployeeJobHistorys = new List<EmployeeJobHistory>();
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 员工姓名拼音简称
        /// </summary>
        public string Abbr { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 员工对应的用户
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// 员工所负责的患者
        /// </summary>
        public virtual ICollection<InHospitalPatientDoctor> InHospitalPatientDoctors { get; set; }

        /// <summary>
        /// 员工部门变更历史
        /// </summary>
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistorys { get; set; }

        /// <summary>
        /// 员工职位变更历史
        /// </summary>
        public virtual ICollection<EmployeeJobHistory> EmployeeJobHistorys { get; set; }
    }
}
