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
    public enum SeeDoctorStatusEnum { 未到诊, 候诊中, 接诊中, 接诊结束, 申请入院 };
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
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Inpatient> Inpatients { get; set; }
        public DbSet<AssayItem> AssayItems { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public DbSet<InspectItem> InspectItems { get; set; }
        public DbSet<BodyRegion> BodyRegions { get; set; }
        public DbSet<TherapyItem> TherapyItems { get; set; }
        public DbSet<MaterialItem> MaterialItems { get; set; }
        public DbSet<OtherServiceItem> OtherServiceItem { get; set; }
        public DbSet<MedicineInStore> MedicineInStores { get; set; }
        public DbSet<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        public DbSet<MedicineOutStore> MedicineOutStores { get; set; }
        public DbSet<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
        public DbSet<MedicineCheckStore> MedicineCheckStores { get; set; }
        public DbSet<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }

        public DbSet<MaterialInStore> MaterialInStores { get; set; }
        public DbSet<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
        public DbSet<MaterialOutStore> MaterialOutStores { get; set; }
        public DbSet<MaterialOutStoreDetail> MaterialOutStoreDetails { get; set; }
        public DbSet<MaterialCheckStore> MaterialCheckStores { get; set; }
        public DbSet<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }

        public DbSet<StoreRoom> StoreRooms { get; set; }
        public DbSet<StoreNumBase> StoreNumBases { get; set; }
        public DbSet<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
        public DbSet<StoreRoomMaterialNum> StoreRoomMaterialNums { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<RecipeChargeBill> RecipeChargeBills { get; set; }
        public DbSet<RecipeChargeDetail> RecipeChargeDetails { get; set; }

        public DbSet<SickRoom> SickRooms { get; set; }
        public DbSet<SickBed> SickBeds { get; set; }

        public DbSet<PrePay> PrePays { get; set; }

        public DbSet<MedicineDoctorAdvice> MedicineDoctorAdvices { get; set; }
        public DbSet<MaterialDoctorAdvice> MaterialDoctorAdvices { get; set; }

        public DbSet<AssayDoctorAdvice> AssayDoctorAdvices { get; set; }
        public DbSet<InspectDoctorAdvice> InspectDoctorAdvices { get; set; }

        public DbSet<TherapyDoctorAdvice> TherapyDoctorAdvices { get; set; }

        public DbSet<OtherServiceDoctorAdvice> OtherServiceDoctorAdvices { get; set; }
        public DbSet<SignalItem> SignalItems { get; set; }

        public DbSet<DoctorAdviceBase> DoctorAdviceBases { get; set; }

        public DbSet<GoodsBase> GoodsBases { get; set; }

        public DbSet<ChargeDetailBase> ChargeDetailBases { get; set; }
        public DbSet<MedicineChargeDetail> MedicineChargeDetails { get; set; }
        public DbSet<MaterialChargeDetail> MaterialChargeDetails { get; set; }
        public DbSet<TherapyChargeDetail> TherapyChargeDetails { get; set; }
        public DbSet<AssayChargeDetail> AssayChargeDetails { get; set; }
        public DbSet<InspectChargeDetail> InspectChargeDetails { get; set; }
        public DbSet<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }

        public DbSet<ChargeBase> ChargeBases { get; set; }
        public DbSet<MedicineCharge> MedicineCharges { get; set; }
        public DbSet<MaterialCharge> MaterialCharges { get; set; }
        public DbSet<TherapyCharge> TherapyCharges { get; set; }
        public DbSet<AssayCharge> AssayCharges { get; set; }
        public DbSet<InspectCharge> InspectCharges { get; set; }
        public DbSet<OtherServiceCharge> OtherServiceCharges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            base.OnModelCreating(modelBuilder);

            // TPT mapping 
            modelBuilder.Entity<DoctorAdviceBase>().ToTable("tpt.DoctorAdviceBase");
            modelBuilder.Entity<MedicineDoctorAdvice>().ToTable("tpt.MedicineDoctorAdvice");
            modelBuilder.Entity<DoctorAdviceDetailBase>().ToTable("tpt.DoctorAdviceDetailBase");
            modelBuilder.Entity<MedicineDoctorAdviceDetail>().ToTable("tpt.MedicineDoctorAdviceDetail");

            modelBuilder.Entity<MaterialDoctorAdvice>().ToTable("tpt.MaterialDoctorAdvice");
            modelBuilder.Entity<MaterialDoctorAdviceDetail>().ToTable("tpt.MaterialDoctorAdviceDetail");
            modelBuilder.Entity<AssayDoctorAdvice>().ToTable("tpt.AssayDoctorAdvice");
            modelBuilder.Entity<AssayDoctorAdviceDetail>().ToTable("tpt.AssayDoctorAdviceDetail");
            modelBuilder.Entity<InspectDoctorAdvice>().ToTable("tpt.InspectDoctorAdvice");
            modelBuilder.Entity<InspectDoctorAdviceDetail>().ToTable("tpt.InspectDoctorAdviceDetail");

            modelBuilder.Entity<TherapyDoctorAdvice>().ToTable("tpt.TherapyDoctorAdvice");
            modelBuilder.Entity<TherapyDoctorAdviceDetail>().ToTable("tpt.TherapyDoctorAdviceDetail");

            modelBuilder.Entity<OtherServiceDoctorAdvice>().ToTable("tpt.OtherServiceDoctorAdvice");
            modelBuilder.Entity<OtherServiceDoctorAdviceDetail>().ToTable("tpt.OtherServiceDoctorAdviceDetail");

            modelBuilder.Entity<GoodsBase>().ToTable("tpt.GoodsBase");
            modelBuilder.Entity<Medicine>().ToTable("tpt.Medicine");
            modelBuilder.Entity<MaterialItem>().ToTable("tpt.MaterialItem");

            modelBuilder.Entity<StoreNumBase>().ToTable("tpt.StoreNumBase");
            modelBuilder.Entity<StoreRoomMedicineNum>().ToTable("tpt.StoreRoomMedicineNum");
            modelBuilder.Entity<StoreRoomMaterialNum>().ToTable("tpt.StoreRoomMaterialNum");

            modelBuilder.Entity<StoreOperateBillDetailBase>().ToTable("tpt.StoreOperateBillDetailBase");
            modelBuilder.Entity<MedicineInStoreDetail>().ToTable("tpt.MedicineInStoreDetail");
            modelBuilder.Entity<MedicineOutStoreDetail>().ToTable("tpt.MedicineOutStoreDetail");
            modelBuilder.Entity<MedicineCheckStoreDetail>().ToTable("tpt.MedicineCheckStoreDetail");
            modelBuilder.Entity<MaterialInStoreDetail>().ToTable("tpt.MaterialInStoreDetail");
            modelBuilder.Entity<MaterialOutStoreDetail>().ToTable("tpt.MaterialOutStoreDetail");
            modelBuilder.Entity<MaterialCheckStoreDetail>().ToTable("tpt.MaterialCheckStoreDetail");

            modelBuilder.Entity<StoreOperateBillBase>().ToTable("tpt.StoreOperateBillBase");
            modelBuilder.Entity<MedicineInStore>().ToTable("tpt.MedicineInStore");
            modelBuilder.Entity<MedicineOutStore>().ToTable("tpt.MedicineOutStore");
            modelBuilder.Entity<MedicineCheckStore>().ToTable("tpt.MedicineCheckStore");
            modelBuilder.Entity<MaterialInStore>().ToTable("tpt.MaterialInStore");
            modelBuilder.Entity<MaterialOutStore>().ToTable("tpt.MaterialOutStore");
            modelBuilder.Entity<MaterialCheckStore>().ToTable("tpt.MaterialCheckStore");

            modelBuilder.Entity<ChargeDetailBase>().ToTable("tpt.ChargeDetailBase");
            modelBuilder.Entity<MedicineChargeDetail>().ToTable("tpt.MedicineChargeDetail");
            modelBuilder.Entity<MaterialChargeDetail>().ToTable("tpt.MaterialChargeDetail");
            modelBuilder.Entity<TherapyChargeDetail>().ToTable("tpt.TherapyChargeDetail");
            modelBuilder.Entity<AssayChargeDetail>().ToTable("tpt.AssayChargeDetail");
            modelBuilder.Entity<InspectChargeDetail>().ToTable("tpt.InspectChargeDetail");
            modelBuilder.Entity<OtherServiceChargeDetail>().ToTable("tpt.OtherServiceChargeDetail");

            modelBuilder.Entity<ChargeBase>().ToTable("tpt.ChargeBase");
            modelBuilder.Entity<MedicineCharge>().ToTable("tpt.MedicineCharge");
            modelBuilder.Entity<MaterialCharge>().ToTable("tpt.MaterialCharge");
            modelBuilder.Entity<TherapyCharge>().ToTable("tpt.TherapyCharge");
            modelBuilder.Entity<AssayCharge>().ToTable("tpt.AssayCharge");
            modelBuilder.Entity<InspectCharge>().ToTable("tpt.InspectCharge");
            modelBuilder.Entity<OtherServiceCharge>().ToTable("tpt.OtherServiceCharge");
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
            Inpatients = new List<Inpatient>();
            PrePays = new List<PrePay>();
            DoctorAdviceBases = new List<DoctorAdviceBase>();
            StoreOperateBillBases = new List<StoreOperateBillBase>();
            ChargeBases = new List<ChargeBase>();
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
        public virtual ICollection<Inpatient> Inpatients { get; set; }       // 所有住院登记 

        public virtual ICollection<PrePay> PrePays { get; set; }

        public virtual ICollection<DoctorAdviceBase> DoctorAdviceBases { get; set; }

        public virtual ICollection<StoreOperateBillBase> StoreOperateBillBases { get; set; }

        public virtual ICollection<ChargeBase> ChargeBases { get; set; }
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
        public int ID { get; set; }                  // 号源ID
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }           // 号源单价

        public DateTime? VistTime { get; set; }       // 看诊日期
        public int MaxNum { get; set; }               // 最大号源
        public int SignalItemID { get; set; }         // 号源种类
        public int EmployeeID { get; set; }           // 值班医生
        public int DepartmentID { get; set; }         // 所属科室
        public virtual SignalItem SignalItem { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号     
    }

    public enum SignalTimeEnum
    {
        上午,
        下午,
        晚上
    }

    public class SignalItem
    {
        public SignalItem()
        {
            SignalSources = new List<SignalSource>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public SignalTimeEnum SignalTimeEnum { get; set; }
        public int MaxNum { get; set; }
        public decimal SellPrice { get; set; }

        public virtual ICollection<SignalSource> SignalSources { get; set; }
    }

    public enum PayWayEnum
    {
        账户支付,
        现金支付
    }
    public class Registration
    {
        public Registration()
        {
            this.RegisterFee = 0.0m;
            this.RegisterTime = DateTime.Now;
            this.SeeDoctorStatus = SeeDoctorStatusEnum.未到诊;
            this.TriageStatus = TriageStatusEnum.no;
            this.MedicalRecords = new List<MedicalRecord>();
        }

        public override string ToString()
        {
            string str = Patient.Name + " " +
                        (Patient.Gender == DAL.GenderEnum.man ? "男 " : "女 ") +
                        "岁\r\n" +
                        "科室：外科\r\n" +
                        "看诊时间：" + SignalSource.VistTime.ToString() + "\r\n";
            return str;
        }


        public int ID { get; set; }                               // 挂号单ID
        public int PatientID { get; set; }                        // 患者ID
        public int SignalSourceID { get; set; }                   // 号源ID
        public int RegisterUserID { get; set; }                   // 经办人ID
        public decimal RegisterFee { get; set; }                  // 挂号费用
        public DateTime? RegisterTime { get; set; }               // 经办时间
        public SeeDoctorStatusEnum SeeDoctorStatus { get; set; }  // 看诊状态
        public TriageStatusEnum TriageStatus { get; set; }        // 分诊状态
        public PayWayEnum PayWayEnum { get; set; }                // 支付方式

        public decimal ReturnServiceMoney { get; set; }           // 退号手续费
        public int ReturnUserID { get; set; }                     // 退号人ID
        public DateTime? ReturnTime { get; set; }                 // 退号时间

        public int ArriveUserID { get; set; }                     // 到诊用户ID
        public DateTime? ArriveTime { get; set; }                 // 到诊时间 

        public DateTime? StartSeeDoctorTime { get; set; }               // 开始看诊时间 
        public DateTime? EndSeeDoctorTime { get; set; }                 // 结束看诊时间
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
        public DateTime? DateTime { get; set; }                 // 分诊时间
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
            PrePays = new List<PrePay>();
            DoctorAdviceBases = new List<DoctorAdviceBase>();
        }

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
        public int ID { get; set; }              // 患者ID
        public string Name { get; set; }         // 姓名
        public GenderEnum Gender { get; set; }   // 性别
        public DateTime? BirthDay { get; set; }   // 出生日期
        public string IDCardNo { get; set; }     // 身份证
        public VolkEnum Volk { get; set; }       // 民族
        public string Tel { get; set; }                          // 电话，患者电话
        public string JiGuan { get; set; }       // 籍贯

        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号
        public virtual ICollection<Inpatient> Inpatients { get; set; }       // 所有住院

        public virtual ICollection<PrePay> PrePays { get; set; }
        public virtual ICollection<DoctorAdviceBase> DoctorAdviceBases { get; set; }
    }

    public class Employee
    {
        public Employee()
        {
            Name = "";
            Users = new List<User>();
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

    public enum DoctorAdviceContentEnum
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

    public enum DosageFormEnum
    {
        片剂,
        颗粒,
        水剂
    }

    public class GoodsBase
    {
        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        public string Unit { get; set; }                            // 单位
        public string Specifications { get; set; }                  // 规格
        public string Manufacturer { get; set; }                    // 生产厂家
        public YiBaoEnum YiBaoEnum { get; set; }                    // 医保甲乙类
        public int MaxNum { get; set; }                             // 最大库存量
        public int MinNum { get; set; }                             // 最小库存量
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }                      // 零售价
    }

    // 药品字典
    public class Medicine : GoodsBase
    {
        public Medicine()
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
            MedicineDoctorAdviceDetails = new List<MedicineDoctorAdviceDetail>();
        }

        public MedicineTypeEnum MedicineTypeEnum { get; set; }      // 药品类型
        public string Abbr1 { get; set; }                           // 别名1
        public string Abbr2 { get; set; }                           // 别名2
        public string Abbr3 { get; set; }                           // 别名3
        public DosageFormEnum DosageFormEnum { get; set; }          // 药品剂型   
        public string AdministrationRoute { get; set; }             // 给药方式
        public bool PoisonousHemp { get; set; }                     // 毒麻
        public bool Valuable { get; set; }                          // 贵重
        public bool EssentialDrugs { get; set; }                    // 基本药物
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
        public virtual ICollection<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }
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
        public DateTime? WriteTime { get; set; }                   // 编辑时间
        public int WriteUserID { get; set; }                      // 编写人的用户ID
        public string ContentXml { get; set; }                    // 内容xml

        public virtual Registration Registration { get; set; }
    }

    public enum BaoXianEnum
    {
        自费,
        城乡居民医保,
        城镇职工医保
    }

    public enum MarriageEnum
    {
        未婚,
        已婚,
        离异,
        丧偶
    }

    public enum IllnesSstateEnum
    {
        危,
        急,
        一般
    }

    public enum InHospitalStatusEnum
    {
        未入院,
        在院中,
        已出院
    }

    // 住院病人
    public class Inpatient
    {
        public Inpatient()
        {
        }

        public int ID { get; set; }                              // ID
        public string No { get; set; }                           // 住院号
        public string CaseNo { get; set; }                       // 病历号
        public BaoXianEnum BaoXianEnum { get; set; }             // 费用类别
        public string YiBaoNo { get; set; }                      // 医保号
        public int PatientID { get; set; }                       // 患者ID
        public MarriageEnum MarriageEnum { get; set; }           // 婚姻状况
        public string Job { get; set; }                          // 职业
        public string WorkAddress { get; set; }                  // 单位地址 
        public string ContactsName { get; set; }                 // 联系人  
        public string ContactsTel { get; set; }                  // 联系人电话  
        public string ContactsAddress { get; set; }              // 联系人住址  
        public DateTime? InHospitalTime { get; set; }            // 入院时间
        public string InHospitalDiagnoses { get; set; }          // 入院诊断 
        public IllnesSstateEnum IllnesSstateEnum { get; set; }   // 入院病情
        public string InHospitalDoctorName { get; set; }         // 入院医生
        public string InHospitalDepartment { get; set; }         // 入院科室
        public int InPatientUserID { get; set; }                 // 入院经办人账户ID 

        public DateTime? LeaveHospitalTime { get; set; }            // 出院时间
        public string LeaveHospitalDiagnoses { get; set; }          // 出院诊断 
        public string LeaveHospitalDoctorName { get; set; }         // 出院医生
        public string LeaveHospitalDepartment { get; set; }         // 出院科室
        public int LeaveHospitalUserID { get; set; }                 // 出院经办人账户ID 
        public InHospitalStatusEnum InHospitalStatusEnum { get; set; } // 住院状态

        public virtual Patient Patient { get; set; }             // 报错，会形成循环或者树状引用
        public virtual User InPatientUser { get; set; }
    }

    // 化验项目
    public class AssayItem
    {
        public AssayItem()
        {
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
            AssayChargeDetails = new List<AssayChargeDetail>();
        }

        public int ID { get; set; }                             // ID
        public string Name { get; set; }                        // 名称
        public string AbbrPY { get; set; }                      // 拼音简称
        public string AbbrWB { get; set; }                      // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                      // 价格
        public string Unit { get; set; }                        // 单位

        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类 

        public virtual ICollection<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
        public virtual ICollection<AssayChargeDetail> AssayChargeDetails { get; set; }
    }

    // 化验标本
    public class Specimen
    {
        public Specimen()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string AbbrPY { get; set; }
        public string AbbrWB { get; set; }

    }

    // 检查项目
    public class InspectItem
    {
        public InspectItem()
        {
            InspectDoctorAdviceDetail = new List<InspectDoctorAdviceDetail>();
            InspectChargeDetails = new List<InspectChargeDetail>();
        }

        public int ID { get; set; }                             // ID
        public string Name { get; set; }                        // 名称
        public string AbbrPY { get; set; }                      // 拼音简称
        public string AbbrWB { get; set; }                      // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                       // 价格
        public string Unit { get; set; }                        // 单位
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类 

        public virtual ICollection<InspectDoctorAdviceDetail> InspectDoctorAdviceDetail { get; set; }
        public virtual ICollection<InspectChargeDetail> InspectChargeDetails { get; set; }
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
            TherapyDoctorAdviceDetails = new List<TherapyDoctorAdviceDetail>();
            TherapyChargeDetails = new List<TherapyChargeDetail>(); 
        }

        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名称
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                          // 价格
        public string Unit { get; set; }                            // 单位
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类

        public virtual ICollection<TherapyDoctorAdviceDetail> TherapyDoctorAdviceDetails { get; set; }
        public virtual ICollection<TherapyChargeDetail> TherapyChargeDetails { get; set; }
    }

    // 物资项目
    public class MaterialItem : GoodsBase
    {
        public MaterialItem()
        {
            MaterialDoctorAdviceDetails = new List<MaterialDoctorAdviceDetail>();
            StoreRoomMaterialNums = new List<StoreRoomMaterialNum>();
        }

        public bool Valuable { get; set; }                      // 是否是贵重

        public virtual ICollection<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
        public virtual ICollection<StoreRoomMaterialNum> StoreRoomMaterialNums { get; set; }
    }

    // 其他服务字典
    public class OtherServiceItem
    {
        public OtherServiceItem()
        {
            OtherServiceDoctorAdviceDetails = new List<OtherServiceDoctorAdviceDetail>();
            OtherServiceChargeDetails = new List<OtherServiceChargeDetail>();
        }

        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名称
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                           // 价格
        public string Unit { get; set; }                            // 单位

        public virtual ICollection<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
        public virtual ICollection<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
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

    // 库存表基类
    public class StoreNumBase
    {
        public StoreNumBase()
        {
        }

        public int ID { get; set; }                  // ID
        public int StoreRoomID { get; set; }         // 库房ID
        public int SupplierID { get; set; }          // 供应商ID
        public string Batch { get; set; }            // 批次
        public DateTime? ExpirationDate { get; set; } // 有效期
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }      // 成本价
        public int Num { get; set; }                 // 库存

        public virtual StoreRoom StoreRoom { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

    // 库存操作明细基类
    public class StoreOperateBillDetailBase
    {
        public int ID { get; set; }                      // ID
        public string Batch { get; set; }                // 批次
        public DateTime? ExpirationDate { get; set; }    // 有效期
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }          // 成本价
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }           // 零售价
        public int Num { get; set; }                     // 数量
    }

    // 库存操作表基类
    public class StoreOperateBillBase
    {
        public int ID { get; set; }                     // ID
        public string NO { get; set; }                  // 单号 
        public decimal SumOfMoney { get; set; }         // 总金额，成本价
        public DateTime? OperateTime { get; set; }      // 操作时间
        public string Remarks { get; set; }             // 备注
        public int OperateUserID { get; set; }          // 操作用户
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }      // 审核状态
        public int ReCheckUserID { get; set; }         // 复检用户 

        public virtual User OperateUser { get; set; }  // 制单用户
    }
    public enum OutStoreEnum
    {
        科室出库,
        报损出库,
        分销出库,
        退货出库,
        其他出库
    }

    // 药品入库表
    public class MedicineInStore : StoreOperateBillBase
    {
        public MedicineInStore()
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
        }
        public InStoreEnum InStoreEnum { get; set; }
        public int FromSupplierID { get; set; }      // 供应商
        public int ToStoreID { get; set; }           // 入库库房

        public virtual Supplier FromSupplier { get; set; }
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
    }

    // 药品入库明细
    public class MedicineInStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineInStoreDetail()
        {

        }
        public int MedicineID { get; set; }          // 对应药品字典
        public int MedicineInStoreID { get; set; }  // 入库单ID

        public virtual Medicine Medicine { get; set; }    // 药品字典外键
        public virtual MedicineInStore MedicineInStore { get; set; }   // 入库单外键
    }


    // 药品出库表
    public class MedicineOutStore : StoreOperateBillBase
    {
        public MedicineOutStore()
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
        }

        public OutStoreEnum OutStoreEnum { get; set; }   // 出库类型
        public int FromStoreID { get; set; }
        public int ToStoreID { get; set; }
        public int ToOtherHospitalID { get; set; }
        public int ToSupplierID { get; set; }        // 供货商退货 

        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
    }

    // 药品出库明细
    public class MedicineOutStoreDetail : StoreOperateBillDetailBase
    {
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        public int NumBeforeOut { get; set; }            // 出库前数量 
        public int MedicineOutStoreID { get; set; }  // 出库单ID
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
        public virtual MedicineOutStore MedicineOutStore { get; set; }   // 出库单外键
    }

    // 药品盘存表
    public class MedicineCheckStore : StoreOperateBillBase
    {
        public MedicineCheckStore()
        {
            MedicineCheckStoreDetails = new List<MedicineCheckStoreDetail>();
        }

        public int CheckStoreID { get; set; }        // 盘存库房

        public virtual ICollection<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
    }

    // 药品盘存明细
    public class MedicineCheckStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineCheckStoreDetail()
        {

        }

        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
        public int NumBeforeCheck { get; set; }          // 出库前数量 

        public int MedicineCheckStoreID { get; set; }    // 盘存单ID

        public virtual MedicineCheckStore MedicineCheckStore { get; set; }   // 盘存单外键
    }

    // 物资入库表
    public class MaterialInStore : StoreOperateBillBase
    {
        public MaterialInStore()
        {
            MaterialInStoreDetails = new List<MaterialInStoreDetail>();
        }
        public InStoreEnum InStoreEnum { get; set; }
        public int FromSupplierID { get; set; }      // 供应商
        public int ToStoreID { get; set; }           // 入库库房

        public virtual Supplier FromSupplier { get; set; }
        public virtual ICollection<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
    }

    // 物资入库明细
    public class MaterialInStoreDetail : StoreOperateBillDetailBase
    {
        public MaterialInStoreDetail()
        {

        }
        public int MaterialID { get; set; }          // 对应物资字典
        public int MaterialInStoreID { get; set; }  // 入库单ID

        public virtual MaterialItem Material { get; set; }    // 物资字典外键
        public virtual MaterialInStore MaterialInStore { get; set; }   // 入库单外键
    }


    // 物资出库表
    public class MaterialOutStore : StoreOperateBillBase
    {
        public MaterialOutStore()
        {
            MaterialOutStoreDetails = new List<MaterialOutStoreDetail>();
        }

        public OutStoreEnum OutStoreEnum { get; set; }   // 出库类型
        public int FromStoreID { get; set; }
        public int ToStoreID { get; set; }
        public int ToOtherHospitalID { get; set; }
        public int ToSupplierID { get; set; }        // 供货商退货 

        public virtual ICollection<MaterialOutStoreDetail> MaterialOutStoreDetails { get; set; }
    }

    // 物资出库明细
    public class MaterialOutStoreDetail : StoreOperateBillDetailBase
    {
        public int StoreRoomMaterialNumID { get; set; }     // 库存ID
        public int NumBeforeOut { get; set; }               // 出库前数量 
        public int MaterialOutStoreID { get; set; }         // 出库单ID
        public virtual StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
        public virtual MaterialOutStore MaterialOutStore { get; set; }   // 出库单外键
    }

    // 物资盘存表
    public class MaterialCheckStore : StoreOperateBillBase
    {
        public MaterialCheckStore()
        {
            MaterialCheckStoreDetails = new List<MaterialCheckStoreDetail>();
        }

        public int CheckStoreID { get; set; }        // 盘存库房

        public virtual ICollection<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }
    }

    // 物资盘存明细
    public class MaterialCheckStoreDetail : StoreOperateBillDetailBase
    {
        public MaterialCheckStoreDetail()
        {

        }

        public int StoreRoomMaterialNumID { get; set; }  // 库存ID
        public int NumBeforeCheck { get; set; }          // 出库前数量 

        public int MaterialCheckStoreID { get; set; }    // 盘存单ID

        public virtual MaterialCheckStore MaterialCheckStore { get; set; }   // 盘存单外键
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

    // 药品库存
    public class StoreRoomMedicineNum : StoreNumBase
    {
        public StoreRoomMedicineNum()
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
            RecipeChargeDetails = new List<RecipeChargeDetail>();
            MedicineChargeDetails = new List<MedicineChargeDetail>();
        }
        public int MedicineID { get; set; }          // 对应药品字典

        public virtual Medicine Medicine { get; set; }
        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
        public virtual ICollection<RecipeChargeDetail> RecipeChargeDetails { get; set; }
        public virtual ICollection<MedicineChargeDetail> MedicineChargeDetails { get; set; }
    }

    // 物资库存
    public class StoreRoomMaterialNum : StoreNumBase
    {
        public StoreRoomMaterialNum()
        {
            MaterialChargeDetails = new List<MaterialChargeDetail>();
        }
        public int MaterialItemID { get; set; }          // 对应药品字典
        public virtual MaterialItem MaterialItem { get; set; }
        public virtual ICollection<MaterialChargeDetail> MaterialChargeDetails { get; set; }
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
        public DateTime? ChargeTime { get; set; }
        public int MedicineDoctorAdviceID { get; set; }
        public bool Block { get; set; }

        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
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

    // 病房
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

    // 病床
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

    public enum PrePayWayEnum
    {
        现金,
        支付宝,
        微信
    }

    // 预付单
    public class PrePay
    {
        public int ID { get; set; }
        public string No { get; set; }
        public DateTime? PrePayTime { get; set; }
        public decimal PrePayMoney { get; set; }
        public string PayerName { get; set; }
        public PrePayWayEnum PrePayWayEnum { get; set; }
        public int PatientID { get; set; }
        public int UserID { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual User User { get; set; }
    }

    // 医嘱明细基类
    public class DoctorAdviceDetailBase
    {
        public int ID { get; set; }
        public int AllNum { get; set; }
        public decimal SellPrice { get; set; }           // 参考价格
        public string Remarks { get; set; }
    }

    // 医嘱基类
    public class DoctorAdviceBase
    {
        public DoctorAdviceBase()
        {
        }
        public int ID { get; set; }
        public string NO { get; set; }
        public decimal SumOfMoney { get; set; }                 // 金额
        public DateTime? WriteTime { get; set; }                // 开具时间
        public int WriteDoctorUserID { get; set; }              // 开具医生
        public int PatientID { get; set; }                      // 所属患者
        public ChargeStatusEnum ChargeStatusEnum { get; set; }  // 收费状态
        public int RegistrationID { get; set; }                 // 门诊看诊标记
        public int InpatientID { get; set; }                    // 住院看诊标记

        public virtual User WriteDoctorUser { get; set; }       // 开具医生
        public virtual Patient Patient { get; set; }
    }

    // 用药处方医嘱明细
    public class MedicineDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int MedicineID { get; set; }               // 药品
        public int MedicineDoctorAdviceID { get; set; }

        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        public virtual Medicine Medicine { get; set; }
    }

    // 用药处方医嘱
    public class MedicineDoctorAdvice : DoctorAdviceBase
    {
        public MedicineDoctorAdvice()
        {
            MedicineDoctorAdviceDetails = new List<MedicineDoctorAdviceDetail>();
            MedicineCharges = new List<MedicineCharge>();
        }
        public DoctorAdviceContentEnum RecipeContentEnum { get; set; }
        public virtual ICollection<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }

        public virtual ICollection<MedicineCharge> MedicineCharges { get; set; }
    }

    // 材料物资医嘱明细
    public class MaterialDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int MaterialID { get; set; }               // 物资材料
        public int MaterialDoctorAdviceID { get; set; }

        public virtual MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        public virtual MaterialItem Material { get; set; }
    }

    // 材料物资医嘱
    public class MaterialDoctorAdvice : DoctorAdviceBase
    {
        public MaterialDoctorAdvice()
        {
            MaterialDoctorAdviceDetails = new List<MaterialDoctorAdviceDetail>();
            MaterialCharges = new List<MaterialCharge>();
        }
        public virtual ICollection<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
        public virtual ICollection<MaterialCharge> MaterialCharges { get; set; }
    }


    // 化验医嘱明细
    public class AssayDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int AssayID { get; set; }               // 化验项目
        public int AssayDoctorAdviceID { get; set; }

        public virtual AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        public virtual AssayItem Assay { get; set; }
    }

    // 化验医嘱
    public class AssayDoctorAdvice : DoctorAdviceBase
    {
        public AssayDoctorAdvice()
        {
            AssayDoctorAdviceDetails = new List<AssayDoctorAdviceDetail>();
            AssayCharges = new List<AssayCharge>();
        }
        public virtual ICollection<AssayDoctorAdviceDetail> AssayDoctorAdviceDetails { get; set; }
        public virtual ICollection<AssayCharge> AssayCharges { get; set; }
    }


    // 检验医嘱明细
    public class InspectDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int InspectID { get; set; }               // 检验项目
        public int InspectDoctorAdviceID { get; set; }

        public virtual InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        public virtual InspectItem Inspect { get; set; }
    }

    // 检验医嘱
    public class InspectDoctorAdvice : DoctorAdviceBase
    {
        public InspectDoctorAdvice()
        {
            InspectDoctorAdviceDetails = new List<InspectDoctorAdviceDetail>();
            InspectCharges = new List<InspectCharge>();
        }
        public virtual ICollection<InspectDoctorAdviceDetail> InspectDoctorAdviceDetails { get; set; }
        public virtual ICollection<InspectCharge> InspectCharges { get; set; }
    }

    // 治疗医嘱明细
    public class TherapyDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int TherapyID { get; set; }               // 治疗项目
        public int TherapyDoctorAdviceID { get; set; }

        public virtual TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
        public virtual TherapyItem Therapy { get; set; }
    }

    // 治疗医嘱
    public class TherapyDoctorAdvice : DoctorAdviceBase
    {
        public TherapyDoctorAdvice()
        {
            TherapyDoctorAdviceDetails = new List<TherapyDoctorAdviceDetail>();
            TherapyCharges = new List<TherapyCharge>();
        }
        public virtual ICollection<TherapyDoctorAdviceDetail> TherapyDoctorAdviceDetails { get; set; }
        public virtual ICollection<TherapyCharge> TherapyCharges { get; set; }
    }

    // 其他医嘱明细
    public class OtherServiceDoctorAdviceDetail : DoctorAdviceDetailBase
    {
        public int OtherServiceID { get; set; }               // 其他项目
        public int OtherServiceDoctorAdviceID { get; set; }

        public virtual OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
        public virtual OtherServiceItem OtherService { get; set; }
    }

    // 其他医嘱
    public class OtherServiceDoctorAdvice : DoctorAdviceBase
    {
        public OtherServiceDoctorAdvice()
        {
            OtherServiceDoctorAdviceDetails = new List<OtherServiceDoctorAdviceDetail>();
            OtherServiceCharges = new List<OtherServiceCharge>();
        }
        public virtual ICollection<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
        public virtual ICollection<OtherServiceCharge> OtherServiceCharges { get; set; }
    }

    // 收费明细基类
    public class ChargeDetailBase
    {
        public int ID { get; set; }                               // ID
        [DecimalPrecision(18, 4)]
        public decimal SellPrice { get; set; }                    // 单价
        public int AllNum { get; set; }                           // 数量
        public int Rebate { get; set; }                           // 折扣
    }

    // 收费单基类
    public class ChargeBase
    {
        public int ID { get; set; }                               // ID
        public string NO { get; set; }                            // 收费单编号
        public DateTime? ChargeTime { get; set; }                 // 收费时间  
        public int ChargeUserID { get; set; }                     // 收费人员
        public decimal SumOfMoney { get; set; }                   // 收费金额
        public virtual User ChargeUser { get; set; }
    }

    // 用药处方医嘱收费单明细
    public class MedicineChargeDetail : ChargeDetailBase
    {
        public int StoreRoomMedicineNumID { get; set; }         // 药品库存
        public int MedicineChargeID { get; set; }               // 所属收费单

        public virtual MedicineCharge MedicineCharge { get; set; }
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
    }

    // 用药处方医嘱收费单
    public class MedicineCharge : ChargeBase
    {
        public MedicineCharge()
        {
            MedicineChargeDetails = new List<MedicineChargeDetail>();
        }

        public int MedicineDoctorAdviceID { get; set; }                    // 所对应的的用药医嘱
        public MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
        public virtual ICollection<MedicineChargeDetail> MedicineChargeDetails { get; set; }
    }

    // 材料物资医嘱收费单明细
    public class MaterialChargeDetail : ChargeDetailBase
    {
        public int StoreRoomMaterialNumID { get; set; }               // 物资材料
        public int MaterialChargeID { get; set; }

        public virtual MaterialCharge MaterialCharge { get; set; }
        public virtual StoreRoomMaterialNum StoreRoomMaterialNum { get; set; }
    }

    // 材料物资医嘱收费单
    public class MaterialCharge : ChargeBase
    {
        public MaterialCharge()
        {
            MaterialChargeDetails = new List<MaterialChargeDetail>();
        }
        public int MaterialDoctorAdviceID { get; set; }                    // 所对应的的物资材料医嘱
        public MaterialDoctorAdvice MaterialDoctorAdvice { get; set; }
        public virtual ICollection<MaterialChargeDetail> MaterialChargeDetails { get; set; }
    }

    // 治疗医嘱收费单明细
    public class TherapyChargeDetail : ChargeDetailBase
    {
        public int TherapyID { get; set; }               // 治疗项目
        public int TherapyChargeID { get; set; }

        public virtual TherapyCharge TherapyCharge { get; set; }
        public virtual TherapyItem Therapy { get; set; }
    }

    // 治疗医嘱收费单
    public class TherapyCharge : ChargeBase
    {
        public TherapyCharge()
        {
            TherapyChargeDetails = new List<TherapyChargeDetail>();
        }
        public int TherapyDoctorAdviceID { get; set; }
        public TherapyDoctorAdvice TherapyDoctorAdvice { get; set; }
        public virtual ICollection<TherapyChargeDetail> TherapyChargeDetails { get; set; }
    }

    // 化验医嘱收费单明细
    public class AssayChargeDetail : ChargeDetailBase
    {
        public int AssayID { get; set; }               // 化验项目
        public int AssayChargeID { get; set; }

        public virtual AssayCharge AssayCharge { get; set; }
        public virtual AssayItem Assay { get; set; }
    }

    // 化验医嘱收费单
    public class AssayCharge : ChargeBase
    {
        public AssayCharge()
        {
            AssayChargeDetails = new List<AssayChargeDetail>();
        }
        public int AssayDoctorAdviceID { get; set; }
        public AssayDoctorAdvice AssayDoctorAdvice { get; set; }
        public virtual ICollection<AssayChargeDetail> AssayChargeDetails { get; set; }
    }

    // 检查医嘱收费单明细
    public class InspectChargeDetail : ChargeDetailBase
    {
        public int InspectID { get; set; }               // 检查项目
        public int InspectChargeID { get; set; }

        public virtual InspectCharge InspectCharge { get; set; }
        public virtual InspectItem Inspect { get; set; }
    }

    // 检查医嘱收费单
    public class InspectCharge : ChargeBase
    {
        public InspectCharge()
        {
            InspectChargeDetails = new List<InspectChargeDetail>();
        }
        public int InspectDoctorAdviceID { get; set; }
        public InspectDoctorAdvice InspectDoctorAdvice { get; set; }
        public virtual ICollection<InspectChargeDetail> InspectChargeDetails { get; set; }
    }

    // 其他医嘱收费单明细
    public class OtherServiceChargeDetail : ChargeDetailBase
    {
        public int OtherServiceID { get; set; }               // 其他项目
        public int OtherServiceChargeID { get; set; }

        public virtual OtherServiceCharge OtherServiceCharge { get; set; }
        public virtual OtherServiceItem OtherService { get; set; }
    }

    // 其他医嘱收费单
    public class OtherServiceCharge : ChargeBase
    {
        public OtherServiceCharge()
        {
            OtherServiceChargeDetails = new List<OtherServiceChargeDetail>();
        }
        public int OtherServiceDoctorAdviceID { get; set; }
        public OtherServiceDoctorAdvice OtherServiceDoctorAdvice { get; set; }
        public virtual ICollection<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
    }
}
