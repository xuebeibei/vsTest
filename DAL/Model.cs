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

    public class HisContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SignalSource> SignalSources { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    
    public class User
    {
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.Status = LoginStatus.unknow;
        }
        public enum LoginStatus { invalid, unknow, logout, login };
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
        public DateTime LastLogin { get; set; }
        public Employee Employee { get; set; }
    }

    public class Department
    {
        public Department()
        {
            this.Name = "";
            this.Abbr = "";
            this.IsDoctorDepartment = false;
            this.ParentID = 0;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public bool IsDoctorDepartment { get; set; }
        public int ParentID { get; set; }
    }

    public class SignalSource
    {
        public SignalSource()
        {
            this.Price = 0.0;
            this.TimeIntival = 1;
            this.DepartmentID = 0;
            this.SignalType = 1;
            this.MaxNum = 0;
            this.AddMaxNum = 0;
            this.HasUsedNum = 0;
            this.Specialist = 0;
            this.Explain = "";
        }
        public int ID { get; set; }              // 号源ID
        public double Price { get; set; }        // 号源单价

        public DateTime VistTime { get; set; }    // 看诊日期
        public int TimeIntival { get; set; }      // 看诊时段ID
        public int DepartmentID { get; set; }// 科室
        public int SignalType { get; set; }       // 号别
        public int MaxNum { get; set; }           // 最大号源
        public int AddMaxNum { get; set; }        // 临时加号号源
        public int HasUsedNum { get; set; }       // 已挂号源
        public int Specialist { get; set; }       // 专家ID
        public string Explain { get; set; }       // 说明
    }

    public class Registration
    {
        public Registration()
        {
            //this.ID = 0;
            this.Patient = new Patient();
            this.SignalSource = new SignalSource();
            this.User = new User();
            this.Fee = 0.0;
            this.DateTime = DateTime.Now;
        }

        public Registration(CommContracts.Registration registration)
        {
            this.Patient = new Patient();
            this.Patient.ID = 1;

            this.SignalSource = new SignalSource();
            this.SignalSource.ID = 2;
            this.SignalSource.DepartmentID = 3;
            this.User = new User();
            this.Fee = registration.Fee;
            this.DateTime = registration.GetDateTime;
        }
        public int ID { get; set; }              // 挂号单ID
        public Patient Patient { get; set; }       // 患者ID
        public SignalSource SignalSource { get; set; }  // 号源ID
        public User User { get; set; }          // 经办人ID
        public double Fee { get; set; }          // 费用
        public DateTime DateTime { get; set; }   // 经办时间  
    }

    public class Patient
    {
        public Patient()
        {
            this.Name = "";
            this.Gender = GenderEnum.man;
            this.Volk = VolkEnum.hanzu;
        }
       
        public int ID { get; set; }              // 患者ID
        public string Name { get; set; }         // 姓名
        public GenderEnum Gender { get; set; }   // 性别
        public DateTime BirthDay { get; set; }   // 出生日期
        public VolkEnum Volk { get; set; }       // 民族
    }

    public class Employee
    {
        public Employee()
        {
            Name = "";
            Department = new Department();
            Job = new Job();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public Job Job { get; set; }
        public GenderEnum Gender { get; set; }   // 性别
    }

    public class Job
    {
        public Job()
        {
            Name = "";
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Default { get; set; }
    }
}
