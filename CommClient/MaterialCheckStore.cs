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
    public class MaterialCheckStore : MyTableBase
    {
        public MaterialCheckStore()
        {
        }

        public bool SaveMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            return client.SaveMaterialCheckStock(MaterialCheckStore);
        }

        public bool RecheckMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            return client.RecheckMaterialCheckStock(MaterialCheckStore);
        }

        public List<CommContracts.MaterialCheckStore> getAllMaterialCheckStore(int StoreID,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            return client.getAllMaterialCheckStore(StoreID, StartInStoreTime, EndInStoreTime, InStoreNo);
        }
    }
}
