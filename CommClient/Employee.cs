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
    public class Employee
    {
        private ILoginService client;
        public Employee()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.Employee> getAllDoctor(int DepartmentID = 0)
        {
            return client.getAllDoctor(DepartmentID);
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
    }
}
