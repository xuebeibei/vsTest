using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InjectionBill : MyTableBase
    {
        [DataMember]
        public int MedicineDoctorAdviceID { get; set; }
        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
    }
}
