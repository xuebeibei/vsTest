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
    public class Job : MyTableBase
    {

        public Job()
        {
        }

        public List<CommContracts.Job> GetAllJob(string strName = "")
        {
            return client.GetAllJob(strName);
        }

        public List<CommContracts.Job> GetAllTypeJob(CommContracts.JobTypeEnum typeEnum)
        {
            return client.GetAllTypeJob(typeEnum);
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
