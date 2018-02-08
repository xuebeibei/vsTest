using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 注射输液
    /// </summary>
    public class InjectionBill : MyTableBase
    {
        /// <summary>
        /// 用药医嘱ID
        /// </summary>
        public int MedicineDoctorAdviceID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 对应的用药医嘱
        /// </summary>
        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
    }
}
