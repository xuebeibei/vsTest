using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 费用类别
    /// </summary>
    public enum FeeTypeEnum
    {
        /// <summary>
        /// 自费
        /// </summary>
        eZiFei,

        /// <summary>
        /// 城镇职工医保
        /// </summary>
        eChengZhenZhiGong,

        /// <summary>
        /// 城乡居民
        /// </summary>
        eChengXiangJuMin
    }

    /// <summary>
    /// 证件类型
    /// </summary>
    public enum ZhengJianEnum
    {
        /// <summary>
        /// 身份证
        /// </summary>
        eIDCard
    }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    public enum HunYinEnum
    {
        未填 = 0,
        未婚 = 1,
        已婚 = 2,
        丧偶 = 3,
        离婚 = 4,
        其他 = 9
    }

    public enum PatientCardEnum
    {
        普通卡,
        临时卡
    }

    public enum CountryEnum
    {
        中国,
        其他
    }

    public enum PatientJobEnum
    {
        //11.国家公务员、13.专业技术人员、17.职员、21.企业管理人员、24.工人、27.农民、31.学生、37.现役军人、51.自由职业者、54.个体经营者、70.无业人员、80.退（离）休人员、90.其他
        未填 = 0,
        国家公务员 = 11,
        专业技术人员 = 13,
        职员 = 17,
        企业管理人员 = 21,
        工人 = 24,
        农民 = 27,
        学生 = 31,
        现役军人 = 37,
        自由职业者 = 51,
        个体经营者 = 54,
        无业人员 = 70,
        退休离休人员 = 80,
        其他 = 90
    }

    public enum GuanXiEnum
    {
        /*
         * 联系人“关系”：指联系人与患者之间的关系，
         * 参照《家庭关系代码》国家标准（GB/T4761）填写：
         * 1.配偶，2.子，3.女，4.孙子、孙女或外孙子、外孙女，5.父母，
         * 6.祖父母或外祖父母，7.兄、弟、姐、妹，8/9.其他。
         * 根据联系人与患者实际关系情况填写，如：孙子。
         * 对于非家庭关系人员，统一使用“其他”，并可附加说明，如：同事。
         */
        未填 = 0,
        配偶 = 1,
        子 = 2,
        女 = 3,
        孙子孙女或外孙子外孙女 = 4,
        父母 = 5,
        祖父母或外祖父母 = 6,
        兄弟姐妹 = 7,
        其他 = 9
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
        /// 患者ID
        /// </summary>
        
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// 医院患者编码
        /// </summary>
        
        public string PID { get; set; }

        /// <summary>
        /// 就诊卡类别
        /// </summary>
        
        public PatientCardEnum PatientCardEnum { get; set; }

        /// <summary>
        /// 医院患者就诊卡号
        /// </summary>
        
        public string PatientCardNo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        
        public ZhengJianEnum ZhengJianEnum { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        
        public string ZhengJianNum { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        
        public HunYinEnum HunYin { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        
        public CountryEnum Country { get; set; }

        /// <summary>
        /// 工作类别
        /// </summary>
        
        public PatientJobEnum PatientJob { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        
        public string JobUnit { get; set; }

        /// <summary>
        /// 单位电话
        /// </summary>
        
        public string JobUnitTel { get; set; }

        /// <summary>
        /// 家庭地址
        /// </summary>
        
        public string HomeAddress { get; set; }

        /// <summary>
        /// 家庭电话
        /// </summary>
        
        public string HomeTel { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ConnectName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ConnectTel { get; set; }

        /// <summary>
        /// 联系人与患者关系
        /// </summary>
        public GuanXiEnum ConnectGuanXi { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        
        public VolkEnum Volk { get; set; }

        /// <summary>
        /// 电话，患者电话
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
        /// 费别
        /// </summary>
        
        public FeeTypeEnum FeeTypeEnum { get; set; }

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
