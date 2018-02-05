using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 医嘱基类
    public class DoctorAdviceBase
    {
        public DoctorAdviceBase()
        {
        }
        public int ID { get; set; }
        public string NO { get; set; }
        public decimal SumOfMoney { get; set; }                 // 金额
        public DateTime? WriteTime { get; set; }                // 开具时间
        public int WriteDoctorUserID { get; set; }              // 开具医生
        public int PatientID { get; set; }                      // 所属患者
        public ChargeStatusEnum ChargeStatusEnum { get; set; }  // 收费状态

        public ExecuteEnum ExecuteEnum { get; set; }            // 执行状态
        public int RegistrationID { get; set; }                 // 门诊看诊标记
        public int InpatientID { get; set; }                    // 住院看诊标记

        public virtual User WriteDoctorUser { get; set; }       // 开具医生
        public virtual Patient Patient { get; set; }
    }
}
