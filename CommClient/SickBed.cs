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
    public class SickBed : MyTableBase
    {
        public SickBed()
        {
        }

        public List<CommContracts.SickBed> GetAllSickBed(string strName = "")
        {
            return client.GetAllSickBed(strName);
        }

        public bool UpdateSickBed(CommContracts.SickBed sickBed)
        {
            return client.UpdateSickBed(sickBed);
        }

        public bool SaveSickBed(CommContracts.SickBed sickBed)
        {
            return client.SaveSickBed(sickBed);
        }

        public bool DeleteSickBed(int sickBedID)
        {
            return client.DeleteSickBed(sickBedID);
        }
    }
}
