using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 值班类别
    /// </summary>
    public class WorkType
    {
        /// <summary>
        /// 号别构造函数
        /// </summary>
        public WorkType()
        {
            WorkPlans = new List<WorkPlan>();
            //SignalTypes = new List<SignalType>();
        }
        /// <summary>
        /// 值班类别ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 值班类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 该值班类别应的排班记录
        /// </summary>
        public virtual ICollection<WorkPlan> WorkPlans { get; set; }

        ///// <summary>
        ///// 该值班类型对应的可选号别
        ///// </summary>
        //public virtual ICollection<SignalType> SignalTypes { get; set; }
    }
}
