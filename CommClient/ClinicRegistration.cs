using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class ClinicRegistration : MyTableBase
    {
        public ClinicRegistration()
        {
        }

        public List<CommContracts.ClinicRegistration> GetAllClinicRegistration(string strName = "")
        {
            return client.GetAllClinicRegistration(strName);
        }

        public bool UpdateClinicRegistration(CommContracts.ClinicRegistration ClinicRegistration)
        {
            return client.UpdateClinicRegistration(ClinicRegistration);
        }

        public bool SaveClinicRegistration(CommContracts.ClinicRegistration ClinicRegistration)
        {
            return client.SaveClinicRegistration(ClinicRegistration);
        }

        public bool DeleteClinicRegistration(int ClinicRegistrationID)
        {
            return client.DeleteClinicRegistration(ClinicRegistrationID);
        }
    }
}
