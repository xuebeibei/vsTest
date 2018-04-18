using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class EmployeeJobHistory : MyTableBase
    {
        public List<CommContracts.EmployeeJobHistory> GetAllEmployeeJobHistory(int EmployeeID)
        {
            return client.GetAllEmployeeJobHistory(EmployeeID);
        }

        public List<CommContracts.Employee> GetAllJobEmployee(int JobID)
        {
            return client.GetAllJobEmployee(JobID);
        }

        public bool SaveEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory)
        {
            return client.SaveEmployeeJobHistory(EmployeeJobHistory);
        }

        public bool DeleteEmployeeJobHistory(int EmployeeJobHistoryID)
        {
            return client.DeleteEmployeeJobHistory(EmployeeJobHistoryID);
        }

        public bool UpdateEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory)
        {
            return client.UpdateEmployeeJobHistory(EmployeeJobHistory);
        }
    }
}
