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
    public class DoctorAdviceBase : MyTableBase
    {
        public DoctorAdviceBase()
        {
        }

        public bool UpdateChargeStatus(int DoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            return client.UpdateChargeStatus(DoctorAdviceID, chargeStatusEnum);
        }

        public bool UpdateExecuteEnum(int DoctorAdviceID, CommContracts.ExecuteEnum executeEnum)
        {
            return client.UpdateExecuteEnum(DoctorAdviceID, executeEnum);
        }
    }
}
