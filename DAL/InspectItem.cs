using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 检查项目
    public class InspectItem
    {
        public InspectItem()
        {
            InspectDoctorAdviceDetail = new List<InspectDoctorAdviceDetail>();
            InspectChargeDetails = new List<InspectChargeDetail>();
        }

        public int ID { get; set; }                             // ID
        public string Name { get; set; }                        // 名称
        public string AbbrPY { get; set; }                      // 拼音简称
        public string AbbrWB { get; set; }                      // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                       // 价格
        public string Unit { get; set; }                        // 单位
        public YiBaoEnum YiBaoEnum { get; set; }                // 医保甲乙类 

        public virtual ICollection<InspectDoctorAdviceDetail> InspectDoctorAdviceDetail { get; set; }
        public virtual ICollection<InspectChargeDetail> InspectChargeDetails { get; set; }
    }
}
