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
            EmployeeJobHistorys = new List<EmployeeJobHistory>();
            JobGrade = JobGradeEnum.初级;
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
        /// 职位等级
        /// </summary>
        public JobGradeEnum JobGrade { get; set; }

        /// <summary>
        /// 职位类别
        /// </summary>
        public JobTypeEnum JobType { get; set; }
        /// <summary>
        /// 工作模块
        /// </summary>
        public PowerEnum PowerEnum { get; set; }

        /// <summary>
        /// 员工职位变更历史
        /// </summary>
        public virtual ICollection<EmployeeJobHistory> EmployeeJobHistorys { get; set; }
    }
}
