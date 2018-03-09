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
    public class SignalItem : MyTableBase
    {
        public SignalItem()
        {
        }

        public List<CommContracts.SignalItem> GetAllSignalItem(string strName = "")
        {
            return client.GetAllSignalItem(strName);
        }

        public bool UpdateSignalItem(CommContracts.SignalItem signalItem)
        {
            return client.UpdateSignalItem(signalItem);
        }

        public bool SaveSignalItem(CommContracts.SignalItem signalItem)
        {
            return client.SaveSignalItem(signalItem);
        }

        public bool DeleteSignalItem(int signalItemID)
        {
            return client.DeleteSignalItem(signalItemID);
        }
    }
}
