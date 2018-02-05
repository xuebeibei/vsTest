using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InjectionBill : MyTableBase
    {
        public int MedicineDoctorAdviceID { get; set; }
        public string Result { get; set; }

        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
    }
}
