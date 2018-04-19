using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 母表
    /// </summary>
    public class MyTableBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CurrentTime { get; set; }
        /// <summary>
        /// 表所对应的员工
        /// </summary>
        public virtual Employee User { get; set; }
    }
}
