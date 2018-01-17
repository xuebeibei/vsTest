using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace DAL
{
    public enum GenderEnum { man, woman };
    public enum VolkEnum { hanzu, other };
    public enum SeeDoctorStatusEnum { watting, seeing, leaved };
    public enum TriageStatusEnum { no, yes };
    public enum JobEnum
    {
        初级,        // 初级
        中级,         // 中级
        高级          // 高级
    }
    public enum DepartmentEnum
    {
        其他科室,     // 其他科室
        临床科室, // 临床科室
        医技科室       // 医技科室  
    }

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

    public enum UsageEnum
    {
        口服,
        注射
    }

    public enum DDDSEnum
    {
        一日1次,
        一日2次,
        一日3次
    }

    /// <summary>
    /// <para>自定义Decimal类型的精度属性</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalPrecisionAttribute : Attribute
    {

        #region Field
        private byte _precision = 18;
        public byte _scale = 4;
        #endregion

        #region Construct
        /// <summary>
        /// <para>自定义Decimal类型的精确度属性</para>
        /// </summary>
        /// <param name="precision">precision
        /// <para>精度（默认18）</para></param>
        /// <param name="scale">scale
        /// <para>小数位数（默认4）</para></param>
        public DecimalPrecisionAttribute(byte precision = 18, byte scale = 4)
        {
            Precision = precision;
            Scale = scale;
        }
        #endregion

        #region Property
        /// <summary>
        /// 精确度（默认18）
        /// </summary>
        public byte Precision
        {
            get { return this._precision; }
            set { this._precision = value; }
        }

        /// <summary>
        /// 保留位数（默认4）
        /// </summary>
        public byte Scale
        {
            get { return this._scale; }
            set { this._scale = value; }
        }
        #endregion
    }

    /// <summary>
    /// 用于modelBuilder全局设置自定义精度属性
    /// </summary>
    public class DecimalPrecisionAttributeConvention
        : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DecimalPrecisionAttribute attribute)
        {
            if (attribute.Precision < 1 || attribute.Precision > 38)
            {
                throw new InvalidOperationException("Precision must be between 1 and 38.");
            }
            if (attribute.Scale > attribute.Precision)
            {
                throw new InvalidOperationException("Scale must be between 0 and the Precision value.");
            }
            configuration.HasPrecision(attribute.Precision, attribute.Scale);
        }
    }

    public class HisContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SignalSource> SignalSources { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Triage> Triages { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Inpatient> Inpatients { get; set; }
        public DbSet<AssayItem> AssayItems { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public DbSet<InspectItem> InspectItems { get; set; }
        public DbSet<BodyRegion> BodyRegions { get; set; }
        public DbSet<TherapyItem> TherapyItems { get; set; }
        public DbSet<MaterialItem> MaterialItems { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<TherapyDetail> TherapyDetails { get; set; }
        public DbSet<Assay> Assays { get; set; }
        public DbSet<AssayDetail> AssayDetails { get; set; }
        public DbSet<Inspect> Inspects { get; set; }
        public DbSet<InspectDetail> InspectDetails { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<MaterialBill> MaterialBills { get; set; }
        public DbSet<MaterialBillDetail> MaterialBillDetail { get; set; }
        public DbSet<OtherServiceItem> OtherServiceItem { get; set; }
        public DbSet<OtherService> OtherServices { get; set; }
        public DbSet<OtherServiceDetail> OtherServiceDetails { get; set; }

        public DbSet<MedicineInStore> MedicineInStores { get; set; }
        public DbSet<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        public DbSet<MedicineOutStore> MedicineOutStores { get; set; }
        public DbSet<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
        public DbSet<MedicineCheckStore> MedicineCheckStores { get; set; }
        public DbSet<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
        public DbSet<StoreRoom> StoreRooms { get; set; }
        public DbSet<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<RecipeChargeBill> RecipeChargeBills { get; set; }
        public DbSet<RecipeChargeDetail> RecipeChargeDetails { get; set; }

        public DbSet<SickRoom> SickRooms { get; set; }
        public DbSet<SickBed> SickBeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class User
    {
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.Status = LoginStatus.unknow;
            Registrations = new List<Registration>();
            Recipes = new List<Recipe>();
            Therapys = new List<Therapy>();
            Assays = new List<Assay>();
            Inspects = new List<Inspect>();
            Inpatients = new List<Inpatient>();
            MaterialBills = new List<MaterialBill>();
            OtherServices = new List<OtherService>();
            MedicineInStores = new List<MedicineInStore>();
        }
        public enum LoginStatus { invalid, unknow, logout, login };
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
        public DateTime? LastLogin { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号
        public virtual ICollection<Recipe> Recipes { get; set; }             // 所有开具的处方
        public virtual ICollection<Therapy> Therapys { get; set; }           // 所有开具的治疗单
        public virtual ICollection<Assay> Assays { get; set; }               // 所有开具的检验申请单
        public virtual ICollection<Inspect> Inspects { get; set; }           // 所有开具的检查申请单 
        public virtual ICollection<Inpatient> Inpatients { get; set; }       // 所有住院登记 
        public virtual ICollection<MaterialBill> MaterialBills { get; set; } // 所有材料单
        public virtual ICollection<OtherService> OtherServices { get; set; } // 所有其他服务单

        public virtual ICollection<MedicineInStore> MedicineInStores { get; set; }
    }

    public class Department
    {
        public Department()
        {
            this.Name = "";
            this.Abbr = "";
            this.DepartmentEnum = DepartmentEnum.其他科室;
            this.ParentID = 0;
            Employees = new List<Employee>();
            SickRooms = new List<SickRoom>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public DepartmentEnum DepartmentEnum { get; set; }
        public int ParentID { get; set; }    // 父类科室

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SickRoom> SickRooms { get; set; }
    }

    public class SignalSource
    {
        public SignalSource()
        {
            Registrations = new List<Registration>();
        }
        public int ID { get; set; }               // 号源ID
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }        // 号源单价

        public DateTime VistTime { get; set; }    // 看诊日期
        public int TimeIntival { get; set; }      // 看诊时段ID
        public int DepartmentID { get; set; }     // 科室
        public int SignalType { get; set; }       // 号别
        public int MaxNum { get; set; }           // 最大号源
        public int AddMaxNum { get; set; }        // 临时加号号源
        public int HasUsedNum { get; set; }       // 已挂号源
        public int Specialist { get; set; }       // 专家ID
        public string Explain { get; set; }       // 说明

        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号     
    }

    public class Registration
    {
        public Registration()
        {
            this.RegisterFee = 0.0m;
            this.RegisterTime = DateTime.Now;
            this.SeeDoctorStatus = SeeDoctorStatusEnum.watting;
            this.TriageStatus = TriageStatusEnum.no;
            this.MedicalRecords = new List<MedicalRecord>();
        }

        public override string ToString()
        {
            string str = Patient.Name + " " +
                        (Patient.Gender == DAL.GenderEnum.man ? "男 " : "女 ") +
                        (DateTime.Now.Year - Patient.BirthDay.Year).ToString() + "岁\r\n" +
                        "科室：外科\r\n" +
                        "医生：" + SignalSource.Specialist.ToString() + "\r\n" +
                        "看诊时间：" + SignalSource.VistTime.ToString() + "\r\n";
            return str;
        }


        public int ID { get; set; }                               // 挂号单ID
        public int PatientID { get; set; }                        // 患者ID
        public int SignalSourceID { get; set; }                   // 号源ID
        public int RegisterUserID { get; set; }                   // 经办人ID
        public decimal RegisterFee { get; set; }                   // 挂号费用
        public DateTime RegisterTime { get; set; }                // 经办时间
        public SeeDoctorStatusEnum SeeDoctorStatus { get; set; }  // 看诊状态
        public TriageStatusEnum TriageStatus { get; set; }        // 分诊状态

        public virtual Patient Patient { get; set; }                      // 患者
        public virtual SignalSource SignalSource { get; set; }            // 号源
        public virtual User RegisterUser { get; set; }                    // 经办人
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }  // 病历列表
    }

    public class Triage
    {
        // 分诊表，记录分诊结果
        public Triage()
        {

        }

        public int ID { get; set; }                            // 分诊ID
        public int RegistrationID { get; set; }                // 挂号单ID
        public int DoctorID { get; set; }                      // 分诊医生ID 
        public User User { get; set; }                         // 分诊经办人
        public DateTime DateTime { get; set; }                 // 分诊时间
    }

    public class Patient
    {
        public Patient()
        {
            this.Name = "";
            this.Gender = GenderEnum.man;
            this.Volk = VolkEnum.hanzu;
            Registrations = new List<Registration>();
            Inpatients = new List<Inpatient>();
        }

        public string ToBMIMsg()
        {
            string str = "姓名：" + this.Name + "\r\n" +
                        "性别：" + (this.Gender == DAL.GenderEnum.man ? "男" : "女") + "\r\n" +
                        "年龄：" + (DateTime.Now.Year - this.BirthDay.Year).ToString() + "岁\r\n" +
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
        public int ID { get; set; }              // 患者ID
        public string Name { get; set; }         // 姓名
        public GenderEnum Gender { get; set; }   // 性别
        public DateTime BirthDay { get; set; }   // 出生日期
        public VolkEnum Volk { get; set; }       // 民族

        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号
        public virtual ICollection<Inpatient> Inpatients { get; set; }       // 所有住院
    }

    public class Employee
    {
        public Employee()
        {
            Name = "";
            Users = new List<User>();
            Responsibilities = new List<Responsibility>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public int DepartmentID { get; set; }
        public int JobID { get; set; }

        public GenderEnum Gender { get; set; }   // 性别

        public virtual ICollection<User> Users { get; set; }
        public virtual Job Job { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Responsibility> Responsibilities { get; set; }
    }

    public class Job
    {
        public Job()
        {
            Name = "";
            Employees = new List<Employee>();
            JobEnum = JobEnum.初级;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Default { get; set; }
        public JobEnum JobEnum { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }

    public enum RecipeTypeEnum
    {
        PuTong,             // 普通处方
        JiZhen,             // 急诊处方
        ErKe,               // 儿科处方  
        MaJingYi,           // 麻精一   
        JingEr              // 精二  
    }

    public enum RecipeContentEnum
    {
        XiChengYao,
        ZhongYao
    }

    public enum ChargeStatusEnum
    {
        未收费,
        部分收费,
        全部收费
    }

    // 处方单
    public class Recipe
    {

        public Recipe()
        {
            this.RecipeTypeEnum = RecipeTypeEnum.PuTong;
            this.ChargeStatusEnum = ChargeStatusEnum.未收费;
            RecipeDetails = new List<RecipeDetail>();
        }

        public int ID { get; set; }                               // 处方ID
        public string No { get; set; }                            // 处方编号
        public RecipeTypeEnum RecipeTypeEnum { get; set; }        // 处方类型
        public RecipeContentEnum RecipeContentEnum { get; set; }  // 处方内容类别：西/ 成药、中药
        public string MedicalInstitution { get; set; }            // 医疗机构名称
        public int ChargeTypeEnum { get; set; }                   // 费别,*是否存在在门诊和住院中，待定
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID
        public string ClinicalDiagnosis { get; set; }             // 临床诊断
        public string PatientsIDCardNum { get; set; }             // 患者身份证    -- 麻醉和精一处方
        public string ProxyIDCardNum { get; set; }                // 代办人身份证  -- 麻醉和精一处方
        public string ProxyName { get; set; }                     // 代办人姓名    -- 麻醉和精一处方

        public decimal SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
        public ChargeStatusEnum ChargeStatusEnum { get; set; }

        public virtual User WriteUser { get; set; }               // 开具医生
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }

    // 处方单明细
    public class RecipeDetail
    {
        public RecipeDetail()
        {
        }

        public int ID { get; set; }                               // 处方正文ID
        public string GroupNum { set; get; }                      // 组别
        public int MedicineID { get; set; }                       // 药品ID
        public int SingleDose { get; set; }                       // 单次剂量
        public UsageEnum Usage { get; set; }                      // 用法
        public DDDSEnum DDDS { get; set; }                        // 使用频率
        public int DaysNum { get; set; }                          // 天数
        public int IntegralDose { get; set; }                     // 总量
        public string Illustration { get; set; }                  // 说明

        public int RecipeID { get; set; }                         // 所属处方ID
        public virtual Recipe Recipe { get; set; }

        public virtual Medicine Medicine { get; set; }
    }

    public enum DosageFormEnum
    {
        片剂,
        颗粒,
        水剂
    }

    // 药品字典
    public class Medicine
    {
        public Medicine()
        {
            RecipeDetails = new List<RecipeDetail>();
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
        }

        public int ID { get; set; }                                 // ID
        public MedicineTypeEnum MedicineTypeEnum { get; set; }      // 药品类型
        public string Name { get; set; }                            // 药品品名
        public string Abbr1 { get; set; }                           // 别名1
        public string Abbr2 { get; set; }                           // 别名2
        public string Abbr3 { get; set; }                           // 别名3
        public DosageFormEnum DosageFormEnum { get; set; }          // 药品剂型   
        public string Unit { get; set; }                            // 单位
        public string AdministrationRoute { get; set; }             // 给药方式
        public string Specifications { get; set; }                  // 规格
        public string Manufacturer { get; set; }                    // 生产厂家
        public bool PoisonousHemp { get; set; }                     // 毒麻
        public bool Valuable { get; set; }                          // 贵重
        public bool EssentialDrugs { get; set; }                    // 基本药物
        public YiBaoEnum YiBaoEnum { get; set; }                    // 医保甲乙类
        public int MaxNum { get; set; }                             // 最大库存量
        public int MinNum { get; set; }                             // 最小库存量
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }                      // 零售价

        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
    }

    public enum MedicalRecordEnum
    {
        MenZhen,              // 门诊病历
        RuYuan,               // 入院记录 
        BingCheng,            // 病程记录
        ChuYuan,              // 出院记录
        BiangAnShouYe         // 病案首页 
    }

    // 病历
    public class MedicalRecord
    {
        public MedicalRecord()
        {

        }

        public int ID { get; set; }  // ID
        public string NO { get; set; } // 病历号
        public MedicalRecordEnum MedicalRecordEnum { get; set; }  // 类别
        public int RegistrationID { get; set; }                   // 门诊ID
        public DateTime WriteTime { get; set; }                   // 编辑时间
        public int WriteUserID { get; set; }                      // 编写人的用户ID
        public string ContentXml { get; set; }                    // 内容xml

        public virtual Registration Registration { get; set; }
    }

    // 住院病人
    public class Inpatient
    {
        public Inpatient()
        {
        }

        public override string ToString()
        {
            string str = Patient.Name + " " +
                        (Patient.Gender == DAL.GenderEnum.man ? "男 " : "女 ") +
                        (DateTime.Now.Year - Patient.BirthDay.Year).ToString() + "岁\r\n" +
                        "科室：外科\r\n" +
                        //"医生：" + SignalSource.Specialist.ToString() + "\r\n" +
                        "入院时间：" + InHospitalTime.ToString() + "\r\n";
            return str;
        }

        public int ID { get; set; }                              // ID
        public string No { get; set; }                           // 住院号
        public int PatientID { get; set; }                       // 患者ID
        public DateTime InHospitalTime { get; set; }             // 入院时间
        public int InPatientUserID { get; set; }                 // 经办人账户ID 

        public virtual Patient Patient { get; set; }             // 报错，会形成循环或者树状引用
        public virtual User InPatientUser { get; set; }
    }

    // 住院患者接诊表
    public class Responsibility
    {
        public int ID { get; set; }
        public int InpatientID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartTime { get; set; }

        public virtual Employee Employee { get; set; }
    }

    // 检验项目
    public class AssayItem
    {
        public AssayItem()
        {
            AssayDetails = new List<AssayDetail>();
        }

        public int ID { get; set; }                             // ID
        public string Name { get; set; }                        // 名称
        public string AbbrPY { get; set; }                      // 拼音简称
        public string AbbrWB { get; set; }                      // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                       // 价格
        public int SpecimenID { get; set; }                     // 检验标本
        public string Unit { get; set; }                        // 单位

        public virtual Specimen Specimen { get; set; }

        public virtual ICollection<AssayDetail> AssayDetails { get; set; }
    }

    // 检验标本
    public class Specimen
    {
        public Specimen()
        {
            AssayItems = new List<AssayItem>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string AbbrPY { get; set; }
        public string AbbrWB { get; set; }

        public virtual ICollection<AssayItem> AssayItems { get; set; }     // 该标本可执行的所有检验项目
    }

    // 检查项目
    public class InspectItem
    {
        public InspectItem()
        {
            InspectDetails = new List<InspectDetail>();
        }

        public int ID { get; set; }                             // ID
        public string Name { get; set; }                        // 名称
        public string AbbrPY { get; set; }                      // 拼音简称
        public string AbbrWB { get; set; }                      // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                       // 价格
        public string Unit { get; set; }                        // 单位
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类 

        public virtual ICollection<InspectDetail> InspectDetails { get; set; }
    }

    // 检查部位
    public class BodyRegion
    {
        public BodyRegion()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string AbbrPY { get; set; }
        public string AbbrWB { get; set; }
    }

    // 治疗项目
    public class TherapyItem
    {
        public TherapyItem()
        {
            TherapyDetails = new List<TherapyDetail>();
        }

        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名称
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                           // 价格
        public string Unit { get; set; }                            // 单位

        public virtual ICollection<TherapyDetail> TherapyDetails { get; set; }
    }

    // 物资项目
    public class MaterialItem
    {
        public MaterialItem()
        {
            MaterialBillDetails = new List<MaterialBillDetail>();
        }

        public int ID { get; set; }
        public string Name { get; set; }                        // 名称
        public string AbbrPY { get; set; }                      // 拼音简称
        public string AbbrWB { get; set; }                      // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }                  // 零售价
        public string Unit { get; set; }                        // 单位
        public string Specifications { get; set; }              // 规格
        public string Manufacturer { get; set; }                // 生产厂家
        public bool Valuable { get; set; }                      // 是否是贵重
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类
        public int MaxNum { get; set; }                         // 最大库存量
        public int MinNum { get; set; }                         // 最小库存量

        public virtual ICollection<MaterialBillDetail> MaterialBillDetails { get; set; }
    }

    // 治疗单
    public class Therapy
    {
        public Therapy()
        {
            TherapyDetails = new List<TherapyDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }                            // 编号
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID

        public decimal SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
        public virtual User WriteUser { get; set; }               // 开具医生

        public virtual ICollection<TherapyDetail> TherapyDetails { get; set; }
    }

    // 治疗单明细
    public class TherapyDetail
    {
        public TherapyDetail()
        {

        }

        public int ID { get; set; }                               // ID
        public int TherapyItemID { get; set; }                    // 治疗ID
        public int Num { get; set; }                              // 次数
        public string Illustration { get; set; }                  // 说明

        public int TherapyID { get; set; }                         // 所属治疗单ID
        public virtual Therapy Therapy { get; set; }

        public virtual TherapyItem TherapyItem { get; set; }
    }

    // 检验申请单
    public class Assay
    {
        public Assay()
        {
            AssayDetails = new List<AssayDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID

        public decimal SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
        public virtual User WriteUser { get; set; }               // 开具医生

        public virtual ICollection<AssayDetail> AssayDetails { get; set; }
    }

    // 检验申请单明细
    public class AssayDetail
    {
        public AssayDetail()
        {

        }

        public int ID { get; set; }                               // ID
        public int AssayItemID { get; set; }                      // 治疗ID
        public int Num { get; set; }                              // 次数
        public string Illustration { get; set; }                  // 说明

        public int AssayID { get; set; }                          // 所属检验申请单ID
        public virtual Assay Assay { get; set; }

        public virtual AssayItem AssayItem { get; set; }
    }

    // 检查申请单
    public class Inspect
    {
        public Inspect()
        {
            InspectDetails = new List<InspectDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID

        public decimal SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
        public virtual User WriteUser { get; set; }               // 开具医生

        public virtual ICollection<InspectDetail> InspectDetails { get; set; }
    }

    // 检查申请单明细
    public class InspectDetail
    {
        public InspectDetail()
        {

        }

        public int ID { get; set; }                               // ID
        public int InspectItemID { get; set; }                    // 治疗ID
        public int Num { get; set; }                              // 次数
        public string Illustration { get; set; }                  // 说明

        public int InspectID { get; set; }                          // 所属检验申请单ID
        public virtual Inspect Inspect { get; set; }

        public virtual InspectItem InspectItem { get; set; }
    }

    // 材料单
    public class MaterialBill
    {
        public MaterialBill()
        {
            MaterialBillDetails = new List<MaterialBillDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID

        public decimal SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
        public virtual User WriteUser { get; set; }               // 开具医生

        public virtual ICollection<MaterialBillDetail> MaterialBillDetails { get; set; }
    }
    // 材料单明细
    public class MaterialBillDetail
    {
        public MaterialBillDetail()
        {

        }

        public int ID { get; set; }                               // ID
        public int MaterialItemID { get; set; }                   // 材料ID
        public int Num { get; set; }                              // 次数
        public string Illustration { get; set; }                  // 说明

        public int MaterialBillID { get; set; }                          // 所属材料单ID
        public virtual MaterialBill MaterialBill { get; set; }

        public virtual MaterialItem MaterialItem { get; set; }
    }

    // 其他服务字典
    public class OtherServiceItem
    {
        public OtherServiceItem()
        {
            OtherServiceDetails = new List<OtherServiceDetail>();
        }

        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名称
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                           // 价格
        public string Unit { get; set; }                            // 单位

        public virtual ICollection<OtherServiceDetail> OtherServiceDetails { get; set; }
    }

    // 其他服务单
    public class OtherService
    {
        public OtherService()
        {
            OtherServiceDetails = new List<OtherServiceDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID

        public decimal SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
        public virtual User WriteUser { get; set; }               // 开具医生

        public virtual ICollection<OtherServiceDetail> OtherServiceDetails { get; set; }
    }

    // 其他服务单明细
    public class OtherServiceDetail
    {
        public OtherServiceDetail()
        {

        }

        public int ID { get; set; }                                      // ID
        public int OtherServiceItemID { get; set; }                      // 其他服务ID
        public int Num { get; set; }                                     // 次数
        public string Illustration { get; set; }                         // 说明

        public int OtherServiceID { get; set; }                          // 所属其他服务单ID
        public virtual OtherService OtherService { get; set; }

        public virtual OtherServiceItem OtherServiceItem { get; set; }
    }

    public enum InStoreEnum
    {
        采购入库,
        赠与入库,
        其他入库
    }

    public enum ReCheckStatusEnum
    {
        待审核,
        已审核
    }

    // 药品入库表
    public class MedicineInStore
    {
        public MedicineInStore()
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
        }

        public int ID { get; set; }                  // ID
        public string NO { get; set; }               // 单号 
        public decimal SumOfMoney { get; set; }      // 总金额，成本价
        public DateTime OperateTime { get; set; }    // 操作时间
        public InStoreEnum InStoreEnum { get; set; }
        public int FromSupplierID { get; set; }      // 供应商
        public int ToStoreID { get; set; }           // 入库库房
        public string Remarks { get; set; }          // 备注
        public int OperateUserID { get; set; }       // 操作用户
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }      // 审核状态
        public int ReCheckUserID { get; set; }       // 复检用户 

        public virtual User OperateUser { get; set; }     // 制单用户
        public virtual Supplier FromSupplier { get; set; }
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
    }

    // 药品入库明细
    public class MedicineInStoreDetail
    {
        public MedicineInStoreDetail()
        {

        }

        public int ID { get; set; }       // ID
        public int MedicineID { get; set; }          // 对应药品字典
        public string Batch { get; set; }            // 批次
        public DateTime ExpirationDate { get; set; } // 有效期
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }      // 成本价
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }       // 零售价
        public int Num { get; set; }             // 入库数量

        public int MedicineInStoreID { get; set; }  // 入库单ID
        public virtual Medicine Medicine { get; set; }    // 药品字典外键
        public virtual MedicineInStore MedicineInStore { get; set; }   // 入库单外键
    }

    public enum OutStoreEnum
    {
        科室出库,
        报损出库,
        分销出库,
        退货出库,
        其他出库
    }

    // 药品出库表
    public class MedicineOutStore
    {
        public MedicineOutStore()
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
        }

        public int ID { get; set; }                      // ID
        public string NO { get; set; }                   // 单号
        public decimal SumOfMoney { get; set; }          // 总金额，成本价
        public DateTime OperateTime { get; set; }        // 操作时间
        public OutStoreEnum OutStoreEnum { get; set; }   // 出库类型
        public int FromStoreID { get; set; }
        public int ToStoreID { get; set; }
        public int ToOtherHospitalID { get; set; }
        public int ToSupplierID { get; set; }        // 供货商退货 
        public string Remarks { get; set; }          // 备注

        public int OperateUserID { get; set; }       // 操作用户
        public int ReCheckUserID { get; set; }       // 复检用户
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }

        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
    }

    // 药品出库明细
    public class MedicineOutStoreDetail
    {
        public MedicineOutStoreDetail()
        {

        }

        public int ID { get; set; }                      // ID
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        public int NumBeforeOut { get; set; }            // 出库前数量 
        public int Num { get; set; }                     // 出库数量
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }          // 出库前成本价
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }           // 出库前零售价

        public int MedicineOutStoreID { get; set; }  // 出库单ID
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
        public virtual MedicineOutStore MedicineOutStore { get; set; }   // 出库单外键
    }

    // 药品盘存表
    public class MedicineCheckStore
    {
        public MedicineCheckStore()
        {
            MedicineCheckStoreDetails = new List<MedicineCheckStoreDetail>();
        }

        public int ID { get; set; }                  // ID
        public string NO { get; set; }               // 单号
        public decimal SumOfMoney { get; set; }      // 总损益，成本价
        public DateTime OperateTime { get; set; }    // 操作时间
        public int CheckStoreID { get; set; }        // 盘存库房
        public string Remarks { get; set; }          // 备注

        public int OperateUserID { get; set; }       // 操作用户
        public int ReCheckUserID { get; set; }       // 复检用户
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }

        public virtual ICollection<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
    }

    // 药品盘存明细
    public class MedicineCheckStoreDetail
    {
        public MedicineCheckStoreDetail()
        {

        }

        public int ID { get; set; }                      // ID
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        public int NumBeforeCheck { get; set; }          // 出库前数量 
        public int Num { get; set; }                     // 出库数量
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }          // 出库前成本价
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }           // 出库前零售价

        public int MedicineCheckStoreID { get; set; }  // 盘存单ID

        public virtual MedicineCheckStore MedicineCheckStore { get; set; }   // 盘存单外键
    }

    public enum StoreRoomEnum
    {
        一级库,
        二级库,
        三级库
    }

    // 库房
    public class StoreRoom
    {
        public StoreRoom()
        {
            StoreRoomMedicineBatchs = new List<StoreRoomMedicineNum>();
        }

        public int ID { get; set; }          // ID
        public string Name { get; set; }     // 库房名称
        public string Abbr1 { get; set; }
        public string Abbr2 { get; set; }
        public string Abbr3 { get; set; }
        public string Address { get; set; }  // 库房地址
        public string Contents { get; set; } // 库房联系人
        public string Tel { get; set; }      // 库房联系方式
        public StoreRoomEnum StoreRoomEnum { get; set; }  // 库房的等级

        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineBatchs { get; set; }
    }

    // 库房库存
    public class StoreRoomMedicineNum
    {
        public StoreRoomMedicineNum()
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
            RecipeChargeDetails = new List<RecipeChargeDetail>();
        }

        public int ID { get; set; }   // ID
        public int StoreRoomID { get; set; }         // 库房ID
        public int SupplierID { get; set; }          // 供应商ID
        public int MedicineID { get; set; }          // 对应药品字典
        public string Batch { get; set; }            // 批次
        public DateTime ExpirationDate { get; set; } // 有效期
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }      // 成本价
        public int Num { get; set; }                 // 库存

        public virtual StoreRoom StoreRoom { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Medicine Medicine { get; set; }

        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
        public virtual ICollection<RecipeChargeDetail> RecipeChargeDetails { get; set; }
    }


    // 供应商
    public class Supplier
    {
        public Supplier()
        {
            MedicineInStores = new List<MedicineInStore>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr1 { get; set; }
        public string Abbr2 { get; set; }
        public string Abbr3 { get; set; }
        public string Address { get; set; }  // 供应商地址
        public string Contents { get; set; } // 供应商联系人
        public string Tel { get; set; }      // 供应商联系方式

        public virtual ICollection<MedicineInStore> MedicineInStores { get; set; }
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
    }

    // 用药处方收费单
    public class RecipeChargeBill
    {
        public RecipeChargeBill()
        {
            RecipeChargeDetails = new List<RecipeChargeDetail>();
        }

        public int ID { get; set; }
        public string NO { get; set; }
        public decimal SumOfMoney { get; set; }
        public DateTime ChargeTime { get; set; }
        public int RecipeID { get; set; }
        public bool Block { get; set; }

        public virtual ICollection<RecipeChargeDetail> RecipeChargeDetails { get; set; }
    }

    // 用药处方收费单明细
    public class RecipeChargeDetail
    {
        public int ID { get; set; }
        public int StoreRoomMedicineNumID { get; set; }
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }
        public int Num { get; set; }
        public int Rebate { get; set; }
        public virtual RecipeChargeBill RecipeChargeBill { get; set; }
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }

    public enum SickRoomEnum
    {
        普通病房,
        重症病房
    }

    public class SickRoom
    {
        public SickRoom()
        {
            SickBeds = new List<SickBed>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public SickRoomEnum SickRoomEnum { get; set; }

        public int DepartmentID { get; set; }

        public string Address { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<SickBed> SickBeds { get; set; }
    }

    public class SickBed
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int SickRoomID { get; set; }
        public string Remarks { get; set; }

        public virtual SickRoom SickRoom { get; set; }
    }
}
