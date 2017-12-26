using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Therapy
    {
        public Therapy()
        {
            TherapyDetails = new List<TherapyDetail>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NO { get; set; }                                  // 编号
        [DataMember]
        public int RegistrationID { get; set; }                        // 门诊ID
        [DataMember]
        public int InpatientID { get; set; }                           // 住院ID
        [DataMember]
        public double SumOfMoney { get; set; }                         // 金额
        [DataMember]
        public DateTime WriteTime { get; set; }                        // 开具时间
        [DataMember]
        public int WriteUserID { get; set; }                           // 开具医生
        [DataMember]
        public virtual LoginUser WriteUser { get; set; }               // 开具医生
        [DataMember]
        public virtual ICollection<TherapyDetail> TherapyDetails { get; set; }
    }
}
