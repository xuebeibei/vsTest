using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace DAL
{
    /// <summary>
    /// 用于modelBuilder全局设置自定义精度属性
    /// </summary>
    public class DecimalPrecisionAttributeConvention
        : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“DecimalPrecisionAttributeConvention.Apply(ConventionPrimitivePropertyConfiguration, DecimalPrecisionAttribute)”的 XML 注释
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DecimalPrecisionAttribute attribute)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“DecimalPrecisionAttributeConvention.Apply(ConventionPrimitivePropertyConfiguration, DecimalPrecisionAttribute)”的 XML 注释
        {
            if (attribute.Precision < 1 || attribute.Precision > 38)
            {
                throw new InvalidOperationException("Precision must be between 1 and 38.");
            }
            if (attribute.Scale > attribute.Precision)
            {
                throw new InvalidOperationException("Scale must be between 0 and the Precision value.");
            }
            configuration.HasPrecision(attribute.Precision, attribute.Scale);
        }
    }
}
