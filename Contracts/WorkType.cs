using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 值班类别
    /// </summary>
    [DataContract]
    public class WorkType
    {
        /// <summary>
        /// 号别构造函数
        /// </summary>
        public WorkType()
        {
            //WorkPlans = new List<WorkPlan>();
        }
        /// <summary>
        /// 值班类别ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 值班类别名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }

        ///// <summary>
        ///// 该时号别应的排班记录
        ///// </summary>
        //[DataMember]
        //public virtual ICollection<WorkPlan> WorkPlans { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as WorkType;
            if (temp == null)
                return false;

            if (temp.ID == ID)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
