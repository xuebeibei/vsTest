using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 库存表基类
    public class StoreNumBase
    {
        public StoreNumBase()
        {
        }

        public int ID { get; set; }                  // ID
        public int StoreRoomID { get; set; }         // 库房ID
        public int SupplierID { get; set; }          // 供应商ID
        public string Batch { get; set; }            // 批次
        public DateTime? ExpirationDate { get; set; } // 有效期
        [DecimalPrecision(18, 4)]
        public decimal StorePrice { get; set; }      // 成本价
        public int Num { get; set; }                 // 库存

        public virtual StoreRoom StoreRoom { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
