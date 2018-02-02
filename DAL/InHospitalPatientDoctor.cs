using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InHospitalPatientDoctor : MyTableBase
    {
        public int InHospitalID { get; set; }
        public int DoctorID { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual InHospital InHospital { get; set; }

        public virtual Employee Doctor { get; set; }
    }
}
