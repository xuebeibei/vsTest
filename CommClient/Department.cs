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
    public class Department
    {
        private ILoginService client;

        public Department()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public int getAllDepartmentNum()
        {
            return client.getAllDepartmentNum();
        }
        
        public List<CommContracts.Department> getALLDepartment(CommContracts.DepartmentEnum departmentEnum)
        {
            return client.getALLDepartment(departmentEnum);
        }

        public List<CommContracts.Department> getALLDepartment(string strName)
        {
            return client.getALLDepartmentByName(strName);
        }


        public bool SaveDepartment(CommContracts.Department department)
        {
            return client.SaveDepartment(department);
        }

        public bool UpdateDepartment(CommContracts.Department department)
        {
            return client.UpdateDepartment(department);
        }

        public bool DeleteDepartment(int departmentID)
        {
            return client.DeleteDepartment(departmentID);
        }
    }
}
