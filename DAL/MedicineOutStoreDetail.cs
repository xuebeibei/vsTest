using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品出库明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail”的 XML 注释
    public class MedicineOutStoreDetail : StoreOperateBillDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.StoreRoomMedicineNumID”的 XML 注释
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.StoreRoomMedicineNumID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.NumBeforeOut”的 XML 注释
        public int NumBeforeOut { get; set; }            // 出库前数量 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.NumBeforeOut”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.MedicineOutStoreID”的 XML 注释
        public int MedicineOutStoreID { get; set; }  // 出库单ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.MedicineOutStoreID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.StoreRoomMedicineNum”的 XML 注释
        public virtual StoreRoomMedicineNum StoreRoomMedicineNum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.StoreRoomMedicineNum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.MedicineOutStore”的 XML 注释
        public virtual MedicineOutStore MedicineOutStore { get; set; }   // 出库单外键
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStoreDetail.MedicineOutStore”的 XML 注释
    }
}
