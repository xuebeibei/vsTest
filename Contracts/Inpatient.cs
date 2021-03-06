﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
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

    //[DataContract]
    //public class Inpatient
    //{
    //    public Inpatient()
    //    {
    //        No = "021";
    //        InHospitalTime = DateTime.Now;
    //        BaoXianEnum = BaoXianEnum.自费;
    //        MarriageEnum = MarriageEnum.未婚;
    //        IllnesSstateEnum = IllnesSstateEnum.一般;
    //    }
    //    [DataMember]
    //    public int ID { get; set; }                              // ID
    //    [DataMember]
    //    public string No { get; set; }                           // 住院号
    //    [DataMember]
    //    public string CaseNo { get; set; }                       // 病历号
    //    [DataMember]
    //    public BaoXianEnum BaoXianEnum { get; set; }             // 费用类别
    //    [DataMember]
    //    public string YiBaoNo { get; set; }                      // 医保号
    //    [DataMember]
    //    public int PatientID { get; set; }                       // 患者ID
    //    [DataMember]
    //    public MarriageEnum MarriageEnum { get; set; }           // 婚姻状况
    //    [DataMember]
    //    public string Job { get; set; }                          // 职业
    //    [DataMember]
    //    public string WorkAddress { get; set; }                  // 单位地址 
    //    [DataMember]
    //    public string ContactsName { get; set; }                 // 联系人  
    //    [DataMember]
    //    public string ContactsTel { get; set; }                  // 联系人电话  
    //    [DataMember]
    //    public string ContactsAddress { get; set; }              // 联系人住址  
    //    [DataMember]
    //    public DateTime? InHospitalTime { get; set; }             // 入院时间
    //    [DataMember]
    //    public string InHospitalDiagnoses { get; set; }          // 入院诊断 
    //    [DataMember]
    //    public IllnesSstateEnum IllnesSstateEnum { get; set; }   // 入院病情
    //    [DataMember]
    //    public string InHospitalDoctorName { get; set; }         // 入院医生
    //    [DataMember]
    //    public string InHospitalDepartment { get; set; }         // 入院科室
    //    [DataMember]
    //    public int InPatientUserID { get; set; }                 // 经办人账户ID
    //    [DataMember]
    //    public DateTime? LeaveHospitalTime { get; set; }            // 出院时间
    //    [DataMember]
    //    public string LeaveHospitalDiagnoses { get; set; }          // 出院诊断 
    //    [DataMember]
    //    public string LeaveHospitalDoctorName { get; set; }         // 出院医生
    //    [DataMember]
    //    public string LeaveHospitalDepartment { get; set; }         // 出院科室
    //    [DataMember]
    //    public int LeaveHospitalUserID { get; set; }                 // 出院经办人账户ID 

    //    [DataMember]
    //    public InHospitalStatusEnum InHospitalStatusEnum { get; set; } // 住院状态
    //    [DataMember]
    //    public Patient Patient { get; set; }             // 报错，会形成循环或者树状引用
    //    [DataMember]
    //    public User InPatientUser { get; set; }
    //}
}
