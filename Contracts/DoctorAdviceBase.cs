using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
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
        public int RegistrationID { get; set; }                 // 门诊看诊标记
        [DataMember]
        public int InpatientID { get; set; }                    // 住院看诊标记
        [DataMember]
        public User WriteDoctorUser { get; set; }       // 开具医生
        [DataMember]
        public Patient Patient { get; set; }

        public override string ToString()
        {
            string str = "";

            str = "处方号：" + this.NO + "  " +
                "处方日期：" + this.WriteTime.ToString() + "  " +
                "就诊科室：" + (this.WriteDoctorUser == null ? "" :
                (this.WriteDoctorUser.Employee == null ? "" :
                (this.WriteDoctorUser.Employee.Department == null ? "" : this.WriteDoctorUser.Employee.Department.Name)
                )
                ) + "  " +
                "看诊医师：" + (this.WriteDoctorUser == null ? "" :
                (this.WriteDoctorUser.Employee == null ? "" : this.WriteDoctorUser.Employee.Name)
                ) + "  ";
            return str;
        }
    }
}
