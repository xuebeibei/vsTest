using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品盘存明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail”的 XML 注释
    public class MedicineCheckStoreDetail : StoreOperateBillDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.MedicineCheckStoreDetail()”的 XML 注释
        public MedicineCheckStoreDetail()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.MedicineCheckStoreDetail()”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.StoreRoomMedicineNumID”的 XML 注释
        public int StoreRoomMedicineNumID { get; set; }  // 库存ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.StoreRoomMedicineNumID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.NumBeforeCheck”的 XML 注释
        public int NumBeforeCheck { get; set; }          // 出库前数量 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.NumBeforeCheck”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.MedicineCheckStoreID”的 XML 注释
        public int MedicineCheckStoreID { get; set; }    // 盘存单ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.MedicineCheckStoreID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.MedicineCheckStore”的 XML 注释
        public virtual MedicineCheckStore MedicineCheckStore { get; set; }   // 盘存单外键
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineCheckStoreDetail.MedicineCheckStore”的 XML 注释
    }
}
