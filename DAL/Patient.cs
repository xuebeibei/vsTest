using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum YbEnum
    {
        eZiFei,
        eChengZhenZhiGong,
        eChengXiangJuMin
    }

    /// <summary>
    /// 患者表
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Patient()
        {
            this.Name = "";
            this.Gender = GenderEnum.man;
            this.Volk = VolkEnum.hanzu;
            Registrations = new List<Registration>();
            PrePays = new List<PrePay>();
            DoctorAdviceBases = new List<DoctorAdviceBase>();
            InHospitalApplys = new List<InHospitalApply>();
            InHospitals = new List<InHospital>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToBMIMsg()
        {
            string str = "姓名：" + this.Name + "\r\n" +
                        "性别：" + (this.Gender == DAL.GenderEnum.man ? "男" : "女") + "\r\n" +
                        "岁\r\n" +
                        "身高：165CM\r\n" +
                        "体重：50KG" + "\r\n" +
                        "BIM指数：" + "\r\n" +
                        "体温：" + "\r\n" +
                        "呼吸：" + "\r\n" +
                        "脉搏：" + "\r\n" +
                        "血压：" + "\r\n" +
                        "血糖浓度：" + "\r\n" +
                        "视力：" + "\r\n" +
                        "氧饱和度：" + "\r\n" +
                        "疼痛评分：" + "\r\n" +
                        "初步诊断：" + "\r\n";
            return str;
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 医院患者编码
        /// </summary>
        public string PID { get; set; }

        /// <summary>
        /// 医院患者就诊卡号
        /// </summary>
        public string PatientCardNo { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 患者生日
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNo { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public VolkEnum Volk { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 籍贯_省
        /// </summary>
        public string JiGuan_Sheng { get; set; }
        /// <summary>
        /// 籍贯_市
        /// </summary>
        public string JiGuan_Shi { get; set; }
        /// <summary>
        /// 籍贯_县
        /// </summary>
        public string JiGuan_Xian { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public YbEnum YbEnum { get; set; }

        /// <summary>
        /// 医保卡号
        /// </summary>
        public string YbCardNo { get; set; }

        /// <summary>
        /// 所有的门诊挂号
        /// </summary>
        public virtual ICollection<Registration> Registrations { get; set; }
        /// <summary>
        /// 所有的预付款
        /// </summary>
        public virtual ICollection<PrePay> PrePays { get; set; }
        /// <summary>
        /// 所有的医嘱
        /// </summary>
        public virtual ICollection<DoctorAdviceBase> DoctorAdviceBases { get; set; }
        /// <summary>
        /// 所有的住院申请
        /// </summary>
        public virtual ICollection<InHospitalApply> InHospitalApplys { get; set; }
        /// <summary>
        /// 所有的住院
        /// </summary>
        public virtual ICollection<InHospital> InHospitals { get; set; }

        /// <summary>
        /// 所有的就诊卡
        /// </summary>
        public virtual ICollection<PatientCardManage> PatientCards { get; set; }
    }
}
