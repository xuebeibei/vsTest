using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class AdministrationRoute : MyTableBase
    {
        public AdministrationRoute()
        {
        }

        public List<CommContracts.AdministrationRoute> GetAllAdministrationRoute(string strName = "")
        {
            return client.GetAllAdministrationRoute(strName);
        }

        public bool UpdateAdministrationRoute(CommContracts.AdministrationRoute AdministrationRoute)
        {
            return client.UpdateAdministrationRoute(AdministrationRoute);
        }

        public bool SaveAdministrationRoute(CommContracts.AdministrationRoute AdministrationRoute)
        {
            return client.SaveAdministrationRoute(AdministrationRoute);
        }

        public bool DeleteAdministrationRoute(int AdministrationRouteID)
        {
            return client.DeleteAdministrationRoute(AdministrationRouteID);
        }
    }
}
