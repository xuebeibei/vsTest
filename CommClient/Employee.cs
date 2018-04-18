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
    public class Employee : MyTableBase
    {
        public Employee()
        {
        }

        public List<CommContracts.Employee> GetAllEmployee(string strName = "")
        {
            return client.GetAllEmployee(strName);
        }

        public bool UpdateEmployee(CommContracts.Employee employee)
        {
            return client.UpdateEmployee(employee);
        }

        public bool SaveEmployee(CommContracts.Employee employee)
        {
            return client.SaveEmployee(employee);
        }

        public bool DeleteEmployee(int employeeID)
        {
            return client.DeleteEmployee(employeeID);
        }

        public CommContracts.Department GetCurrentDepartment(int employeeID)
        {
            return client.GetCurrentDepartment(employeeID);
        }

        public CommContracts.Job GetCurrentJob(int employeeID)
        {
            return client.GetCurrentJob(employeeID);
        }
    }
}
