using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class OtherService
    {
        public OtherService()
        {
            OtherServiceDetails = new List<OtherServiceDetail>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NO { get; set; }
        [DataMember]
        public int RegistrationID { get; set; }                   // 门诊ID
        [DataMember]
        public int InpatientID { get; set; }                      // 住院ID
        [DataMember]
        public double SumOfMoney { get; set; }                    // 金额
        [DataMember]
        public DateTime? WriteTime { get; set; }                   // 开具时间
        [DataMember]
        public int WriteUserID { get; set; }                      // 开具医生
        [DataMember]
        public User WriteUser { get; set; }               // 开具医生
        [DataMember]
        public List<OtherServiceDetail> OtherServiceDetails { get; set; }

        public string ToTipString()
        {
            string str = "";

            str = "处方号：" + this.NO + "  " +
                "处方日期：" + this.WriteTime.ToString() + "  " +
                "就诊科室：" + "外科" + "  " +
                "看诊医师：" + "张医生" + "  ";
            return str;
        }
    }
}
