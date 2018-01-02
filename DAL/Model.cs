﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DAL
{
    public enum GenderEnum { man, woman };
    public enum VolkEnum { hanzu, other };
    public enum SeeDoctorStatusEnum { watting, seeing, leaved };
    public enum TriageStatusEnum { no, yes };
    public enum JobEnum
    {
        Initial,        // 初级
        Middle,         // 中级
        Senior          // 高级
    }
    public enum DepartmentEnum
    {
        Other,     // 其他科室
        LinChuang, // 临床科室
        YiJi       // 医技科室  
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
        }
        public enum LoginStatus { invalid, unknow, logout, login };
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
        public DateTime LastLogin { get; set; }

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
    }

    public class Department
    {
        public Department()
        {
            this.Name = "";
            this.Abbr = "";
            this.DepartmentEnum = DepartmentEnum.Other;
            this.ParentID = 0;
            Employees = new List<Employee>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public DepartmentEnum DepartmentEnum { get; set; }
        public int ParentID { get; set; }    // 父类科室
        
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class SignalSource
    {
        public SignalSource()
        {
            Registrations = new List<Registration>();
        }
        public int ID { get; set; }              // 号源ID
        public double Price { get; set; }        // 号源单价

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
            this.RegisterFee = 0.0;
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
        public double RegisterFee { get; set; }                   // 挂号费用
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
            JobEnum = JobEnum.Initial;
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

    // 处方单
    public class Recipe
    {
        
        public Recipe()
        {
            this.RecipeTypeEnum = RecipeTypeEnum.PuTong;
            RecipeDetails = new List<RecipeDetail>();
        }

        public int ID { get; set; }                               // 处方ID
        public string No { get; set; }                            // 处方编号
        public RecipeTypeEnum RecipeTypeEnum { get; set; }        // 处方类型
        public RecipeContentEnum RecipeContentEnum { get; set; }    // 处方内容类别：西/ 成药、中药
        public string MedicalInstitution { get; set; }            // 医疗机构名称
        public int ChargeTypeEnum { get; set; }                   // 费别,*是否存在在门诊和住院中，待定
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID
        public string ClinicalDiagnosis { get; set; }             // 临床诊断
        public string PatientsIDCardNum { get; set; }             // 患者身份证    -- 麻醉和精一处方
        public string ProxyIDCardNum { get; set; }                // 代办人身份证  -- 麻醉和精一处方
        public string ProxyName { get; set; }                     // 代办人姓名    -- 麻醉和精一处方

        public double SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生
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

    public class Medicine
    {
        public Medicine()
        {
            RecipeDetails = new List<RecipeDetail>();
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

        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
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
        public double Price { get; set; }                       // 价格
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
        public double Price { get; set; }                       // 价格
        public string Unit { get; set; }                        // 单位
        public int BodyRegionID { get; set; }                   // 检查部位 

        public virtual BodyRegion BodyRegion { get; set; }
        public virtual ICollection<InspectDetail> InspectDetails { get; set; }
    }

    // 检查部位
    public class BodyRegion
    {
        public BodyRegion()
        {
            InspectItems = new List<InspectItem>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string AbbrPY { get; set; }
        public string AbbrWB { get; set; }

        public virtual ICollection<InspectItem> InspectItems { get; set; }
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
        public double Price { get; set; }                           // 价格
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
        public double StockPrice { get; set; }                  // 入库价格
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

        public double SumOfMoney { get; set; }                    // 金额
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

        public double SumOfMoney { get; set; }                    // 金额
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

        public double SumOfMoney { get; set; }                    // 金额
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

        public double SumOfMoney { get; set; }                    // 金额
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
        public double Price { get; set; }                           // 价格
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
    
        public double SumOfMoney { get; set; }                    // 金额
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
}
