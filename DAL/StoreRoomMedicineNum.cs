using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品库存
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum”的 XML 注释
    public class StoreRoomMedicineNum : StoreNumBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.StoreRoomMedicineNum()”的 XML 注释
        public StoreRoomMedicineNum()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.StoreRoomMedicineNum()”的 XML 注释
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
            MedicineChargeDetails = new List<MedicineChargeDetail>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.MedicineID”的 XML 注释
        public int MedicineID { get; set; }          // 对应药品字典
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.MedicineID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.Medicine”的 XML 注释
        public virtual Medicine Medicine { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.Medicine”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.MedicineOutStoreDetails”的 XML 注释
        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.MedicineOutStoreDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.MedicineChargeDetails”的 XML 注释
        public virtual ICollection<MedicineChargeDetail> MedicineChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“StoreRoomMedicineNum.MedicineChargeDetails”的 XML 注释
    }
}
