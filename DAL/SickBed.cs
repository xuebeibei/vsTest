using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 病床
    public class SickBed
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int SickRoomID { get; set; }
        public string Remarks { get; set; }

        public virtual SickRoom SickRoom { get; set; }
    }
}
