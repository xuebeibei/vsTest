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
    public class Recipe
    {
        private ILoginService client;

        public CommContracts.Recipe MyRecipe { get; set; }

        public Recipe()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));

            MyRecipe = new CommContracts.Recipe();
        }

        public bool SaveRecipe()
        {
            return client.SaveRecipe(MyRecipe); 
        }

        public List<CommContracts.Recipe> getAllXiCheng(int RegistrationID)
        {
            return client.getAllXiCheng(RegistrationID);
        }

        public List<CommContracts.Recipe> getAllZhong(int RegistrationID)
        {
            return client.getAllZhong(RegistrationID);
        }
    }
}
