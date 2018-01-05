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
    public class MedicineInStore
    {
        private ILoginService client;

        public MedicineInStore()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            return client.SaveMedicineInStock(medicineInStore);
        }

        public List<CommContracts.MedicineInStore> getAllMedicineInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            return client.getAllMedicineInStore(StoreID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }
    }
}
