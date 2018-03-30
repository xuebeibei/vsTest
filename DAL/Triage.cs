using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage”的 XML 注释
    public class Triage
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage”的 XML 注释
    {
        // 分诊表，记录分诊结果
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage.Triage()”的 XML 注释
        public Triage()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage.Triage()”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage.ID”的 XML 注释
        public int ID { get; set; }                            // 分诊ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage.RegistrationID”的 XML 注释
        public int RegistrationID { get; set; }                // 挂号单ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage.RegistrationID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage.DoctorID”的 XML 注释
        public int DoctorID { get; set; }                      // 分诊医生ID 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage.DoctorID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage.User”的 XML 注释
        public User User { get; set; }                         // 分诊经办人
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage.User”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Triage.DateTime”的 XML 注释
        public DateTime? DateTime { get; set; }                 // 分诊时间
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Triage.DateTime”的 XML 注释
    }
}
