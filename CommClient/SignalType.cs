using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class SignalType : MyTableBase
    {
        public SignalType()
        {
        }

        public List<CommContracts.SignalType> GetAllSignalType(string strName = "")
        {
            return client.GetAllSignalType(strName);
        }

        public bool UpdateSignalType(CommContracts.SignalType SignalType)
        {
            return client.UpdateSignalType(SignalType);
        }

        public bool SaveSignalType(CommContracts.SignalType SignalType)
        {
            return client.SaveSignalType(SignalType);
        }

        public bool DeleteSignalType(int SignalTypeID)
        {
            return client.DeleteSignalType(SignalTypeID);
        }
    }
}
