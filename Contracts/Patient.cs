using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum GenderEnum { man, woman };
    public enum VolkEnum { hanzu, other };

    [DataContract]
    public class Patient
    {
        [DataMember]
        public int ID { get; set; }              // 患者ID
        [DataMember]
        public string Name { get; set; }         // 姓名
        [DataMember]
        public GenderEnum Gender { get; set; }   // 性别
        [DataMember]
        public DateTime BirthDay { get; set; }   // 出生日期
        [DataMember]
        public string IDCardNo { get; set; }     // 身份证
        [DataMember]
        public VolkEnum Volk { get; set; }       // 民族
        [DataMember]
        public string Tel { get; set; }                          // 电话，患者电话
        [DataMember]
        public string JiGuan { get; set; }       // 籍贯
        [DataMember]
        public List<Registration> Registrations { get; set; } // 所有门诊挂号
        [DataMember]
        public List<Inpatient> Inpatients { get; set; }

    }
}
