using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineCheckStore : StoreOperateBillBase
    {
        public MedicineCheckStore()
        {
            this.NO = "002";
            this.OperateTime = DateTime.Now;
            this.ReCheckStatusEnum = ReCheckStatusEnum.待审核;
        }
        [DataMember]
        public int CheckStoreID { get; set; }        // 盘存库房
        [DataMember]
        public List<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
    }
}
