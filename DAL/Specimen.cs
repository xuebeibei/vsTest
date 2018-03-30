using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 化验标本
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Specimen”的 XML 注释
    public class Specimen
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Specimen”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Specimen.Specimen()”的 XML 注释
        public Specimen()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Specimen.Specimen()”的 XML 注释
        {
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Specimen.ID”的 XML 注释
        public int ID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Specimen.ID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Specimen.Name”的 XML 注释
        public string Name { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Specimen.Name”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Specimen.AbbrPY”的 XML 注释
        public string AbbrPY { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Specimen.AbbrPY”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Specimen.AbbrWB”的 XML 注释
        public string AbbrWB { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Specimen.AbbrWB”的 XML 注释

    }
}
