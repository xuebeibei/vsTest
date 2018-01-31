using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class GoodsBase
    {
        [DataMember]
        public int ID { get; set; }                                 // ID
        [DataMember]
        public string Name { get; set; }                            // 名
        [DataMember]
        public string AbbrPY { get; set; }                          // 拼音简称
        [DataMember]
        public string AbbrWB { get; set; }                          // 五笔简称
        [DataMember]
        public string Unit { get; set; }                            // 单位
        [DataMember]
        public string Specifications { get; set; }                  // 规格
        [DataMember]
        public string Manufacturer { get; set; }                    // 生产厂家
        [DataMember]
        public YiBaoEnum YiBaoEnum { get; set; }                    // 医保甲乙类
        [DataMember]
        public int MaxNum { get; set; }                             // 最大库存量
        [DataMember]
        public int MinNum { get; set; }                             // 最小库存量
        [DataMember]
        public decimal SellPrice { get; set; }                      // 零售价
    }
}
