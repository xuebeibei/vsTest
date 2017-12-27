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

    [DataContract]
    public class Medicine
    {
        public Medicine()
        {

        }

        [DataMember]
        public int ID { get; set; }                                 // ID
        [DataMember]
        public MedicineTypeEnum MedicineTypeEnum { get; set; }      // 药品类型
        [DataMember]
        public string Name { get; set; }                            // 药品品名
        [DataMember]
        public int DosageFormID { get; set; }                       // 药品剂型ID       
        [DataMember]
        public string AdministrationRoute { get; set; }             // 给药方式
        [DataMember]
        public string Specifications { get; set; }                  // 规格
        [DataMember]
        public string Manufacturer { get; set; }                    // 生产厂家
        [DataMember]
        public bool PoisonousHemp { get; set; }                     // 毒麻
        [DataMember]
        public bool Valuable { get; set; }                          // 贵重
        [DataMember]
        public bool EssentialDrugs { get; set; }                    // 基本药物
        [DataMember]
        public YiBaoEnum YiBaoEnum { get; set; }                    // 医保甲乙类
        [DataMember]
        public int MaxNum { get; set; }                             // 最大库存量
        [DataMember]
        public int MinNum { get; set; }                             // 最小库存量

    }
}
