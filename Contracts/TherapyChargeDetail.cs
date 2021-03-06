﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class TherapyChargeDetail : ChargeDetailBase
    {
        [DataMember]
        public int TherapyID { get; set; }               // 治疗项目
        [DataMember]
        public int TherapyChargeID { get; set; }
        [DataMember]
        public TherapyItem Therapy { get; set; }
    }
}
