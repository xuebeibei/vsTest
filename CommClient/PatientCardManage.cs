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
    public class PatientCardManage : MyTableBase
    {
        public PatientCardManage()
        {
        }

        public List<CommContracts.PatientCardManage> GetAllPatientCardManage(string strName = "")
        {
            return client.GetAllPatientCardManage(strName);
        }

        public bool UpdatePatientCardManage(CommContracts.PatientCardManage PatientCardManage)
        {
            return client.UpdatePatientCardManage(PatientCardManage);
        }

        public bool SavePatientCardManage(CommContracts.PatientCardManage PatientCardManage, ref string ErrorMsg)
        {
            return client.SavePatientCardManage(PatientCardManage, ref ErrorMsg);
        }

        public bool DeletePatientCardManage(int PatientCardManageID)
        {
            return client.DeletePatientCardManage(PatientCardManageID);
        }
    }
}
