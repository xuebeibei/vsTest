using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class Inpatient
    {
        public Inpatient()
        {

        }
        [DataMember]
        public int ID { get; set; }                              // ID
        [DataMember]
        public string No { get; set; }                           // 住院号
        [DataMember]
        public int PatientID { get; set; }                       // 患者ID
        [DataMember]
        public DateTime InHospitalTime { get; set; }             // 入院时间
        [DataMember]
        public int DoctorID { get; set; }                        // 接诊医生
        [DataMember]
        public int DepertmentID { get; set; }                    // 接诊科室
    }
}
