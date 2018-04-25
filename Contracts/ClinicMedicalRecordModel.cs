using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 模板使用范围
    /// </summary>
    public enum ModelUsageRangeEnum
    {
        /// <summary>
        /// 科室内可用
        /// </summary>
        科室内可用 = 0,

        /// <summary>
        /// 本人可用
        /// </summary>
        本人可用 = 1
    }

    [DataContract]
    public class ClinicMedicalRecordModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [DataMember]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 所属科室
        /// </summary>
        [DataMember]
        public int DepartmentID { get; set; }

        /// <summary>
        /// 使用范围
        /// </summary>
        [DataMember]
        public ModelUsageRangeEnum ModelUsageRangeEnum { get; set; }

        /// <summary>
        /// 内容xml
        /// </summary>
        [DataMember]
        public string ContentXML { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 所属科室
        /// </summary>
        [DataMember]
        public virtual Department Department { get; set; }

        /// <summary>
        /// 编辑人
        /// </summary>
        [DataMember]
        public virtual Employee Employee { get; set; }
    }
}
