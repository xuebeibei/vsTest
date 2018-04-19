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

        public CommContracts.Employee Authenticate(string username, string password, string MachineCode)
        {
            Log log = Log.getInstance();
            CommContracts.Employee user = new CommContracts.Employee();
            try
            {
                user = client.UserAuthenticate(username, password, MachineCode);
            }
            catch (Exception ex)
            {
                log.write("end client.UserAuthenticate(login) Error:" + ex.Message + " ; " + ex.ToString());
                return null;
            }
            return user;
        }

        public bool Logout(CommContracts.Employee user, string MachineCode)
        {
            return client.UserLogout(user);
        }

        public List<CommContracts.Employee> GetAllEmployee(string strName = "")
        {
            return client.GetAllEmployee(strName);
        }

        public bool UpdateEmployee(CommContracts.Employee employee)
        {
            return client.UpdateEmployee(employee);
        }

        public bool SaveEmployee(CommContracts.Employee employee, ref int employeeID)
        {
            return client.SaveEmployee(employee, ref employeeID);
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
