using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Employee
    {
        public Employee()
        {
            Name = "";
            Department = new Department();
            Job = new Job();
        }
 
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbr { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public int JobID { get; set; }
        [DataMember]
        public GenderEnum Gender { get; set; }   // 性别
        [DataMember]
        public Job Job { get; set; }
        [DataMember]
        public virtual Department Department { get; set; }

    }
}
