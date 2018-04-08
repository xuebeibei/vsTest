using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum JobGradeEnum
    {
        初级,        // 初级
        中级,         // 中级
        高级          // 高级
    }

    public enum PowerEnum
    {
        设置模块,
        医生模块,
        综合收费模块,
        库存管理模块,
        护士模块,
        就诊卡模块
    }


    /// <summary>
    /// 系统职位类别
    /// </summary>
    public enum JobTypeEnum
    {
        /// <summary>
        /// 护理
        /// </summary>
        护理,
        /// <summary>
        /// 药学
        /// </summary>
        药学,
        /// <summary>
        /// 中药学
        /// </summary>
        中药学,
        /// <summary>
        /// 检验
        /// </summary>
        检验,
        /// <summary>
        /// 放射
        /// </summary>
        放射,
        /// <summary>
        /// 医师
        /// </summary>
        医师,
        /// <summary>
        /// 财务管理
        /// </summary>
        财务管理,
        /// <summary>
        /// 收费管理
        /// </summary>
        收费管理,
        /// <summary>
        /// 库房管理
        /// </summary>
        库房管理,
        /// <summary>
        /// 患者管理
        /// </summary>
        患者管理,
        /// <summary>
        /// 系统管理
        /// </summary>
        系统管理
    }

    [DataContract]
#pragma warning disable CS0659 // “Job”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    public class Job
#pragma warning restore CS0659 // “Job”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    {
        public Job()
        {
            Name = "";
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public JobGradeEnum JobGrade { get; set; }
        /// <summary>
        /// 职位类别
        /// </summary>
        [DataMember]
        public JobTypeEnum JobType { get; set; }

        [DataMember]
        public PowerEnum PowerEnum { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var job = obj as Job;
            if (job == null)
                return false;
            if (job.ID != this.ID)
                return false;

            return true;
        }
    }
}
