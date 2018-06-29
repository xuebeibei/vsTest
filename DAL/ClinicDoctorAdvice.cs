using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 门诊医嘱
    /// </summary>
    public class ClinicDoctorAdvice
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClinicDoctorAdvice()
        {
            ClinicDoctorAdvice_DiagnoseItems = new List<ClinicDoctorAdvice_DiagnoseItem>();
            DoctorAdviceDetailGroups = new List<DoctorAdviceDetailGroup>();
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 医嘱内容类别
        /// </summary>
        public DoctorAdviceItemType DoctorAdviceType { get; set; }
        /// <summary>
        /// 开立医嘱时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 是否紧急
        /// </summary>
        public bool IsExigence { get; set; }

        /// <summary>
        /// 挂号单ID
        /// </summary>
        public int ClinicRegistrationID { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 挂号
        /// </summary>
        public virtual ClinicRegistration ClinicRegistration { get; set; }

        /// <summary>
        /// 诊断
        /// </summary>
        public virtual ICollection<ClinicDoctorAdvice_DiagnoseItem> ClinicDoctorAdvice_DiagnoseItems { get; set; }

        /// <summary>
        /// 医嘱明细组列表
        /// </summary>
        public ICollection<DoctorAdviceDetailGroup> DoctorAdviceDetailGroups { get; set; }

    }
}
