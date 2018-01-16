using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum LoginStatus { invalid, unknow, logout, login };
    [DataContract]
    public class User
    {   
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public LoginStatus Status { get; set; }
        [DataMember]
        public DateTime? LastLogin { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public virtual Employee Employee { get; set; }
    }
}
