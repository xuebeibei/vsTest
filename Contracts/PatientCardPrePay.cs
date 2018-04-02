using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum PrePayWayEnum
    {
        现金
    }

    /// <summary>
    /// 预交金记录类型
    /// </summary>
    public enum PrePayTypeEnum
    {
        /// <summary>
        /// 缴款
        /// </summary>
        缴款,

        /// <summary>
        /// 退款
        /// </summary>
        退款
    }

    /// <summary>
    /// 预交金记录
    /// </summary>
    [DataContract]
    public class PatientCardPrePay : MyTableBase
    {
        /// <summary>
        /// 预交金记录编号
        /// </summary>
        [DataMember]
        public string No { get; set; }

        /// <summary>
        /// 预交金金额
        /// </summary>
        [DataMember]
        public decimal PrePayMoney { get; set; }

        /// <summary>
        /// 预交金参与人姓名
        /// </summary>
        [DataMember]
        public string PayerName { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [DataMember]
        public PrePayWayEnum PrePayWayEnum { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [DataMember]
        public PrePayTypeEnum PrePayType { get; set; }

        /// <summary>
        /// 预交金患者ID
        /// </summary>
        [DataMember]
        public int PatientID { get; set; }

        /// <summary>
        /// 预交金关联患者
        /// </summary>
        [DataMember]
        public Patient Patient { get; set; }
    }
}
