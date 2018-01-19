﻿using System;
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
    public class MedicineInStore
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
        public int ID { get; set; }                  // ID
        [DataMember]
        public string NO { get; set; }               // 单号 
        [DataMember]
        public decimal SumOfMoney { get; set; }      // 总金额，成本价
        [DataMember]
        public DateTime? OperateTime { get; set; }    // 操作时间
        [DataMember]
        public InStoreEnum InStoreEnum { get; set; }
        [DataMember]
        public int FromSupplierID { get; set; }      // 供应商
        [DataMember]
        public int ToStoreID { get; set; }           // 入库库房
        [DataMember]
        public string Remarks { get; set; }          // 备注
        [DataMember]
        public int OperateUserID { get; set; }       // 操作用户
        [DataMember]
        public ReCheckStatusEnum ReCheckStatusEnum { get; set; }      // 审核状态
        [DataMember]
        public int ReCheckUserID { get; set; }       // 复检用户
        [DataMember]
        public Supplier FromSupplier { get; set; }
        [DataMember]
        public User OperateUser { get; set; }
        [DataMember]
        public List<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
    }
}
