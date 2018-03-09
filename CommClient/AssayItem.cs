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
    public class AssayItem : MyTableBase
    {
        public AssayItem()
        {
        }

        public List<CommContracts.AssayItem> GetAllAssayItem(string strName = "")
        {
            return client.GetAllAssayItem(strName);
        }

        public bool UpdateAssayItem(CommContracts.AssayItem assayItem)
        {
            return client.UpdateAssayItem(assayItem);
        }

        public bool SaveAssayItem(CommContracts.AssayItem assayItem)
        {
            return client.SaveAssayItem(assayItem);
        }

        public bool DeleteAssayItem(int AssayItemID)
        {
            return client.DeleteAssayItem(AssayItemID);
        }
    }
}
