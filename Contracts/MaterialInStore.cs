using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialInStore : StoreOperateBillBase
    {
        [DataMember]
        public InStoreEnum InStoreEnum { get; set; }
        [DataMember]
        public int FromSupplierID { get; set; }      // 供应商
        [DataMember]
        public int ToStoreID { get; set; }           // 入库库房
        [DataMember]
        public Supplier FromSupplier { get; set; }
        [DataMember]
        public List<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
    }
}
