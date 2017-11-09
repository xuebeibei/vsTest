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
    public class SignalSource
    {
        private ILoginService client;

        public SignalSource()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.SignalSource> getALLSignalSource(int DepartmentID, DateTime dateTime, int timeInterval)
        {
            return client.getALLSignalSource(DepartmentID, dateTime, timeInterval);
        }

        public List<DateTime> getAllSignalDate(int DepartmentID)
        {
            return client.getAllSignalDate(DepartmentID);
        }

        public List<int> getAllSignalTimeIntival(int DepartmentID)
        {
            return client.getAllSignalTimeIntival(DepartmentID);
        }

        public string getSignalSourceTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
            return client.getSignalSourceTip(DepartmentID, dateTime, TimeIntival);
        }

    }
}
