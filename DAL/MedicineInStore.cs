using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品入库表
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore”的 XML 注释
    public class MedicineInStore : StoreOperateBillBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore.MedicineInStore()”的 XML 注释
        public MedicineInStore()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore.MedicineInStore()”的 XML 注释
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore.InStoreEnum”的 XML 注释
        public InStoreEnum InStoreEnum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore.InStoreEnum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore.FromSupplierID”的 XML 注释
        public int FromSupplierID { get; set; }      // 供应商
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore.FromSupplierID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore.ToStoreID”的 XML 注释
        public int ToStoreID { get; set; }           // 入库库房
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore.ToStoreID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore.FromSupplier”的 XML 注释
        public virtual Supplier FromSupplier { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore.FromSupplier”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineInStore.MedicineInStoreDetails”的 XML 注释
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineInStore.MedicineInStoreDetails”的 XML 注释
    }
}
