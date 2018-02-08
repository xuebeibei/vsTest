using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 出院
    /// </summary>
    public class LeaveHospital : MyTableBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LeaveHospital()
        {
            RecallHospitals = new List<RecallHospital>();
        }
        /// <summary>
        /// 住院ID
        /// </summary>
        public int InHospitalID { get; set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime LeaveTime { get; set; }
        /// <summary>
        /// 出院诊断
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        /// 住院信息
        /// </summary>
        public virtual InHospital InHospital { get; set; }
        /// <summary>
        /// 对应的召回信息列表
        /// </summary>
        public virtual ICollection<RecallHospital> RecallHospitals { get; set; }
    }
}
