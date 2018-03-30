using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品出库表
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore”的 XML 注释
    public class MedicineOutStore : StoreOperateBillBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.MedicineOutStore()”的 XML 注释
        public MedicineOutStore()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.MedicineOutStore()”的 XML 注释
        {
            MedicineOutStoreDetails = new List<MedicineOutStoreDetail>();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.OutStoreEnum”的 XML 注释
        public OutStoreEnum OutStoreEnum { get; set; }   // 出库类型
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.OutStoreEnum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.FromStoreID”的 XML 注释
        public int FromStoreID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.FromStoreID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.ToStoreID”的 XML 注释
        public int ToStoreID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.ToStoreID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.ToOtherHospitalID”的 XML 注释
        public int ToOtherHospitalID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.ToOtherHospitalID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.ToSupplierID”的 XML 注释
        public int ToSupplierID { get; set; }        // 供货商退货 
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.ToSupplierID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.MedicineOutStoreDetails”的 XML 注释
        public virtual ICollection<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineOutStore.MedicineOutStoreDetails”的 XML 注释
    }
}
