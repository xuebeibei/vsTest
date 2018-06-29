using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
    public enum DoctorAdviceItemType
    {
        西成药品 = 1,
        中药 = 2,
        检验 = 3,
        检查 = 4,
        手术 = 5,
        治疗 = 6
    }

    public class DoctorAdviceItem
    {
        /// <summary>
        /// 医嘱项ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 医嘱项类别
        /// </summary>
        public DoctorAdviceItemType doctorAdviceItemType { get; set; }

        /// <summary>
        /// 医嘱项名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 医嘱项拼音简称
        /// </summary>
        public string Abbr { get; set; }

        /// <summary>
        /// 五笔
        /// </summary>
        public string WuBi { get; set; }

        /// <summary>
        /// 销售包装名称
        /// </summary>
        public string SellPackageName { get; set; }
        /// <summary>
        /// 最小包装名称
        /// </summary>
        public string MinPackageName { get; set; }
        /// <summary>
        /// 最小包装数值
        /// </summary>
        public decimal MinPackageNum { get; set; }

        /// <summary>
        /// 最小包装单位
        /// </summary>
        public string MinPackageUnit { get; set; }
        /// <summary>
        /// 换算系数
        /// </summary>
        public decimal ScalingFactor { get; set; }
    }
}
