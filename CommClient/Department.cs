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
        //private CommContracts.Department MyDepartment;


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
        
        public List<CommContracts.Department> getALLDepartment()
        {
            return client.getALLDepartment();
        }

    }
}
