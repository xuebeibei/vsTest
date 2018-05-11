using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class HospitalMsg : MyTableBase
    {
        public HospitalMsg()
        {
        }

        public List<CommContracts.HospitalMsg> GetAllHospitalMsg(string strName = "")
        {
            return client.GetAllHospitalMsg(strName);
        }

        public bool UpdateHospitalMsg(CommContracts.HospitalMsg HospitalMsg)
        {
            return client.UpdateHospitalMsg(HospitalMsg);
        }

        public bool SaveHospitalMsg(CommContracts.HospitalMsg HospitalMsg)
        {
            return client.SaveHospitalMsg(HospitalMsg);
        }

        public bool DeleteHospitalMsg(int HospitalMsgID)
        {
            return client.DeleteHospitalMsg(HospitalMsgID);
        }
    }
}
