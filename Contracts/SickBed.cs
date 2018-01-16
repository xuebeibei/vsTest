using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class SickBed
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public int SickRoomID { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public SickRoom SickRoom { get; set; }

    }
}
