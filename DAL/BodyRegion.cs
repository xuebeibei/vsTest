using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查部位
    /// </summary>
    public class BodyRegion
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BodyRegion()
        {

        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 拼音简拼
        /// </summary>
        public string AbbrPY { get; set; }
        /// <summary>
        /// 五笔简拼
        /// </summary>
        public string AbbrWB { get; set; }
    }
}
