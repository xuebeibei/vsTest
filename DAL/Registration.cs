using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
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
}
