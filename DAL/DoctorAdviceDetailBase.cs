using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 医嘱明细基类
    /// </summary>
    public class DoctorAdviceDetailBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int AllNum { get; set; }
        /// <summary>
        /// 参考价格
        /// </summary>
        public decimal SellPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
