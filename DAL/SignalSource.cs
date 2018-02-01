using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SignalSource
    {
        public SignalSource()
        {
            Registrations = new List<Registration>();
        }
        public int ID { get; set; }                  // 号源ID
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }           // 号源单价

        public DateTime? VistTime { get; set; }       // 看诊日期
        public int MaxNum { get; set; }               // 最大号源
        public int SignalItemID { get; set; }         // 号源种类
        public int EmployeeID { get; set; }           // 值班医生
        public int DepartmentID { get; set; }         // 所属科室
        public virtual SignalItem SignalItem { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号     
    }
}
