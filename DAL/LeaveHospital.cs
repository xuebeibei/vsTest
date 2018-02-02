using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LeaveHospital : MyTableBase
    {
        public LeaveHospital()
        {
            RecallHospitals = new List<RecallHospital>();
        }
        public int InHospitalID { get; set; }
        public DateTime LeaveTime { get; set; }
        public string Diagnosis { get; set; }

        public virtual InHospital InHospital { get; set; }
        public virtual ICollection<RecallHospital> RecallHospitals { get; set; }
    }
}
