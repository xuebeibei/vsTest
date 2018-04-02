using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 预交金记录类型
    /// </summary>
    public enum PrePayTypeEnum
    {
        /// <summary>
        /// 缴款
        /// </summary>
        ePay,

        /// <summary>
        /// 退款
        /// </summary>
        eReturn
    }

    /// <summary>
    /// 预交金记录
    /// </summary>
    public class PatientCardPrePay : MyTableBase
    {
        /// <summary>
        /// 预交金记录编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 预交金金额
        /// </summary>
        [DecimalPrecision(18, 2)]
        public decimal PrePayMoney { get; set; }

        /// <summary>
        /// 预交金参与人姓名
        /// </summary>
        public string PayerName { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public PrePayWayEnum PrePayWayEnum { get; set; }

        /// <summary>
        /// 预交金患者ID
        /// </summary>
        public int PatientID { get; set; }

        /// <summary>
        /// 预交金关联患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
