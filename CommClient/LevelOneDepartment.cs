using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class LevelOneDepartment : MyTableBase
    {
        public LevelOneDepartment()
        {
        }

        public List<CommContracts.LevelOneDepartment> GetAllLevelOneDepartment(string strName = "")
        {
            return client.GetAllLevelOneDepartment(strName);
        }

        public bool UpdateLevelOneDepartment(CommContracts.LevelOneDepartment LevelOneDepartment)
        {
            return client.UpdateLevelOneDepartment(LevelOneDepartment);
        }

        public bool SaveLevelOneDepartment(CommContracts.LevelOneDepartment LevelOneDepartment)
        {
            return client.SaveLevelOneDepartment(LevelOneDepartment);
        }

        public bool DeleteLevelOneDepartment(int LevelOneDepartmentID)
        {
            return client.DeleteLevelOneDepartment(LevelOneDepartmentID);
        }
    }
}
