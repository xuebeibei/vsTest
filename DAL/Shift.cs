using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 班次
    /// </summary>
    public class Shift
    {
        public Shift()
        {
            WorkPlans = new List<WorkPlan>();
        }
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedDate { get; set; }


        /// <summary>
        /// 该时段对应的排班记录
        /// </summary>
        public virtual ICollection<WorkPlan> WorkPlans { get; set; }
    }
}
