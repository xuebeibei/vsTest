using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum GenderEnum { 男, 女 };
    public enum VolkEnum { 未填, 汉族, 少数民族 };
    public enum FeeTypeEnum
    {
        自费,
        城镇职工,
        城乡居民
    }

    public enum ZhengJianEnum
    {
        身份证
    }

    public enum HunYinEnum
    {
        未填 = 0,
        未婚 = 1,
        已婚 = 2,
        丧偶 = 3,
        离婚 = 4,
        其他 = 9
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

    /// <summary>
    /// 患者就诊卡当前状态
    /// </summary>
    public enum PatientCardStatusEnum
    {
        /// <summary>
        /// 新建可用状态
        /// </summary>
        新建,

        /// <summary>
        /// 挂失不可用状态
        /// </summary>
        挂失,

        /// <summary>
        /// 补办可用状态
        /// </summary>
        补办,

        /// <summary>
        /// 换卡可用状态
        /// </summary>
        换卡
    }

    [DataContract]
    public class Patient
    {
        public Patient()
        {
            Name = "";
            PatientCardEnum = PatientCardEnum.普通卡;
            Gender = GenderEnum.男;
            ZhengJianEnum = ZhengJianEnum.身份证;
            Country = CountryEnum.中国;
            Volk = VolkEnum.未填;
            HunYin = HunYinEnum.未填;
            PatientJob = PatientJobEnum.未填;
            ConnectGuanXi = GuanXiEnum.未填;

            FeeTypeEnum = FeeTypeEnum.自费;
            PatientCardStatus = PatientCardStatusEnum.新建;
        }

        /// <summary>
        /// 患者ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 医院患者编码
        /// </summary>
        [DataMember]
        public string PID { get; set; }

        /// <summary>
        /// 就诊卡类别
        /// </summary>
        [DataMember]
        public PatientCardEnum PatientCardEnum { get; set; }

        /// <summary>
        /// 医院患者就诊卡号
        /// </summary>
        [DataMember]
        public string PatientCardNo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DataMember]
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [DataMember]
        public ZhengJianEnum ZhengJianEnum { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        [DataMember]
        public string ZhengJianNum { get; set; } 

        /// <summary>
        /// 婚姻状况
        /// </summary>
        [DataMember]
        public HunYinEnum HunYin { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        [DataMember]
        public CountryEnum Country { get; set; }

        /// <summary>
        /// 工作类别
        /// </summary>
        [DataMember]
        public PatientJobEnum PatientJob { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        [DataMember]
        public string JobUnit { get; set; }

        /// <summary>
        /// 单位电话
        /// </summary>
        [DataMember]
        public string JobUnitTel { get; set; }

        /// <summary>
        /// 家庭地址
        /// </summary>
        [DataMember]
        public string HomeAddress { get; set; }

        /// <summary>
        /// 家庭电话
        /// </summary>
        [DataMember]
        public string HomeTel { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string ConnectName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [DataMember]
        public string ConnectTel { get; set; }

        /// <summary>
        /// 联系人与患者关系
        /// </summary>
        [DataMember]
        public GuanXiEnum ConnectGuanXi { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [DataMember]
        public VolkEnum Volk { get; set; }

        /// <summary>
        /// 电话，患者电话
        /// </summary>
        [DataMember]
        public string Tel { get; set; }

        /// <summary>
        /// 籍贯_省
        /// </summary>
        [DataMember]
        public string JiGuan_Sheng { get; set; }

        /// <summary>
        /// 籍贯_市
        /// </summary>
        [DataMember]
        public string JiGuan_Shi { get; set; }

        /// <summary>
        /// 籍贯_县
        /// </summary>
        [DataMember]
        public string JiGuan_Xian { get; set; }

        /// <summary>
        /// 费别
        /// </summary>
        [DataMember]
        public FeeTypeEnum FeeTypeEnum { get; set; }

        /// <summary>
        /// 医保卡号
        /// </summary>
        [DataMember]
        public string YbCardNo { get; set; }

        /// <summary>
        /// 患者就诊卡状态
        /// </summary>
        [DataMember]
        public PatientCardStatusEnum PatientCardStatus { get; set; }

        /// <summary>
        /// 患者就诊卡余额
        /// </summary>
        [DataMember]
        public decimal PatientCardBalance { get; set; }


    }
}
