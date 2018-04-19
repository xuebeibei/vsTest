using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class EmployeeDepartmentHistory : MyTableBase
    {
        public List<CommContracts.EmployeeDepartmentHistory> GetAllEmployeeDepartmentHistory(int EmployeeID)
        {
            return client.GetAllEmployeeDepartmentHistory(EmployeeID);
        }

        public List<CommContracts.Employee> GetAllDepartmentEmployee(int DepartmentID)
        {
            return client.GetAllDepartmentEmployee(DepartmentID);
        }

        public List<CommContracts.Employee> GetAllDepartmentDoctor(int DepartmentID)
        {
            return client.GetAllDepartmentDoctor(DepartmentID);
        }

        public bool SaveEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory)
        {
            return client.SaveEmployeeDepartmentHistory(EmployeeDepartmentHistory);
        }

        public bool DeleteEmployeeDepartmentHistory(int EmployeeDepartmentHistoryID)
        {
            return client.DeleteEmployeeDepartmentHistory(EmployeeDepartmentHistoryID);
        }

        public bool UpdateEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory)
        {
            return client.UpdateEmployeeDepartmentHistory(EmployeeDepartmentHistory);
        }
    }
}
