using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 号别
    /// </summary>
    public class SignalItem
    {
        /// <summary>
        /// 号别构造函数
        /// </summary>
        public SignalItem()
        {
            SignalSources = new List<SignalSource>();
        }

        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 号别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 医生职称
        /// </summary>
        public string DoctorJob { get; set; }

        /// <summary>
        /// 医事服务费
        /// </summary>
        public decimal SellPrice { get; set; }

        /// <summary>
        /// 号别所有的号源
        /// </summary>
        public virtual ICollection<SignalSource> SignalSources { get; set; }
    }
}
