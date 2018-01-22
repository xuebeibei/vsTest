using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum PayWayEnum
    {
        现金,
        支付宝,
        微信
    }

    [DataContract]
    public class PrePay
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string No { get; set; }
        [DataMember]
        public DateTime? PrePayTime { get; set; }
        [DataMember]
        public decimal PrePayMoney { get; set; }
        [DataMember]
        public string PayerName { get; set; }
        [DataMember]
        public PayWayEnum PayWayEnum { get; set; }
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public Patient Patient { get; set; }
        [DataMember]
        public User User { get; set; }
    }
}
