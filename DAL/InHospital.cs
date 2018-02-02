using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InHospital : MyTableBase
    {
        public InHospital()
        {
            LeaveHospitals = new List<LeaveHospital>();
            InHospitalPatientDoctors = new List<InHospitalPatientDoctor>();
        }
        public string NO { get; set; }
        public int PatientID { get; set; }       
        public DateTime InTime { get; set; }
        public string Diagnosis { get; set; }
        public InHospitalStatusEnum InHospitalStatusEnum { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<LeaveHospital> LeaveHospitals { get; set; }
        public virtual ICollection<InHospitalPatientDoctor> InHospitalPatientDoctors { get; set; }
    }
}
