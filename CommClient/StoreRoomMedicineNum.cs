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

        public bool RecheckMedicineOutStore(CommContracts.MedicineOutStore medicineOutStore)
        {
            return client.RecheckMedicineOutStore(medicineOutStore);
        }

        public List<CommContracts.StoreRoomMedicineNum> getAllMedicineItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            return client.getAllMedicineItemNum(StoreID, ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
        }

        // 得到当前药品的合理库存
        public List<CommContracts.StoreRoomMedicineNum> GetStoreFromMedicine(int nMedicineID, int nNum)
        {
            return client.GetStoreFromMedicine(nMedicineID, nNum);
        }
    }
}
