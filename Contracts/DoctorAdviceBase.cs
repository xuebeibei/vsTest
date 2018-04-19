using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum DoctorAdviceBaseEnum
    {
        处方,
        治疗,
        化验,
        检查,
        材料,
        其他
    }

    public enum RecipeTypeEnum
    {
        普通处方,             // 普通处方
        急诊处方,             // 急诊处方
        儿科处方,               // 儿科处方  
        麻精一,           // 麻精一   
        精二              // 精二  
    }

    public enum DoctorAdviceContentEnum
    {
        西药成药,
        中药
    }

    public enum ChargeStatusEnum
    {
        未收费,
        部分收费,
        全部收费
    }

    public enum ExecuteEnum
    {
        未执行,
        已执行
    }

    [DataContract]
    public class DoctorAdviceBase
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NO { get; set; }
        [DataMember]
        public decimal SumOfMoney { get; set; }                 // 金额
        [DataMember]
        public DateTime? WriteTime { get; set; }                // 开具时间
        [DataMember]
        public int WriteDoctorUserID { get; set; }              // 开具医生
        [DataMember]
        public int PatientID { get; set; }                      // 所属患者
        [DataMember]
        public ChargeStatusEnum ChargeStatusEnum { get; set; }  // 收费状态
        
        [DataMember]
        public ExecuteEnum ExecuteEnum { get; set; }            // 执行状态

        [DataMember]
        public int RegistrationID { get; set; }                 // 门诊看诊标记
        [DataMember]
        public int InpatientID { get; set; }                    // 住院看诊标记
        [DataMember]
        public Employee WriteDoctorUser { get; set; }       // 开具医生
        [DataMember]
        public Patient Patient { get; set; }
        [DataMember]
        public DoctorAdviceBaseEnum DoctorAdviceEnum { get; set; }
    }
}
