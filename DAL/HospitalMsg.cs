using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 医院信息
    /// </summary>
    public class HospitalMsg
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 是否是医保定点
        /// </summary>
        public bool bIsYiBao { get; set; }

        /// <summary>
        /// 医保号
        /// </summary>
        public string YiBaoNo { get; set; }
    }
}
