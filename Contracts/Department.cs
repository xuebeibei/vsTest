
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
    public class Department
    {
        public Department()
        {
            this.Nodes = new List<Department>();
            this.ParentDepartmentID = 0;//主节点的父id默认为0

            this.Name = "";
            this.Abbr = "";
        }
        [DataMember]
        public List<Department> Nodes { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbr { get; set; }
        [DataMember]
        public bool IsDoctorDepartment { get; set; }
        [DataMember]
        public int ParentDepartmentID { get; set; }
        [DataMember]
        public DepartmentEnum DepartmentEnum { get; set; }
    }
}
