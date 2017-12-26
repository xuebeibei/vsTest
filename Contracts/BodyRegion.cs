using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class BodyRegion
    {
        public BodyRegion()
        {

        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string AbbrPY { get; set; }
        [DataMember]
        public string AbbrWB { get; set; }
        [DataMember]
        public int InspectItemID { get; set; }
        [DataMember]
        public virtual InspectItem InspectItem { get; set; }     // 可以检查该部位的检查项目
    }
}
