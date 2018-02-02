using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class RecallHospital : MyTableBase
    {
        [DataMember]
        public int LeaveHospitalID { get; set; }
        [DataMember]
        public DateTime RecallTime { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public LeaveHospital LeaveHospital { get; set; }
    }
}
