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
    public class MaterialItem
    {
        private ILoginService client;

        public MaterialItem()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.MaterialItem> GetAllMaterialItem(string strName = "")
        {
            return client.GetAllMaterialItem(strName);
        }

        public bool UpdateMaterial(CommContracts.MaterialItem Material)
        {
            return client.UpdateMaterialItem(Material);
        }

        public bool SaveMaterial(CommContracts.MaterialItem material)
        {
            return client.SaveMaterialItem(material);
        }

        public bool DeleteMaterial(int MaterialID)
        {
            return client.DeleteMaterialItem(MaterialID);
        }
    }
}
