using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class SignalTime : MyTableBase
    {
        public SignalTime()
        {
        }

        public List<CommContracts.SignalTime> GetAllClinicVistTime(string strName = "")
        {
            return client.GetAllClinicVistTime(strName);
        }

        public bool UpdateClinicVistTime(CommContracts.SignalTime ClinicVistTime)
        {
            return client.UpdateClinicVistTime(ClinicVistTime);
        }

        public bool SaveClinicVistTime(CommContracts.SignalTime ClinicVistTime)
        {
            return client.SaveClinicVistTime(ClinicVistTime);
        }

        public bool DeleteClinicVistTime(int ClinicVistTimeID)
        {
            return client.DeleteClinicVistTime(ClinicVistTimeID);
        }
    }
}
