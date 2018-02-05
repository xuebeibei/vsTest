using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class LeaveHospital : MyTableBase
    {
        public List<CommContracts.LeaveHospital> GetAllLeaveHospitalList(int EmployeeID = 0, string strName = "")
        {
            return client.GetAllLeaveHospitalList(EmployeeID, strName);
        }

        public bool SaveLeaveHospital(CommContracts.LeaveHospital leaveHospital)
        {
            return client.SaveLeaveHospital(leaveHospital);
        }

        public bool UpdateLeaveHospital(CommContracts.LeaveHospital leaveHospital)
        {
            return client.UpdateLeaveHospital(leaveHospital);
        }
    }
}
