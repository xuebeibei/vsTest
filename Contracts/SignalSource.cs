using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class SignalSource
    {
        //[DataMember]
        //public int ID { get; set; }              // 号源ID
        //[DataMember]
        //public decimal Price { get; set; }        // 号源单价
        //[DataMember]
        //public DateTime? VistTime { get; set; }    // 看诊日期
        //[DataMember]
        //public int TimeIntival { get; set; }      // 看诊时段ID
        //[DataMember]
        //public Department GetDepartment { get; set; } // 科室
        //[DataMember]
        //public int SignalType { get; set; }       // 号别
        //[DataMember]
        //public int MaxNum { get; set; }           // 最大号源
        //[DataMember]
        //public int AddMaxNum { get; set; }        // 临时加号号源
        //[DataMember]
        //public int HasUsedNum { get; set; }       // 已挂号源
        //[DataMember]
        //public int Specialist { get; set; }       // 专家ID
        //[DataMember]
        //public string Explain { get; set; }       // 说明
        [DataMember]
        public int ID { get; set; }                  // 号源ID
        [DataMember]
        public decimal Price { get; set; }           // 号源单价
        [DataMember]
        public DateTime? VistTime { get; set; }       // 看诊日期
        [DataMember]
        public int MaxNum { get; set; }               // 最大号源
        [DataMember]
        public int SignalItemID { get; set; }         // 号源种类
        [DataMember]
        public int EmployeeID { get; set; }           // 值班医生
        [DataMember]
        public int DepartmentID { get; set; }         // 所属科室
        [DataMember]
        public SignalItem SignalItem { get; set; }
    }
}
