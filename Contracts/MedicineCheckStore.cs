using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MedicineCheckStore
    {
        public MedicineCheckStore()
        {
            this.NO = "002";
            this.OperateTime = DateTime.Now;
            this.ReCheckStatusEnum = ReCheckStatusEnum.待审核;
        }
        [DataMember]
        public int ID { get; set; }                  // ID
        [DataMember]
        public string NO { get; set; }               // 单号
        [DataMember]
        public decimal SumOfMoney { get; set; }      // 总损益，成本价
        [DataMember]
        public DateTime? OperateTime { get; set; }    // 操作时间
        [DataMember]
        public int CheckStoreID { get; set; }        // 盘存库房
        [DataMember]
        public string Remarks { get; set; }          // 备注
        [DataMember]
        public int OperateUserID { get; set; }       // 操作用户
        [DataMember]
        public int ReCheckUserID { get; set; }       // 复检用户
        [DataMember]
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }
        [DataMember]
        public List<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
    }
}
