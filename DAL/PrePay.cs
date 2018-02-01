using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 预付单
    public class PrePay
    {
        public int ID { get; set; }
        public string No { get; set; }
        public DateTime? PrePayTime { get; set; }
        public decimal PrePayMoney { get; set; }
        public string PayerName { get; set; }
        public PrePayWayEnum PrePayWayEnum { get; set; }
        public int PatientID { get; set; }
        public int UserID { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual User User { get; set; }
    }
}
