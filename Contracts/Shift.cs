using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    /// <summary>
    /// 班次
    /// </summary>
    [DataContract]
    public class Shift
    {
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
        /// 起始时间
        /// </summary>
        [DataMember]
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public string EndTime { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Shift;
            if (temp == null)
                return false;

            if (temp.ID == this.ID)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
