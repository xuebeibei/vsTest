using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum PayWayEnum
    {
        账户支付,
        现金支付
    }

    public enum SeeDoctorStatusEnum { 未到诊, 候诊中, 已看诊 };
    public enum TriageStatusEnum { no, yes };
    [DataContract]
    public class Registration
    {
        public Registration()
        {

        }
        [DataMember]
        public int ID { get; set; }                               // 挂号单ID
        [DataMember]
        public int PatientID { get; set; }                        // 患者ID
        [DataMember]
        public int SignalSourceID { get; set; }                   // 号源ID
        [DataMember]
        public int RegisterUserID { get; set; }                   // 经办人ID
        [DataMember]
        public decimal RegisterFee { get; set; }                   // 挂号费用
        [DataMember]
        public DateTime? RegisterTime { get; set; }                // 经办时间
        [DataMember]
        public SeeDoctorStatusEnum SeeDoctorStatus { get; set; }  // 看诊状态
        [DataMember]
        public TriageStatusEnum TriageStatus { get; set; }        // 分诊状态
        [DataMember]
        public Patient Patient { get; set; }                      // 患者
        [DataMember]
        public SignalSource SignalSource { get; set; }            // 号源
        [DataMember]
        public User RegisterUser { get; set; }                    // 经办人
        [DataMember]
        public PayWayEnum PayWayEnum { get; set; }                // 支付方式
        [DataMember]
        public decimal ReturnServiceMoney { get; set; }           // 退号手续费
        [DataMember]
        public int ReturnUserID { get; set; }                     // 退号人ID
        [DataMember]
        public DateTime? ReturnTime { get; set; }                 // 退号时间
        [DataMember]
        public int ArriveUserID { get; set; }                     // 到诊用户ID
        [DataMember]
        public DateTime? ArriveTime { get; set; }                 // 到诊时间 

    }
}
