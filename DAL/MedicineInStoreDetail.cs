using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品入库明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail”的 XML 注释
    public class MedicineInStoreDetail : StoreOperateBillDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineInStoreDetail()”的 XML 注释
        public MedicineInStoreDetail()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineInStoreDetail()”的 XML 注释
        {

        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineID”的 XML 注释
        public int MedicineID { get; set; }          // 对应药品字典
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineInStoreID”的 XML 注释
        public int MedicineInStoreID { get; set; }  // 入库单ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineInStoreID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.Medicine”的 XML 注释
        public virtual Medicine Medicine { get; set; }    // 药品字典外键
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.Medicine”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineInStore”的 XML 注释
        public virtual MedicineInStore MedicineInStore { get; set; }   // 入库单外键
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStoreDetail.MedicineInStore”的 XML 注释
    }
}
