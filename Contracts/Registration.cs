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
        public Registration()
        {
            GetPatient = new Patient();
            GetSignalSource = new SignalSource();
            GetLoginUser = new LoginUser();
            GetDateTime = DateTime.Now;
            Fee = 0.0;
        }
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
