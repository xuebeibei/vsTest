using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum JobEnum
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

    [DataContract]
    public class Job
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
        public bool Default { get; set; }

        [DataMember]
        public JobEnum JobEnum { get; set; }
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
