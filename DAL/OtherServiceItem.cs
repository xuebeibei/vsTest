using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他服务字典
    public class OtherServiceItem
    {
        public OtherServiceItem()
        {
            OtherServiceDoctorAdviceDetails = new List<OtherServiceDoctorAdviceDetail>();
            OtherServiceChargeDetails = new List<OtherServiceChargeDetail>();
        }

        public int ID { get; set; }                                 // ID
        public string Name { get; set; }                            // 名称
        public string AbbrPY { get; set; }                          // 拼音简称
        public string AbbrWB { get; set; }                          // 五笔简称
        [DecimalPrecision(18, 4)]
        public decimal Price { get; set; }                           // 价格
        public string Unit { get; set; }                            // 单位

        public virtual ICollection<OtherServiceDoctorAdviceDetail> OtherServiceDoctorAdviceDetails { get; set; }
        public virtual ICollection<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
    }
}
