using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 物资项目
    /// </summary>
    public class MaterialItem : GoodsBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialItem()
        {
            MaterialDoctorAdviceDetails = new List<MaterialDoctorAdviceDetail>();
            StoreRoomMaterialNums = new List<StoreRoomMaterialNum>();
        }

        /// <summary>
        /// 是否是贵重
        /// </summary>
        public bool Valuable { get; set; }                      

        /// <summary>
        /// 材料医嘱明细列表
        /// </summary>
        public virtual ICollection<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }
        /// <summary>
        /// 物资库存列表
        /// </summary>
        public virtual ICollection<StoreRoomMaterialNum> StoreRoomMaterialNums { get; set; }
    }
}
