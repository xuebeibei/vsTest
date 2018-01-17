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
    public class AssayItem
    {
        private ILoginService client;

        public AssayItem()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.AssayItem> GetAllAssayItem(string strName = "")
        {
            return client.GetAllAssayItem(strName);
        }

        public bool UpdateAssayItem(CommContracts.AssayItem AssayItem)
        {
            return client.UpdateAssayItem(AssayItem);
        }

        public bool SaveAssayItem(CommContracts.AssayItem material)
        {
            return client.SaveAssayItem(material);
        }

        public bool DeleteAssayItem(int AssayItemID)
        {
            return client.DeleteAssayItem(AssayItemID);
        }
    }
}
