using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class RecallHospital : MyTableBase
    {
        public List<CommContracts.RecallHospital> GetAllRecallHospitalList(int EmployeeID = 0, string strName = "")
        {
            return client.GetAllRecallHospitalList(EmployeeID, strName);
        }

        public bool SaveRecallHospital(CommContracts.RecallHospital recallHospital)
        {
            return client.SaveRecallHospital(recallHospital);
        }

        public bool UpdateRecallHospital(CommContracts.RecallHospital recallHospital)
        {
            return client.UpdateRecallHospital(recallHospital);
        }
    }
}
