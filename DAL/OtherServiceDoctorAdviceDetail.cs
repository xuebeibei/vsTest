using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱明细
    public class OtherServiceDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int OtherServiceID { get; set; }               // 其他项目
        public int OtherServiceDoctorAdviceID { get; set; }

        public virtual OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
        public virtual OtherServiceItem OtherService { get; set; }
    }
}
