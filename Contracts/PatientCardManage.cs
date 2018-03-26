using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    //[DataContract]
    //public class PatientCardManage
    //{
    //}
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
    [DataContract]
    public class PatientCardManage : MyTableBase
    {
        /// <summary>
        /// 所属患者ID
        /// </summary>
        [DataMember]
        public int PatientID { get; set; }
        /// <summary>
        /// 所属患者
        /// </summary>
        [DataMember]
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// 就诊卡编号
        /// </summary>
        [DataMember]
        public string CardNo { get; set; }

        /// <summary>
        /// 就诊卡管理操作类型
        /// </summary>
        [DataMember]
        public CardManageEnum CardManageEnum { get; set; }
    }
}
