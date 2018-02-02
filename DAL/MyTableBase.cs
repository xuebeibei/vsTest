using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyTableBase
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public DateTime CurrentTime { get; set; }

        public virtual User User { get; set; }
    }
}
