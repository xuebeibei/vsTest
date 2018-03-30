using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他服务字典
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem”的 XML 注释
    public class OtherServiceItem
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.OtherServiceItem()”的 XML 注释
        public OtherServiceItem()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.OtherServiceItem()”的 XML 注释
        {
            OtherServiceDoctorAdviceDetails = new List<OtherServiceDoctorAdviceDetail>();
            OtherServiceChargeDetails = new List<OtherServiceChargeDetail>();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.ID”的 XML 注释
        public int ID { get; set; }                                 // ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.Name”的 XML 注释
        public string Name { get; set; }                            // 名称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.Name”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.AbbrPY”的 XML 注释
        public string AbbrPY { get; set; }                          // 拼音简称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.AbbrPY”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.AbbrWB”的 XML 注释
        public string AbbrWB { get; set; }                          // 五笔简称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.AbbrWB”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.Price”的 XML 注释
        public decimal Price { get; set; }                           // 价格
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.Price”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.Unit”的 XML 注释
        public string Unit { get; set; }                            // 单位
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.Unit”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.OtherServiceDoctorAdviceDetails”的 XML 注释
        public virtual ICollection<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.OtherServiceDoctorAdviceDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.OtherServiceChargeDetails”的 XML 注释
        public virtual ICollection<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“OtherServiceItem.OtherServiceChargeDetails”的 XML 注释
    }
}
