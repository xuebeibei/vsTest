using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum OutStoreEnum
    {
        科室出库,
        报损出库,
        分销出库,
        退货出库,
        其他出库
    }

    [DataContract]
    public class MedicineOutStore : StoreOperateBillBase
    {
        public MedicineOutStore()
        {
            this.NO = "002";
            this.OperateTime = DateTime.Now;
            this.ReCheckStatusEnum = ReCheckStatusEnum.待审核;
            this.OutStoreEnum = OutStoreEnum.科室出库;
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
        public List<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }

    }
}
