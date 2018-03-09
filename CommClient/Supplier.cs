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
    public class Supplier : MyTableBase
    {
        public Supplier()
        {
        }

        public List<CommContracts.Supplier> GetAllSuppliers(string strFindName)
        {
            return client.GetAllSuppliers(strFindName);
        }

        public bool UpdateSupplier(CommContracts.Supplier supplier)
        {
            return client.UpdateSupplier(supplier);
        }

        public bool SaveSupplier(CommContracts.Supplier supplier)
        {
            return client.SaveSupplier(supplier);
        }

        public bool DeleteSupplier(int supplierID)
        {
            return client.DeleteSupplier(supplierID);
        }

    }
}
