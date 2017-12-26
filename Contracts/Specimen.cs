﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Specimen
    {
        // 检验标本
        public Specimen()
        {
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string AbbrPY { get; set; }
        [DataMember]
        public string AbbrWB { get; set; }
    }
}
