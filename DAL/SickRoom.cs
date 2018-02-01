using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 病房
    public class SickRoom
    {
        public SickRoom()
        {
            SickBeds = new List<SickBed>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public SickRoomEnum SickRoomEnum { get; set; }

        public int DepartmentID { get; set; }

        public string Address { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<SickBed> SickBeds { get; set; }
    }
}
