using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 医嘱明细基类
    public class DoctorAdviceDetailBase
    {
        public int ID { get; set; }
        public int AllNum { get; set; }
        public decimal SellPrice { get; set; }           // 参考价格
        public string Remarks { get; set; }
    }
}
