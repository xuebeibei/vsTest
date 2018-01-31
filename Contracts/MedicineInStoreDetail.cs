using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineInStoreDetail : StoreOperateBillDetailBase
    {
        public MedicineInStoreDetail()
        {

        }

        [DataMember]
        public int MedicineID { get; set; }          // 对应药品字典
        [DataMember]
        public int MedicineInStoreID { get; set; }  // 入库单ID
        [DataMember]
        public virtual Medicine Medicine { get; set; }    // 药品字典外键
    }
}
