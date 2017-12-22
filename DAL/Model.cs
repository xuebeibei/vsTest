using System;
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
        putong,
        teshu
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
        public DbSet<MedicineAlias> MedicineAliases { get; set; }
        public DbSet<MedicinePacking> MedicinePackings { get; set; }
        public DbSet<DosageForm> DosageForms { get; set; }
    }

    public class User
    {
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.Status = LoginStatus.unknow;
            Registrations = new List<Registration>();
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
        PuTong,
        JiZhen,
        ErKe,
        MaJingYi,
        JingEr
    }

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

        public int AuditorUserID { get; set; }                    // 审核、调配，核对、发药人员
        public DateTime AuditorTime { get; set; }                 // 审核、调配，核对、发药时间

        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }

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

    public class Medicine
    {
        public Medicine()
        {
            MedicineAlias = new List<MedicineAlias>();
            MedicinePacking = new List<MedicinePacking>();
            RecipeDetails = new List<RecipeDetail>();
        }

        public int ID { get; set; }                                 // ID
        public MedicineTypeEnum MedicineTypeEnum { get; set; }      // 药品类型
        public string Name { get; set; }                            // 药品品名
        public int DosageFormID { get; set; }                       // 药品剂型ID       
        public string AdministrationRoute { get; set; }             // 给药方式
        public string Specifications { get; set; }                  // 规格
        public string Manufacturer { get; set; }                    // 生产厂家
        public bool PoisonousHemp { get; set; }                     // 毒麻
        public bool Valuable { get; set; }                          // 贵重
        public bool EssentialDrugs { get; set; }                    // 基本药物
        public YiBaoEnum YiBaoEnum { get; set; }                    // 医保甲乙类
        public int MaxNum { get; set; }                             // 最大库存量
        public int MinNum { get; set; }                             // 最小库存量

        public virtual ICollection<MedicineAlias> MedicineAlias { get; set; }
        public virtual ICollection<MedicinePacking> MedicinePacking { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }

        public virtual DosageForm DosageForm { get; set; }
    }

    // 药品名称表
    public class MedicineAlias
    {
        public MedicineAlias()
        {
        }

        public int ID { get; set; }
        public string Alias { get; set; }

        public int MedicineID { get; set; }
        public virtual Medicine Medicine { get; set; }
    }

    // 药品包装表
    public class MedicinePacking
    {
        public MedicinePacking()
        {
        }

        public int ID { get; set; }
        public string BigUnit { get; set; }   // 包装
        public int Num { get; set; }          // 换算量，最小包装为0
        public int SmallID { get; set; }      // 小包装ID,最小包装为0

        public int MedicineID { get; set; }
        public virtual Medicine Medicine { get; set; }
    }

    public enum DosageFormEnum   // 剂型分类
    {
        Xiyao,                   // 西药
        ZhongChengYao            // 中成药  
    }


    // 药品剂型
    public class DosageForm
    {
        public DosageForm()
        {
            Medicines = new List<Medicine>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public DosageFormEnum DosageFormEnum { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
