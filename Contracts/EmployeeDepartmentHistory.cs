using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class EmployeeDepartmentHistory
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        [DataMember]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [DataMember]
        public int DepartmentID { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }


        /// <summary>
        /// 员工
        /// </summary>
        [DataMember]
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [DataMember]
        public virtual Department Department { get; set; }
    }
}
