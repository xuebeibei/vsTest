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
    public class RecipeChargeBill
    {
        private ILoginService client;

        public RecipeChargeBill()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveRecipeChargeBill(CommContracts.RecipeChargeBill recipeChargeBill)
        {
            return client.SaveRecipeChargeBill(recipeChargeBill);
        }

        public List<CommContracts.RecipeChargeBill> GetAllChargeFromRecipe(int RecipeID)
        {
            return client.GetAllChargeFromRecipe(RecipeID);
        }
    }
}
