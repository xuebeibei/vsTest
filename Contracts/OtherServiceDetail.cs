using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class OtherServiceDetail
    {
        public OtherServiceDetail()
        {

        }
        [DataMember]
        public int ID { get; set; }                                      // ID
        [DataMember]
        public int OtherServiceItemID { get; set; }                      // 其他服务ID
        [DataMember]
        public int Num { get; set; }                                     // 次数
        [DataMember]
        public string Illustration { get; set; }                         // 说明
        [DataMember]
        public int OtherServiceID { get; set; }                          // 所属其他服务单ID
        [DataMember]
        public OtherServiceItem OtherServiceItem { get; set; }

    }
}
