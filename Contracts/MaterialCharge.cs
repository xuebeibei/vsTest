using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialCharge : ChargeBase
    {
        public MaterialCharge()
        {
            ChargeEnum = ChargeEnum.物资材料单;
        }
        [DataMember]
        public int MaterialDoctorAdviceID { get; set; }                    // 所对应的的物资材料医嘱
        [DataMember]
        public MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        [DataMember]
        public List<MaterialChargeDetail> MaterialChargeDetails { get; set; }
    }
}
