using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration”的 XML 注释
    public class Registration
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Registration()”的 XML 注释
        public Registration()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Registration()”的 XML 注释
        {
            this.RegisterFee = 0.0m;
            this.RegisterTime = DateTime.Now;
            this.SeeDoctorStatus = SeeDoctorStatusEnum.未到诊;
            this.TriageStatus = TriageStatusEnum.no;
            this.MedicalRecords = new List<MedicalRecord>();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ToString()”的 XML 注释
        public override string ToString()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ToString()”的 XML 注释
        {
            string str = Patient.Name + " " +
                        (Patient.Gender == DAL.GenderEnum.man ? "男 " : "女 ") +
                        "岁\r\n" +
                        "科室：外科\r\n" +
                        "看诊时间：" + SignalSource.VistTime.ToString() + "\r\n";
            return str;
        }


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ID”的 XML 注释
        public int ID { get; set; }                               // 挂号单ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.PatientID”的 XML 注释
        public int PatientID { get; set; }                        // 患者ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.PatientID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.SignalSourceID”的 XML 注释
        public int SignalSourceID { get; set; }                   // 号源ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.SignalSourceID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.RegisterUserID”的 XML 注释
        public int RegisterUserID { get; set; }                   // 经办人ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.RegisterUserID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.RegisterFee”的 XML 注释
        public decimal RegisterFee { get; set; }                  // 挂号费用
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.RegisterFee”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.RegisterTime”的 XML 注释
        public DateTime? RegisterTime { get; set; }               // 经办时间
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.RegisterTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.SeeDoctorStatus”的 XML 注释
        public SeeDoctorStatusEnum SeeDoctorStatus { get; set; }  // 看诊状态
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.SeeDoctorStatus”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.TriageStatus”的 XML 注释
        public TriageStatusEnum TriageStatus { get; set; }        // 分诊状态
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.TriageStatus”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.PayWayEnum”的 XML 注释
        public PayWayEnum PayWayEnum { get; set; }                // 支付方式
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.PayWayEnum”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ReturnServiceMoney”的 XML 注释
        public decimal ReturnServiceMoney { get; set; }           // 退号手续费
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ReturnServiceMoney”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ReturnUserID”的 XML 注释
        public int ReturnUserID { get; set; }                     // 退号人ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ReturnUserID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ReturnTime”的 XML 注释
        public DateTime? ReturnTime { get; set; }                 // 退号时间
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ReturnTime”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ArriveUserID”的 XML 注释
        public int ArriveUserID { get; set; }                     // 到诊用户ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ArriveUserID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.ArriveTime”的 XML 注释
        public DateTime? ArriveTime { get; set; }                 // 到诊时间 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.ArriveTime”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.StartSeeDoctorTime”的 XML 注释
        public DateTime? StartSeeDoctorTime { get; set; }               // 开始看诊时间 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.StartSeeDoctorTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.EndSeeDoctorTime”的 XML 注释
        public DateTime? EndSeeDoctorTime { get; set; }                 // 结束看诊时间
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.EndSeeDoctorTime”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Patient”的 XML 注释
        public virtual Patient Patient { get; set; }                      // 患者
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Patient”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.SignalSource”的 XML 注释
        public virtual SignalSource SignalSource { get; set; }            // 号源
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.SignalSource”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.RegisterUser”的 XML 注释
        public virtual User RegisterUser { get; set; }                    // 经办人
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.RegisterUser”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.MedicalRecords”的 XML 注释
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }  // 病历列表
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.MedicalRecords”的 XML 注释
    }
}
