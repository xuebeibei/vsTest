using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MyTableBase
    {
        public MyTableBase()
        {
            CurrentTime = DateTime.Now;
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public DateTime CurrentTime { get; set; }
        [DataMember]
        public virtual User User { get; set; }
    }
}
