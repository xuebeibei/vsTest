﻿using System;
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

    public enum SeeDoctorStatusEnum { 未到诊, 候诊中, 接诊中, 接诊结束 , 申请入院 };
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
        public WorkPlan SignalSource { get; set; }            // 号源
        [DataMember]
        public User RegisterUser { get; set; }                    // 经办人
        [DataMember]
        public PayWayEnum PayWayEnum { get; set; }                // 支付方式
        [DataMember]
        public int ArriveUserID { get; set; }                     // 到诊用户ID
        [DataMember]
        public DateTime? ArriveTime { get; set; }                 // 到诊时间 
        [DataMember]
        public DateTime? StartSeeDoctorTime { get; set; }               // 开始看诊时间 
        [DataMember]
        public DateTime? EndSeeDoctorTime { get; set; }                 // 结束看诊时间

        public override bool Equals(object obj)
        {
            var temp = obj as Registration;
            if (temp == null)
                return false;
            if (temp.ID != this.ID)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
