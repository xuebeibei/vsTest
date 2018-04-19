using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 医嘱基类
    /// </summary>
    public class DoctorAdviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DoctorAdviceBase()
        {
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 医嘱编号
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal SumOfMoney { get; set; }
        /// <summary>
        /// 开具时间
        /// </summary>
        public DateTime? WriteTime { get; set; }
        /// <summary>
        /// 开具医生
        /// </summary>
        public int WriteDoctorUserID { get; set; }
        /// <summary>
        /// 所属患者ID
        /// </summary>
        public int PatientID { get; set; }
        /// <summary>
        /// 收费状态
        /// </summary>
        public ChargeStatusEnum ChargeStatusEnum { get; set; }

        /// <summary>
        /// 执行状态
        /// </summary>
        public ExecuteEnum ExecuteEnum { get; set; }
        /// <summary>
        /// 门诊看诊标记
        /// </summary>
        public int RegistrationID { get; set; }
        /// <summary>
        /// 住院看诊标记
        /// </summary>
        public int InpatientID { get; set; }

        /// <summary>
        /// 开具医生
        /// </summary>
        public virtual Employee WriteDoctorUser { get; set; }
        /// <summary>
        /// 所属患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
