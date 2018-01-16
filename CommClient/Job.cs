using CommContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class Job
    {
        private ILoginService client;

        public Job()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.Job> GetAllJob(string strName = "")
        {
            return client.GetAllJob(strName);
        }

        public bool UpdateJob(CommContracts.Job job)
        {
            return client.UpdateJob(job);
        }

        public bool SaveJob(CommContracts.Job job)
        {
            return client.SaveJob(job);
        }

        public bool DeleteJob(int jobID)
        {
            return client.DeleteJob(jobID);
        }
    }
}
