using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InHospital : MyTableBase
    {
        public InHospital()
        {
            InHospitalPatientDoctors = new List<InHospitalPatientDoctor>();
        }
        [DataMember]
        public string NO { get; set; }
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public DateTime InTime { get; set; }
        [DataMember]
        public string Diagnosis { get; set; }
        [DataMember]
        public InHospitalStatusEnum InHospitalStatusEnum { get; set; }
        [DataMember]
        public Patient Patient { get; set; }
        [DataMember]
        public List<LeaveHospital> LeaveHospitals { get; set; }
        [DataMember]
        public List<InHospitalPatientDoctor> InHospitalPatientDoctors { get; set; }
    }
}
