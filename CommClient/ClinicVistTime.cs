using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class ClinicVistTime : MyTableBase
    {
        public ClinicVistTime()
        {
        }

        public List<CommContracts.ClinicVistTime> GetAllClinicVistTime(string strName = "")
        {
            return client.GetAllClinicVistTime(strName);
        }

        public bool UpdateClinicVistTime(CommContracts.ClinicVistTime ClinicVistTime)
        {
            return client.UpdateClinicVistTime(ClinicVistTime);
        }

        public bool SaveClinicVistTime(CommContracts.ClinicVistTime ClinicVistTime)
        {
            return client.SaveClinicVistTime(ClinicVistTime);
        }

        public bool DeleteClinicVistTime(int ClinicVistTimeID)
        {
            return client.DeleteClinicVistTime(ClinicVistTimeID);
        }
    }
}
