using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 入院申请
    /// </summary>
    public class InHospitalApply
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InHospitalApply()
        {

        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime { get; set; }
        /// <summary>
        /// 患者ID
        /// </summary>
        public int PatientID { get; set; }
        /// <summary>
        /// 申请人用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 申请单状态
        /// </summary>
        public InHospitalApplyEnum InHospitalApplyEnum { get; set; }

        /// <summary>
        /// 申请人用户
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 被申请的患者
        /// </summary>
        public virtual Patient Patient { get; set; }

    }
}
