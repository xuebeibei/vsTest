
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum DepartmentEnum
    {
        其他科室,     // 其他科室
        临床科室, // 临床科室
        医技科室       // 医技科室  
    }

    [DataContract]
#pragma warning disable CS0659 // “Department”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    public class Department
#pragma warning restore CS0659 // “Department”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    {
        public Department()
        {

            this.Name = "";
            this.Abbr = "";
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbr { get; set; }
        /// <summary>
        /// 科室楼层指引
        /// </summary>
        [DataMember]
        public string DepartmentAddress { get; set; }
        [DataMember]
        public DepartmentEnum DepartmentEnum { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var de = obj as Department;
            if (de == null)
                return false;
            if (de.ID == this.ID)
                return true;
            else
                return false;
        }
    }
}
