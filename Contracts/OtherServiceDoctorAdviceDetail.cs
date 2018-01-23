using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class OtherServiceDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        [DataMember]
        public int OtherServiceID { get; set; }               // 其他项目
        [DataMember]
        public int OtherServiceDoctorAdviceID { get; set; }
        [DataMember]
        public virtual OtherServiceItem OtherService { get; set; }
    }
}
