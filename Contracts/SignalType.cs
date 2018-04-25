using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{

    [DataContract]
    public class SignalType
    {
        //[DataMember]
        //public int ID { get; set; }
        //[DataMember]
        //public int WorkTypeID { get; set; }
        ///// <summary>
        ///// 医生职称
        ///// </summary>
        //[DataMember]
        //public int MaxNum { get; set; }

        //[DataMember]
        //public decimal SellPrice { get; set; }

        ///// <summary>
        ///// 对应值班类别
        ///// </summary>
        //[DataMember]
        //public WorkType WorkType { get; set; }

        /// <summary>
        /// 号别构造函数
        /// </summary>
        public SignalType()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 值班类别ID
        /// </summary>
        [DataMember]
        public int WorkTypeID { get; set; }


        /// <summary>
        /// 医生职称
        /// </summary>
        [DataMember]
        public int JobID { get; set; }



        /// <summary>
        /// 门诊医师服务费
        /// </summary>
        [DataMember]
        public decimal DoctorClinicFee { get; set; }


        /// <summary>
        /// 对应值班类别
        /// </summary>
        [DataMember]
        public virtual WorkType WorkType { get; set; }

        /// <summary>
        /// 对应职位类别
        /// </summary>
        [DataMember]
        public virtual Job Job { get; set; }

        public override string ToString()
        {
            return WorkType.Name;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as SignalType;
            if (temp == null)
                return false;
            if (temp.ID != this.ID)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
