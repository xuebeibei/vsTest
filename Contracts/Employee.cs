using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
#pragma warning disable CS0659 // “Employee”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    public class Employee
#pragma warning restore CS0659 // “Employee”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
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
        public Department Department { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var em = obj as Employee;
            if (em == null)
                return false;
            if (em.ID == this.ID)
                return false;
            return true;
        }
    }
}
