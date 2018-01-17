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
    public class TherapyItem
    {
        private ILoginService client;

        public TherapyItem()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.TherapyItem> GetAllTherapyItem(string strName = "")
        {
            return client.GetAllTherapyItem(strName);
        }

        public bool UpdateTherapyItem(CommContracts.TherapyItem TherapyItem)
        {
            return client.UpdateTherapyItem(TherapyItem);
        }

        public bool SaveTherapyItem(CommContracts.TherapyItem TherapyItem)
        {
            return client.SaveTherapyItem(TherapyItem);
        }

        public bool DeleteTherapyItem(int TherapyItemID)
        {
            return client.DeleteTherapyItem(TherapyItemID);
        }
    }
}
