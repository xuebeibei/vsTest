using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资库存
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum”的 XML 注释
    public class StoreRoomMaterialNum : StoreNumBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.StoreRoomMaterialNum()”的 XML 注释
        public StoreRoomMaterialNum()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.StoreRoomMaterialNum()”的 XML 注释
        {
            MaterialChargeDetails = new List<MaterialChargeDetail>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.MaterialItemID”的 XML 注释
        public int MaterialItemID { get; set; }          // 对应药品字典
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.MaterialItemID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.MaterialItem”的 XML 注释
        public virtual MaterialItem MaterialItem { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.MaterialItem”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.MaterialChargeDetails”的 XML 注释
        public virtual ICollection<MaterialChargeDetail> MaterialChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMaterialNum.MaterialChargeDetails”的 XML 注释
    }
}
