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
    public class InHospitalApply : MyTableBase
    {
        public InHospitalApply()
        {
        }

        public List<CommContracts.InHospitalApply> GetAllInHospitalApply(CommContracts.InHospitalApplyEnum inHospitalApplyEnum, string strName = "")
        {
            return client.GetAllInHospitalApply(inHospitalApplyEnum, strName);
        }

        public bool UpdateInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            return client.UpdateInHospitalApply(InHospitalApply);
        }

        public bool SaveInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            return client.SaveInHospitalApply(InHospitalApply);
        }

        public bool DeleteInHospitalApply(int InHospitalApplyID)
        {
            return client.DeleteInHospitalApply(InHospitalApplyID);
        }
    }
}
