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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HunYinEnum.未填”的 XML 注释
        未填 = 0,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HunYinEnum.未填”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HunYinEnum.未婚”的 XML 注释
        未婚 = 1,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HunYinEnum.未婚”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HunYinEnum.已婚”的 XML 注释
        已婚 = 2,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HunYinEnum.已婚”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HunYinEnum.丧偶”的 XML 注释
        丧偶 = 3,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HunYinEnum.丧偶”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HunYinEnum.离婚”的 XML 注释
        离婚 = 4,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HunYinEnum.离婚”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HunYinEnum.其他”的 XML 注释
        其他 = 9
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HunYinEnum.其他”的 XML 注释
    }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientCardEnum”的 XML 注释
    public enum PatientCardEnum
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientCardEnum”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientCardEnum.普通卡”的 XML 注释
        普通卡,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientCardEnum.普通卡”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientCardEnum.临时卡”的 XML 注释
        临时卡
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientCardEnum.临时卡”的 XML 注释
    }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CountryEnum”的 XML 注释
    public enum CountryEnum
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CountryEnum”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CountryEnum.中国”的 XML 注释
        中国,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CountryEnum.中国”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CountryEnum.其他”的 XML 注释
        其他
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CountryEnum.其他”的 XML 注释
    }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum”的 XML 注释
    public enum PatientJobEnum
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum”的 XML 注释
    {
        //11.国家公务员、13.专业技术人员、17.职员、21.企业管理人员、24.工人、27.农民、31.学生、37.现役军人、51.自由职业者、54.个体经营者、70.无业人员、80.退（离）休人员、90.其他
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.未填”的 XML 注释
        未填 = 0,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.未填”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.国家公务员”的 XML 注释
        国家公务员 = 11,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.国家公务员”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.专业技术人员”的 XML 注释
        专业技术人员 = 13,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.专业技术人员”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.职员”的 XML 注释
        职员 = 17,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.职员”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.企业管理人员”的 XML 注释
        企业管理人员 = 21,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.企业管理人员”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.工人”的 XML 注释
        工人 = 24,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.工人”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.农民”的 XML 注释
        农民 = 27,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.农民”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.学生”的 XML 注释
        学生 = 31,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.学生”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.现役军人”的 XML 注释
        现役军人 = 37,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.现役军人”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.自由职业者”的 XML 注释
        自由职业者 = 51,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.自由职业者”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.个体经营者”的 XML 注释
        个体经营者 = 54,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.个体经营者”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.无业人员”的 XML 注释
        无业人员 = 70,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.无业人员”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.退休离休人员”的 XML 注释
        退休离休人员 = 80,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.退休离休人员”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.其他”的 XML 注释
        其他 = 90
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“PatientJobEnum.其他”的 XML 注释
    }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum”的 XML 注释
    public enum GuanXiEnum
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum”的 XML 注释
    {
        /*
         * 联系人“关系”：指联系人与患者之间的关系，
         * 参照《家庭关系代码》国家标准（GB/T4761）填写：
         * 1.配偶，2.子，3.女，4.孙子、孙女或外孙子、外孙女，5.父母，
         * 6.祖父母或外祖父母，7.兄、弟、姐、妹，8/9.其他。
         * 根据联系人与患者实际关系情况填写，如：孙子。
         * 对于非家庭关系人员，统一使用“其他”，并可附加说明，如：同事。
         */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.未填”的 XML 注释
        未填 = 0,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.未填”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.配偶”的 XML 注释
        配偶 = 1,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.配偶”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.子”的 XML 注释
        子 = 2,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.子”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.女”的 XML 注释
        女 = 3,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.女”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.孙子孙女或外孙子外孙女”的 XML 注释
        孙子孙女或外孙子外孙女 = 4,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.孙子孙女或外孙子外孙女”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.父母”的 XML 注释
        父母 = 5,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.父母”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.祖父母或外祖父母”的 XML 注释
        祖父母或外祖父母 = 6,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.祖父母或外祖父母”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.兄弟姐妹”的 XML 注释
        兄弟姐妹 = 7,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.兄弟姐妹”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.其他”的 XML 注释
        其他 = 9
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“GuanXiEnum.其他”的 XML 注释
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
