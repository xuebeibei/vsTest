using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class RecipeDetail
    {
        public RecipeDetail()
        {

        }

        [DataMember]
        public int ID { get; set; }                               // 处方正文ID
        [DataMember]
        public string GroupNum { set; get; }                      // 组别
        [DataMember]
        public int DrugID { get; set; }                           // 药品ID
        [DataMember]
        public int SingleDose { get; set; }                       // 单次剂量
        [DataMember]
        public string Usage { get; set; }                         // 用法
        [DataMember]
        public string DDDS { get; set; }                          // 使用频率
        [DataMember]
        public int DaysNum { get; set; }                          // 天数
        [DataMember]
        public int IntegralDose { get; set; }                     // 总量
        [DataMember]
        public string Illustration { get; set; }                  // 说明
        [DataMember]
        public int RecipeID { get; set; }                         // 所属处方ID
    }
}
