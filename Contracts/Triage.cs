using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Triage
    {
        // 分诊表，记录分诊结果
        public Triage()
        {

        }

        [DataMember]
        public int ID { get; set; }                            // 分诊ID
        [DataMember]
        public int RegistrationID { get; set; }                // 挂号单ID
        [DataMember]
        public int DoctorID { get; set; }                      // 分诊医生ID 
        [DataMember]
        public Employee User { get; set; }                    // 分诊经办人
        [DataMember]
        public DateTime? DateTime { get; set; }                 // 分诊时间
    }
}
