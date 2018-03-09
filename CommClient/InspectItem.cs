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
    public class InspectItem : MyTableBase
    {

        public InspectItem()
        {
        }

        public List<CommContracts.InspectItem> GetAllInspectItem(string strName = "")
        {
            return client.GetAllInspectItem(strName);
        }

        public bool UpdateInspectItem(CommContracts.InspectItem InspectItem)
        {
            return client.UpdateInspectItem(InspectItem);
        }

        public bool SaveInspectItem(CommContracts.InspectItem material)
        {
            return client.SaveInspectItem(material);
        }

        public bool DeleteInspectItem(int InspectItemID)
        {
            return client.DeleteInspectItem(InspectItemID);
        }
    }
}
