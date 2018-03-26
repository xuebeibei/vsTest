using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum GenderEnum { 男, 女 };
    public enum VolkEnum { 汉族, 其他 };
    public enum YbEnum
    {
        自费,
        城镇职工,
        城乡居民
    }

    [DataContract]
    public class Patient
    {
        [DataMember]
        public int ID { get; set; }              // 患者ID
        [DataMember]
        public string Name { get; set; }         // 姓名

        [DataMember]
        /// <summary>
        /// 医院患者编码
        /// </summary>
        public string PID { get; set; }
        [DataMember]
        /// <summary>
        /// 医院患者就诊卡号
        /// </summary>
        public string PatientCardNo { get; set; }

        [DataMember]
        public GenderEnum Gender { get; set; }   // 性别
        [DataMember]
        public DateTime? BirthDay { get; set; }   // 出生日期
        [DataMember]
        public string IDCardNo { get; set; }     // 身份证
        [DataMember]
        public VolkEnum Volk { get; set; }       // 民族
        [DataMember]
        public string Tel { get; set; }                          // 电话，患者电话
        [DataMember]
        /// <summary>
        /// 籍贯_省
        /// </summary>
        public string JiGuan_Sheng { get; set; }
        [DataMember]
        /// <summary>
        /// 籍贯_市
        /// </summary>
        public string JiGuan_Shi { get; set; }
        [DataMember]
        /// <summary>
        /// 籍贯_县
        /// </summary>
        public string JiGuan_Xian { get; set; }
        [DataMember]
        /// <summary>
        /// 医保类型
        /// </summary>
        public YbEnum YbEnum { get; set; }
        [DataMember]
        /// <summary>
        /// 医保卡号
        /// </summary>
        public string YbCardNo { get; set; }
        //[DataMember]
        //public List<Registration> Registrations { get; set; } // 所有门诊挂号
        //[DataMember]
        //public List<Inpatient> Inpatients { get; set; }

    }
}
