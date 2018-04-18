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
        }
 
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbr { get; set; }
        [DataMember]
        public int JobID { get; set; }
        [DataMember]
        public GenderEnum Gender { get; set; }   // 性别
        [DataMember]
        public Job Job { get; set; }
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

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
