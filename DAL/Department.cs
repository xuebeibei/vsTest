using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Department
    {
        public Department()
        {
            this.Name = "";
            this.Abbr = "";
            this.DepartmentEnum = DepartmentEnum.其他科室;
            this.ParentID = 0;
            Employees = new List<Employee>();
            SickRooms = new List<SickRoom>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public DepartmentEnum DepartmentEnum { get; set; }
        public int ParentID { get; set; }    // 父类科室

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SickRoom> SickRooms { get; set; }
    }
}
