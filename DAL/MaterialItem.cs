using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资项目
    public class MaterialItem : GoodsBase
    {
        public MaterialItem()
        {
            MaterialDoctorAdviceDetails = new List<MaterialDoctorAdviceDetail>();
            StoreRoomMaterialNums = new List<StoreRoomMaterialNum>();
        }

        public bool Valuable { get; set; }                      // 是否是贵重

        public virtual ICollection<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
        public virtual ICollection<StoreRoomMaterialNum> StoreRoomMaterialNums { get; set; }
    }
}
