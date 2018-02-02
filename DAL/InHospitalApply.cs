using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InHospitalApply
    {
        public InHospitalApply()
        {

        }
        public int ID { get; set; }
        public DateTime ApplyTime { get; set; }
        public int PatientID { get; set; }
        public int UserID { get; set; }
        public InHospitalApplyEnum InHospitalApplyEnum { get; set; }

        public virtual User User { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
