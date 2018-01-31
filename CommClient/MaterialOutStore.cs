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
    public class MaterialOutStore
    {
        private ILoginService client;

        public MaterialOutStore()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore)
        {
            return client.SaveMaterialOutStock(MaterialOutStore);
        }

        public bool RecheckMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore)
        {
            return client.RecheckMaterialOutStock(MaterialOutStore);
        }

        public List<CommContracts.MaterialOutStore> getAllMaterialOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string OutStoreNo = "")
        {
            return client.getAllMaterialOutStore(StoreID, outStoreEnum, StartInStoreTime, EndInStoreTime, OutStoreNo);
        }
    }
}
