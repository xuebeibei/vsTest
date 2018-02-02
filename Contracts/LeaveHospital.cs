using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class LeaveHospital : MyTableBase
    {
        public LeaveHospital()
        {
        }
        [DataMember]
        public int InHospitalID { get; set; }
        [DataMember]
        public DateTime LeaveTime { get; set; }
        [DataMember]
        public string Diagnosis { get; set; }
        [DataMember]
        public InHospital InHospital { get; set; }
        [DataMember]
        public List<RecallHospital> RecallHospitals { get; set; }
    }
}
