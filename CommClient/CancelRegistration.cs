using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class CancelRegistration :RegistrationBase
    {
        public bool SaveCancelRegistration(CommContracts.CancelRegistration cancelRegistration)
        {
            return client.SaveCancelRegistration(cancelRegistration);
        }
    }
}
