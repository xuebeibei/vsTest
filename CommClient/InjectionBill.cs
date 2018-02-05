using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class InjectionBill :  MyTableBase
    {
        public bool SaveInjectionBill(CommContracts.InjectionBill injectionBill)
        {
            return client.SaveInjectionBill(injectionBill);
        }

        public List<CommContracts.InjectionBill> GetAllInjectionBill(int nRegistrationID)
        {
            return client.GetAllInjectionBill(nRegistrationID);
        }

        public List<CommContracts.InjectionBill> GetAllInHospitalInjectionBill(int InHospitalID)
        {
            return client.GetAllInHospitalInjectionBill(InHospitalID);
        }
    }
}
