using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class ClinicDoctorAdvice : MyTableBase
    {
        public ClinicDoctorAdvice()
        {
        }

        public List<CommContracts.ClinicDoctorAdvice> GetAllClinicDoctorAdvice(string strName = "")
        {
            return client.GetAllClinicDoctorAdvice(strName);
        }

        public bool UpdateClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice)
        {
            return client.UpdateClinicDoctorAdvice(ClinicDoctorAdvice);
        }

        public bool SaveClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice)
        {
            return client.SaveClinicDoctorAdvice(ClinicDoctorAdvice);
        }

        public bool DeleteClinicDoctorAdvice(int ClinicDoctorAdviceID)
        {
            return client.DeleteClinicDoctorAdvice(ClinicDoctorAdviceID);
        }
    }
}
