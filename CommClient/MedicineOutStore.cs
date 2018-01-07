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
    public class MedicineOutStore
    {
        private ILoginService client;

        public MedicineOutStore()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore)
        {
            return client.SaveMedicineOutStock(medicineOutStore);
        }

        public bool RecheckMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore)
        {
            return client.RecheckMedicineOutStock(medicineOutStore);
        }

        public List<CommContracts.MedicineOutStore> getAllMedicineOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string OutStoreNo = "")
        {
            return client.getAllMedicineOutStore(StoreID, outStoreEnum, StartInStoreTime, EndInStoreTime, OutStoreNo);
        }
    }
}
