using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum MedicineTypeEnum
    {
        xiyao,
        zhongchengyao,
        zhongyao
    }
    public enum YiBaoEnum
    {
        jia,
        yi,
        feijiafeiyi
    }

    public enum DosageFormEnum
    {
        片剂,
        颗粒,
        水剂
    }

    [DataContract]
    public class Medicine: GoodsBase
    {
        public Medicine()
        {

        }
        
        [DataMember]
        public MedicineTypeEnum MedicineTypeEnum { get; set; }      // 药品类型
        [DataMember]
        public string Abbr1 { get; set; }                           // 别名1
        [DataMember]
        public string Abbr2 { get; set; }                           // 别名2
        [DataMember]
        public string Abbr3 { get; set; }                           // 别名3
        [DataMember]
        public DosageFormEnum DosageFormEnum { get; set; }          // 药品剂型       
        [DataMember]
        public string AdministrationRoute { get; set; }             // 给药方式
        [DataMember]
        public bool PoisonousHemp { get; set; }                     // 毒麻
        [DataMember]
        public bool Valuable { get; set; }                          // 贵重
        [DataMember]
        public bool EssentialDrugs { get; set; }                    // 基本药物
    }
}
