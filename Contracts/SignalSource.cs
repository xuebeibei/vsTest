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
        [DataMember]
        public int ID { get; set; }                  // 号源ID
        [DataMember]
        public decimal Price { get; set; }           // 号源单价
        [DataMember]
        public DateTime? VistDate { get; set; }       // 看诊日期
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

        /// <summary>
        ///  时段ID
        /// </summary>
        [DataMember]
        public int ClinicVistTimeID { get; set; }

        /// <summary>
        /// 值班时段
        /// </summary>
        [DataMember]
        public ClinicVistTime ClinicVistTime { get; set; }

    }
}
