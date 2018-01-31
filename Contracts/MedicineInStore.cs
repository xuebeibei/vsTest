using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum InStoreEnum
    {
        采购入库,
        赠与入库,
        其他入库
    }

    public enum ReCheckStatusEnum
    {
        待审核,
        已审核
    }

    [DataContract]
    public class MedicineInStore : StoreOperateBillBase
    {
        public MedicineInStore()
        {
            this.NO = "002";
            this.OperateTime = DateTime.Now;
            this.FromSupplier = new Supplier();
            this.InStoreEnum = InStoreEnum.采购入库;
            this.ReCheckStatusEnum = ReCheckStatusEnum.待审核;
        }

        [DataMember]
        public InStoreEnum InStoreEnum { get; set; }
        [DataMember]
        public int FromSupplierID { get; set; }      // 供应商
        [DataMember]
        public int ToStoreID { get; set; }           // 入库库房
        [DataMember]
        public Supplier FromSupplier { get; set; }
        [DataMember]
        public List<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
    }
}
