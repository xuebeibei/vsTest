using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 治疗项目
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem”的 XML 注释
    public class TherapyItem
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.TherapyItem()”的 XML 注释
        public TherapyItem()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.TherapyItem()”的 XML 注释
        {
            TherapyDoctorAdviceDetails = new List<TherapyDoctorAdviceDetail>();
            TherapyChargeDetails = new List<TherapyChargeDetail>();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.ID”的 XML 注释
        public int ID { get; set; }                                 // ID
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.Name”的 XML 注释
        public string Name { get; set; }                            // 名称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.Name”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.AbbrPY”的 XML 注释
        public string AbbrPY { get; set; }                          // 拼音简称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.AbbrPY”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.AbbrWB”的 XML 注释
        public string AbbrWB { get; set; }                          // 五笔简称
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.AbbrWB”的 XML 注释
        [DecimalPrecision(18, 4)]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.Price”的 XML 注释
        public decimal Price { get; set; }                          // 价格
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.Price”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.Unit”的 XML 注释
        public string Unit { get; set; }                            // 单位
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.Unit”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.YiBaoEnum”的 XML 注释
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.YiBaoEnum”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.TherapyDoctorAdviceDetails”的 XML 注释
        public virtual ICollection<TherapyDoctorAdviceDetail> TherapyDoctorAdviceDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.TherapyDoctorAdviceDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“TherapyItem.TherapyChargeDetails”的 XML 注释
        public virtual ICollection<TherapyChargeDetail> TherapyChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“TherapyItem.TherapyChargeDetails”的 XML 注释
    }
}
