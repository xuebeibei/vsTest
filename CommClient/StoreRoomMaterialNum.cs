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
    public class StoreRoomMaterialNum
    {
        private ILoginService client;

        public StoreRoomMaterialNum()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool ReCheckMaterialInStore(CommContracts.MaterialInStore MaterialInStore)
        {
            return client.ReCheckMaterialInStore(MaterialInStore);
        }

        public bool RecheckMaterialOutStore(CommContracts.MaterialOutStore MaterialOutStore)
        {
            return client.RecheckMaterialOutStore(MaterialOutStore);
        }
        public bool ReCheckMaterialCheckStore(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            return client.ReCheckMaterialCheckStore(MaterialCheckStore);
        }

        public List<CommContracts.StoreRoomMaterialNum> getAllMaterialItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            return client.getAllMaterialItemNum(StoreID, ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
        }

        // 得到当前物资的合理库存
        public List<CommContracts.StoreRoomMaterialNum> GetStoreFromMaterial(int nMaterialID, int nNum)
        {
            return client.GetStoreFromMaterial(nMaterialID, nNum);
        }

        // 根据收费单更新物资库存
        public bool SubdMaterialStoreNum(CommContracts.MaterialCharge materialCharge)
        {
            return client.SubdMaterialStoreNum(materialCharge);
        }
    }
}
