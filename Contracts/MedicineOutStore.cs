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
    public class MedicineOutStore
    {
        public MedicineOutStore()
        {
            this.NO = "002";
            this.OperateTime = DateTime.Now;
            this.ReCheckStatusEnum = ReCheckStatusEnum.待审核;
            this.OutStoreEnum = OutStoreEnum.科室出库;
        }

        [DataMember]
        public int ID { get; set; }                      // ID
        [DataMember]
        public string NO { get; set; }                   // 单号
        [DataMember]
        public decimal SumOfMoney { get; set; }          // 总金额，成本价
        [DataMember]
        public DateTime OperateTime { get; set; }        // 操作时间
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
        public string Remarks { get; set; }          // 备注
        [DataMember]
        public int OperateUserID { get; set; }       // 操作用户
        [DataMember]
        public int ReCheckUserID { get; set; }       // 复检用户
        [DataMember]
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }
        [DataMember]
        public List<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }

    }
}
