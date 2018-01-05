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
    public class StoreRoomMedicineNum
    {
        private ILoginService client;

        public StoreRoomMedicineNum()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool ReCheckMedicineInStore(CommContracts.MedicineInStore medicineInStore)
        {
            return client.ReCheckMedicineInStore(medicineInStore);
        }

    }
}
