using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialCheckStore : StoreOperateBillBase
    {
        public MaterialCheckStore()
        {
        }
        [DataMember]
        public int CheckStoreID { get; set; }        // 盘存库房
        [DataMember]

        public List<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }
    }
}
