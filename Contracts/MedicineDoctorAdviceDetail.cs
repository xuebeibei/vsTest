using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        [DataMember]
        public int MedicineID { get; set; }               // 药品
        [DataMember]
        public int MedicineDoctorAdviceID { get; set; }
        [DataMember]
        public Medicine Medicine { get; set; }

    }
}
