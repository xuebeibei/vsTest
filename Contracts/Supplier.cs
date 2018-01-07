using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Supplier
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
        //[DataMember]
        //public List<MedicineInStore> MedicineInStores { get; set; }
        //[DataMember]
        //public List<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var aaa = obj as Supplier;
            if (aaa == null)
                return false;
            if (this.ID == aaa.ID)
                return true;
            return false;
        }
    }
}
