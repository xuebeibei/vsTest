﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class InspectItem
    {
        public InspectItem()
        {
        }
        [DataMember]
        public int ID { get; set; }                             // ID
        [DataMember]
        public string Name { get; set; }                        // 名称
        [DataMember]
        public string AbbrPY { get; set; }                      // 拼音简称
        [DataMember]
        public string AbbrWB { get; set; }                      // 五笔简称
        [DataMember]
        public decimal Price { get; set; }                       // 价格
        [DataMember]
        public string Unit { get; set; }                        // 单位
        [DataMember]
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类 
    }
}
