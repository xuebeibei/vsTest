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
    public class PrePay : MyTableBase
    {
        public PrePay()
        {
        }

        public CommContracts.PatientCardPrePay GetPrePay(int Id)
        {
            return client.GetPrePay(Id);
        }

        public bool SavePrePay(CommContracts.PatientCardPrePay prePay)
        {
            return client.SavePrePay(prePay);
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
