using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DAL
{
    public class HisContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SignalSource> SignalSources { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
    
    public class User
    {
        public enum LoginStatus { invalid, unknow, logout, login };
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
        public DateTime LastLogin { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public bool IsDoctorDepartment { get; set; }
        public int ParentID { get; set; }
    }

    public class SignalSource
    {
        public int ID { get; set; }              // 号源ID
        public double Price { get; set; }        // 号源单价

        public DateTime VistTime { get; set; }    // 看诊日期
        public int TimeIntival { get; set; }      // 看诊时段ID
        public Department Department { get; set; }// 科室
        public int SignalType { get; set; }       // 号别
        public int MaxNum { get; set; }           // 最大号源
        public int AddMaxNum { get; set; }        // 临时加号号源
        public int HasUsedNum { get; set; }       // 已挂号源
        public int Specialist { get; set; }       // 专家ID
        public string Explain { get; set; }       // 说明
    }

    public class Registration
    {
        public int ID { get; set; }              // 挂号单ID
        public Patient Patient { get; set; }       // 患者ID
        public SignalSource SignalSource { get; set; }  // 号源ID
        public User User { get; set; }          // 经办人ID
        public double Fee { get; set; }          // 费用
        public DateTime DateTime { get; set; }   // 经办时间  
    }

    public class Patient
    {
        public enum GenderEnum { man, woman };
        public enum VolkEnum { hanzu, other };   
        public int ID { get; set; }              // 患者ID
        public string Name { get; set; }         // 姓名
        public GenderEnum Gender { get; set; }   // 性别
        public DateTime BirthDay { get; set; }   // 出生日期
        public VolkEnum Volk { get; set; }       // 民族
    }
}
