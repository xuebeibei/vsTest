using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 权限模块
    /// </summary>
    public enum PowerEnum
    {
        /// <summary>
        /// 系统设置
        /// </summary>
        设置模块,
        /// <summary>
        /// 医生模块
        /// </summary>
        医生模块,
        /// <summary>
        /// 综合收费模块
        /// </summary>
        综合收费模块,
        /// <summary>
        /// 库存管理模块
        /// </summary>
        库存管理模块,
        /// <summary>
        /// 护士模块
        /// </summary>
        护士模块
    }

    /// <summary>
    /// 职位类
    /// </summary>
    public class Job
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Job()
        {
            Name = "";
            Employees = new List<Employee>();
            JobEnum = JobEnum.初级;
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否默认职位，弃用
        /// </summary>
        public bool Default { get; set; }
        /// <summary>
        /// 职位等级
        /// </summary>
        public JobEnum JobEnum { get; set; }
        /// <summary>
        /// 工作模块
        /// </summary>
        public PowerEnum PowerEnum { get; set; }

        /// <summary>
        /// 该职位的员工列表
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
