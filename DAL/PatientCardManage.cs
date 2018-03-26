using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 就诊卡操作类型
    /// </summary>
    public enum CardManageEnum
    {
        /// <summary>
        /// 新办卡
        /// </summary>
        eNew,
        /// <summary>
        /// 挂失卡
        /// </summary>
        eLost,
        /// <summary>
        /// 退还卡
        /// </summary>
        eReturn
    }

    /// <summary>
    /// 就诊卡管理记录
    /// </summary>
    public class PatientCardManage : MyTableBase
    {
        /// <summary>
        /// 所属患者ID
        /// </summary>
        public int PatientID { get; set; }
        /// <summary>
        /// 所属患者
        /// </summary>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// 就诊卡编号
        /// </summary>
        public string CardNo { get; set; }
        
        /// <summary>
        /// 就诊卡管理操作类型
        /// </summary>
        public CardManageEnum CardManageEnum { get; set; }
    }
}
