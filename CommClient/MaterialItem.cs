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
    public class MaterialItem : MyTableBase
    {
        public MaterialItem()
        {
        }

        public List<CommContracts.MaterialItem> GetAllMaterialItem(string strName = "")
        {
            return client.GetAllMaterialItem(strName);
        }

        public bool UpdateMaterial(CommContracts.MaterialItem MaterialItem)
        {
            return client.UpdateMaterialItem(MaterialItem);
        }

        public bool SaveMaterial(CommContracts.MaterialItem MaterialItem)
        {
            return client.SaveMaterialItem(MaterialItem);
        }

        public bool DeleteMaterial(int MaterialItemID)
        {
            return client.DeleteMaterialItem(MaterialItemID);
        }
    }
}
