using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class WorkPlanToSignalSource
    {
        [DataMember]
        public WorkPlan WorkPlan { get; set; }

        [DataMember]
        public SignalType SignalType { get; set; }
    }
}
