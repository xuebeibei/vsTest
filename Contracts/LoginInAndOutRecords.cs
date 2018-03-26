using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class LoginInAndOutRecords : MyTableBase
    {        
        [DataMember]
        public string LoginMachineCode { get; set; }
        [DataMember]
        public bool LoginInOrLoginOut { get; set; }
    }
}
