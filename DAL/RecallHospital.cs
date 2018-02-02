using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RecallHospital : MyTableBase
    {
        public int LeaveHospitalID { get; set; }
        public DateTime RecallTime { get; set; }
        public string Reason { get; set; }
        public LeaveHospital LeaveHospital { get; set; }
    }
}
