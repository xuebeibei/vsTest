using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class EmployeeLoginHistory
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 登录地址
        /// </summary>
        public string LoginMachineCode { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登出时间
        /// </summary>
        public DateTime? LoginOutTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employees { get; set; }
    }
}
