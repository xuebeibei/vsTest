using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum PowerEnum
    {
        设置模块,
        医生模块,
        综合收费模块,
        库存管理模块,
        护士模块
    }

    public class Job
    {
        public Job()
        {
            Name = "";
            Employees = new List<Employee>();
            JobEnum = JobEnum.初级;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Default { get; set; }
        public JobEnum JobEnum { get; set; }
        public PowerEnum PowerEnum { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
