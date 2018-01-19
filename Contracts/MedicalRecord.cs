using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum MedicalRecordEnum
    {
        MenZhen,              // 门诊病历
        RuYuan,               // 入院记录 
        BingCheng,            // 病程记录
        ChuYuan,              // 出院记录
        BiangAnShouYe         // 病案首页 
    }

    // 病历
    [DataContract]
    public class MedicalRecord
    {
        public MedicalRecord()
        {

        }

        [DataMember]
        public int ID { get; set; }                                   // ID
        [DataMember]
        public string NO { get; set; }                                // 病历号
        [DataMember]
        public MedicalRecordEnum MedicalRecordEnum { get; set; }  // 类别
        [DataMember]
        public int RegistrationID { get; set; }                       // 门诊ID
        [DataMember]
        public DateTime? WriteTime { get; set; }                       // 编辑时间
        [DataMember]
        public int WriteUserID { get; set; }                          // 编写人的用户ID
        [DataMember]
        public string ContentXml { get; set; }                        // 内容xml

        //public virtual Registration Registration { get; set; }
        //public virtual Inpatient Inpatient { get; set; }
    }
}
