using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class DiagnoseItem : MyTableBase
    {
        public DiagnoseItem()
        {
        }

        public List<CommContracts.DiagnoseItem> GetAllDiagnoseItem(string strName = "")
        {
            return client.GetAllDiagnoseItem(strName);
        }

        public bool UpdateDiagnoseItem(CommContracts.DiagnoseItem DiagnoseItem)
        {
            return client.UpdateDiagnoseItem(DiagnoseItem);
        }

        public bool SaveDiagnoseItem(CommContracts.DiagnoseItem DiagnoseItem)
        {
            return client.SaveDiagnoseItem(DiagnoseItem);
        }

        public bool DeleteDiagnoseItem(int DiagnoseItemID)
        {
            return client.DeleteDiagnoseItem(DiagnoseItemID);
        }
    }
}
