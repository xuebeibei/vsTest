using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资库存
    public class StoreRoomMaterialNum : StoreNumBase
    {
        public StoreRoomMaterialNum()
        {
            MaterialChargeDetails = new List<MaterialChargeDetail>();
        }
        public int MaterialItemID { get; set; }          // 对应药品字典
        public virtual MaterialItem MaterialItem { get; set; }
        public virtual ICollection<MaterialChargeDetail> MaterialChargeDetails { get; set; }
    }
}
