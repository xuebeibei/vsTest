using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
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
        public DiagnoseItem DiagnoseItem { get; set; }

        /// <summary>
        /// 医嘱外键
        /// </summary>
        public ClinicDoctorAdvice ClinicDoctorAdvice { get; set; }
    }
}
