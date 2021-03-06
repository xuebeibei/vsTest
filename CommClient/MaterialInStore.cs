﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class MaterialInStore : MyTableBase
    {
        public MaterialInStore()
        {
        }

        public bool SaveMaterialInStock(CommContracts.MaterialInStore MaterialInStore)
        {
            return client.SaveMaterialInStock(MaterialInStore);
        }

        public bool RecheckMaterialInStock(CommContracts.MaterialInStore MaterialInStore)
        {
            return client.RecheckMaterialInStock(MaterialInStore);
        }

        public List<CommContracts.MaterialInStore> getAllMaterialInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            return client.getAllMaterialInStore(StoreID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }
    }
}
