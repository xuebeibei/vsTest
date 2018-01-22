using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineDoctorAdvice : DoctorAdviceBase
    {
        public MedicineDoctorAdvice()
        {
        }

        [DataMember]
        public RecipeContentEnum RecipeContentEnum { get; set; }
        [DataMember]
        public List<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }
    }
}
