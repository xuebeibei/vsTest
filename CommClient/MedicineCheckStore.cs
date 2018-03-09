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
    public class MedicineCheckStore : MyTableBase
    {
        public MedicineCheckStore()
        {
        }

        public bool SaveMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            return client.SaveMedicineCheckStock(medicineCheckStore);
        }

        public bool RecheckMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            return client.RecheckMedicineCheckStock(medicineCheckStore);
        }

        public List<CommContracts.MedicineCheckStore> getAllMedicineCheckStore(int StoreID, 
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            return client.getAllMedicineCheckStore(StoreID, StartInStoreTime, EndInStoreTime, InStoreNo);
        }
    }
}
