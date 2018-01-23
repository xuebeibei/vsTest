﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class TherapyDoctorAdvice : DoctorAdviceBase
    {
        public TherapyDoctorAdvice()
        {
        }
        [DataMember]
        public List<TherapyDoctorAdviceDetail> TherapyDoctorAdviceDetails { get; set; }
    }
}
