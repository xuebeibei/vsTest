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
    public class StoreRoom : MyTableBase
    {
        public StoreRoom()
        {
        }

        public List<CommContracts.StoreRoom> GetAllStoreRoom(string strName = "")
        {
            return client.GetAllStoreRoom(strName);
        }

        public bool UpdateStoreRoom(CommContracts.StoreRoom storeRoom)
        {
            return client.UpdateStoreRoom(storeRoom);
        }

        public bool SaveStoreRoom(CommContracts.StoreRoom storeRoom)
        {
            return client.SaveStoreRoom(storeRoom);
        }

        public bool DeleteStoreRoom(int storeRoomID)
        {
            return client.DeleteStoreRoom(storeRoomID);
        }
    }
}
