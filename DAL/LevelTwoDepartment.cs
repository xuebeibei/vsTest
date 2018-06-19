using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 二级科室
    /// </summary>
    public class LevelTwoDepartment
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 科室简称
        /// </summary>
        public string Abbr { get; set; }

        /// <summary>
        /// 科室位置
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 一级科室ID
        /// </summary>
        public int LevelOneDepartmentID { get; set; }

        /// <summary>
        /// 一级科室
        /// </summary>
        public virtual LevelOneDepartment LevelOneDepartment { get; set; }
    }
}
