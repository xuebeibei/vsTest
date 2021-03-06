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
    public class OtherServiceItem : MyTableBase
    {
        public OtherServiceItem()
        {
        }

        public List<CommContracts.OtherServiceItem> GetAllOtherServiceItem(string strName = "")
        {
            return client.GetAllOtherServiceItem(strName);
        }

        public bool UpdateOtherServiceItem(CommContracts.OtherServiceItem OtherServiceItem)
        {
            return client.UpdateOtherServiceItem(OtherServiceItem);
        }

        public bool SaveOtherServiceItem(CommContracts.OtherServiceItem material)
        {
            return client.SaveOtherServiceItem(material);
        }

        public bool DeleteOtherServiceItem(int OtherServiceItemID)
        {
            return client.DeleteOtherServiceItem(OtherServiceItemID);
        }
    }
}
