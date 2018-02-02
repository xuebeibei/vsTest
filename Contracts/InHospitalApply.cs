using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum InHospitalApplyEnum
    {
        未处理,
        已处理
    }

    [DataContract]
    public class InHospitalApply
    {
        public InHospitalApply()
        {
            ApplyTime = DateTime.Now;
            InHospitalApplyEnum = CommContracts.InHospitalApplyEnum.未处理;
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime ApplyTime { get; set; }
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public InHospitalApplyEnum InHospitalApplyEnum { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public Patient Patient { get; set; }
    }
}
