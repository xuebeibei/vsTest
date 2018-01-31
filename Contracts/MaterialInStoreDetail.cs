using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialInStoreDetail : StoreOperateBillDetailBase
    {
        public MaterialInStoreDetail()
        {

        }
        [DataMember]
        public int MaterialID { get; set; }          // 对应物资字典
        [DataMember]
        public int MaterialInStoreID { get; set; }  // 入库单ID
        [DataMember]
        public MaterialItem Material { get; set; }    // 物资字典外键
    }
}
