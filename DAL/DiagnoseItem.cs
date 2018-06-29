using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 诊断项
    /// </summary>
    public class DiagnoseItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DiagnoseItem()
        {
            ClinicDoctorAdvice_DiagnoseItems = new List<ClinicDoctorAdvice_DiagnoseItem>();
        }
        /// <summary>
        /// 诊断ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 诊断名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 诊断名称的拼音缩写，用来搜索
        /// </summary>
        public string Abbr { get; set; }

        /// <summary>
        /// 医嘱诊断明细外键
        /// </summary>
        public virtual ICollection<ClinicDoctorAdvice_DiagnoseItem> ClinicDoctorAdvice_DiagnoseItems { get; set; }

    }

    /// <summary>
    /// 医嘱诊断明细表
    /// </summary>
    public class ClinicDoctorAdvice_DiagnoseItem
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 医嘱单ID
        /// </summary>
        public int ClinicDoctorAdviceID { get; set; }

        /// <summary>
        /// 诊断项ID
        /// </summary>
        public int DiagnoseItemID { get; set; }

        /// <summary>
        /// 诊断项
        /// </summary>
        public virtual DiagnoseItem DiagnoseItem { get; set; }
        
        /// <summary>
        /// 医嘱外键
        /// </summary>
        public virtual ClinicDoctorAdvice ClinicDoctorAdvice { get; set; }
    }
}
