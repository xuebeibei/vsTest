using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            InHospitalPatientDoctors = new List<InHospitalPatientDoctor>();
            EmployeeDepartmentHistorys = new List<EmployeeDepartmentHistory>();
            EmployeeJobHistorys = new List<EmployeeJobHistory>();
            EmployeeLoginHistorys = new List<EmployeeLoginHistory>();
            WorkPlans = new List<WorkPlan>();
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
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 门诊医师服务数量
        /// </summary>
        public int DoctorClinicNum { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedDate { get; set; }

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

        /// <summary>
        /// 员工登录历史
        /// </summary>
        public virtual ICollection<EmployeeLoginHistory> EmployeeLoginHistorys { get; set; }

        /// <summary>
        /// 该员工对应的排班记录
        /// </summary>
        public virtual ICollection<WorkPlan> WorkPlans { get; set; }
    }
}
