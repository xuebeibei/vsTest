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
        Initial,        // 初级
        Middle,         // 中级
        Senior          // 高级
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
    }
}
