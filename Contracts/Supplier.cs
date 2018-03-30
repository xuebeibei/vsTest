using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
#pragma warning disable CS0659 // “Supplier”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    public class Supplier
#pragma warning restore CS0659 // “Supplier”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    {
        public Supplier()
        {
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbr1 { get; set; }
        [DataMember]
        public string Abbr2 { get; set; }
        [DataMember]
        public string Abbr3 { get; set; }
        [DataMember]
        public string Address { get; set; }  // 供应商地址
        [DataMember]
        public string Contents { get; set; } // 供应商联系人
        [DataMember]
        public string Tel { get; set; }      // 供应商联系方式
        
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var aaa = obj as Supplier;
            if (aaa == null)
                return false;
            if (this.ID == aaa.ID)
                return true;
            return false;
        }
    }
}
