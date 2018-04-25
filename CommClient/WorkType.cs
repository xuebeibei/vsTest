using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class WorkType : MyTableBase
    {
        public WorkType()
        {
        }

        public List<CommContracts.WorkType> GetAllWorkType(string strName = "")
        {
            return client.GetAllWorkType(strName);
        }

        public bool UpdateWorkType(CommContracts.WorkType WorkType)
        {
            return client.UpdateWorkType(WorkType);
        }

        public bool SaveWorkType(CommContracts.WorkType WorkType)
        {
            return client.SaveWorkType(WorkType);
        }

        public bool DeleteWorkType(int WorkTypeID)
        {
            return client.DeleteWorkType(WorkTypeID);
        }
    }
}
