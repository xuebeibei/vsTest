using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Registration
    {
        [DataMember]
        public Patient GetPatient { get; set; }

        [DataMember]
        public SignalSource GetSignalSource { get; set; }

        [DataMember]
        public LoginUser GetLoginUser { get; set; }

        [DataMember]
        public DateTime GetDateTime { get; set; }

        [DataMember]
        public double Fee { get; set; }

    }
}
