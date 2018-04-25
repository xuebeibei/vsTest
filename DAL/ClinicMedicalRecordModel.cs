using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 模板使用范围
    /// </summary>
    public enum ModelUsageRangeEnum
    {
        /// <summary>
        /// 科室内可用
        /// </summary>
        eInDepartment = 0,

        /// <summary>
        /// 本人可用
        /// </summary>
        eInEmployee = 1
    }

    /// <summary>
    /// 门诊病历模板
    /// </summary>
    public class ClinicMedicalRecordModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 所属科室
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// 使用范围
        /// </summary>
        public ModelUsageRangeEnum ModelUsageRangeEnum { get; set; }

        /// <summary>
        /// 内容xml
        /// </summary>
        public string ContentXML { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 所属科室
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 编辑人
        /// </summary>
        public virtual Employee Employee { get; set; }
    }
}
