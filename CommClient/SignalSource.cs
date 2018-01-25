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

        public List<CommContracts.SignalSource> GetAllSignalSource()
        {
            return client.GetAllSignalSource();
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

        public bool UpdateSignalSource(int nSignalSourceID)
        {
            return client.UpdateSignalSource(nSignalSourceID);
        }

        public bool SaveSignalSourceList(List<CommContracts.SignalSource> list)
        {
            return client.SaveSignalSourceList(list);
        }

        public List<CommContracts.SignalSource> GetSignalSourceList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            return client.GetSignalSourceList(DepartmentID, EmployeeID, startDate, endDate);
        }
    }
}
