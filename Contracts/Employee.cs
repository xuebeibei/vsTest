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
            GetDepartment = new Department();
            Job = new Job();
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Department GetDepartment { get; set; }
        [DataMember]
        public Job Job { get; set; }
        [DataMember]
        public GenderEnum Gender { get; set; }   // 性别

    }
}
