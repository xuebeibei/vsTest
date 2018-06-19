using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
    public class LevelOneDepartment
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LevelOneDepartment()
        {
            LevelTwoDepartments = new List<LevelTwoDepartment>();
        }

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
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 化验医嘱收费单明细列表
        /// </summary>
        public ICollection<LevelTwoDepartment> LevelTwoDepartments { get; set; }
    }

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
    }
}
