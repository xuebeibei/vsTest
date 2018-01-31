using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public class MaterialOutStore : StoreOperateBillBase
    {
        public MaterialOutStore()
        {
        }
        [DataMember]
        public OutStoreEnum OutStoreEnum { get; set; }   // 出库类型
        [DataMember]
        public int FromStoreID { get; set; }
        [DataMember]
        public int ToStoreID { get; set; }
        [DataMember]
        public int ToOtherHospitalID { get; set; }
        [DataMember]
        public int ToSupplierID { get; set; }        // 供货商退货 
        [DataMember]
        public List<MaterialOutStoreDetail> MaterialOutStoreDetails { get; set; }
    }
}
