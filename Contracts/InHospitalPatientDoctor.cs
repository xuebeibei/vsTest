using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InHospitalPatientDoctor : MyTableBase
    {
        [DataMember]
        public int InHospitalID { get; set; }
        [DataMember]
        public int DoctorID { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime? EndTime { get; set; }
        [DataMember]
        public Employee Doctor { get; set; }
    }
}
