using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class Frequency : MyTableBase
    {
        public Frequency()
        {
        }

        public List<CommContracts.Frequency> GetAllFrequency(string strName = "")
        {
            return client.GetAllFrequency(strName);
        }

        public bool UpdateFrequency(CommContracts.Frequency Frequency)
        {
            return client.UpdateFrequency(Frequency);
        }

        public bool SaveFrequency(CommContracts.Frequency Frequency)
        {
            return client.SaveFrequency(Frequency);
        }

        public bool DeleteFrequency(int FrequencyID)
        {
            return client.DeleteFrequency(FrequencyID);
        }
    }
}
