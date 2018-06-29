using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 给药途径
    /// </summary>
    public class AdministrationRoute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdministrationRoute()
        {
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 给药途径名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 给药途径名称拼音简写，用来搜索
        /// </summary>
        public string Abbr { get; set; }
        /// <summary>
        /// 给药途径名称五笔，用来搜索
        /// </summary>
        public string WuBi { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
