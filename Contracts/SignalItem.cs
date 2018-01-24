using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum SignalTimeEnum
    {
        上午,
        下午,
        晚上
    }

    [DataContract]
    public class SignalItem
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public SignalTimeEnum SignalTimeEnum { get; set; }
        [DataMember]
        public int MaxNum { get; set; }
        [DataMember]
        public decimal SellPrice { get; set; }

        public override string ToString()
        {
            return Name +" "+ SignalTimeEnum +" "+ MaxNum;
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
    }
}
