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

        public List<CommContracts.Material> GetAllMaterialItems(string strName)
        {
            return client.GetAllMaterialItems(strName);
        }

        public List<CommContracts.Material> GetAllMaterial(string strName = "")
        {
            return client.GetAllMaterial(strName);
        }

        public bool UpdateMaterial(CommContracts.Material Material)
        {
            return client.UpdateMaterial(Material);
        }

        public bool SaveMaterial(CommContracts.Material material)
        {
            return client.SaveMaterial(material);
        }

        public bool DeleteMaterial(int MaterialID)
        {
            return client.DeleteMaterial(MaterialID);
        }
    }
}
