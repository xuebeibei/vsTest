using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{

    [DataContract]
    public class SignalItem
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 医生职称
        /// </summary>
        [DataMember]
        public string DoctorJob { get; set; }

        [DataMember]
        public decimal SellPrice { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as SignalItem;
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
