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
    public class PatientCardPrePay : MyTableBase
    {
        public PatientCardPrePay()
        {
        }

        public CommContracts.PatientCardPrePay GetPrePay(int Id)
        {
            return client.GetPrePay(Id);
        }

        public bool SavePrePay(CommContracts.PatientCardPrePay prePay, ref int prePayID, ref string ErrorMsg)
        {
            return client.SavePrePay(prePay, ref prePayID, ref ErrorMsg);
        }

        public List<CommContracts.PatientCardPrePay> GetAllPrePay(int PatientID)
        {
            return client.GetAllPrePay(PatientID);
        }

        public bool DeletePrePay(int PrePayID)
        {
            return client.DeletePrePay(PrePayID);
        }
    }
}
