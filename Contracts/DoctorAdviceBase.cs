using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class DoctorAdviceBase
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NO { get; set; }
        [DataMember]
        public decimal SumOfMoney { get; set; }                 // 金额
        [DataMember]
        public DateTime? WriteTime { get; set; }                // 开具时间
        [DataMember]
        public int WriteDoctorUserID { get; set; }              // 开具医生
        [DataMember]
        public int PatientID { get; set; }                      // 所属患者
        [DataMember]
        public User WriteDoctorUser { get; set; }       // 开具医生
        [DataMember]
        public Patient Patient { get; set; }
    }
}
