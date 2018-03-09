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
    public class MedicineInStore : MyTableBase
    {
        public MedicineInStore()
        {
        }

        public bool SaveMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            return client.SaveMedicineInStock(medicineInStore);
        }

        public bool RecheckMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            return client.RecheckMedicineInStock(medicineInStore);
        }

        public List<CommContracts.MedicineInStore> getAllMedicineInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            return client.getAllMedicineInStore(StoreID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }
    }
}
