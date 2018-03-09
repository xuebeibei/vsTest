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
    public class SickRoom : MyTableBase
    {
        public SickRoom()
        {
        }

        public List<CommContracts.SickRoom> GetAllSickRoom(string strName = "")
        {
            return client.GetAllSickRoom(strName);
        }

        public bool UpdateSickRoom(CommContracts.SickRoom sickRoom)
        {
            return client.UpdateSickRoom(sickRoom);
        }

        public bool SaveSickRoom(CommContracts.SickRoom sickRoom)
        {
            return client.SaveSickRoom(sickRoom);
        }

        public bool DeleteSickRoom(int sickRoomID)
        {
            return client.DeleteSickRoom(sickRoomID);
        }
    }
}
