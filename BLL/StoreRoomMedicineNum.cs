using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreRoomMedicineNum
    {
        public bool ReCheckMedicineInStore(CommContracts.MedicineInStore medicineInStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if (medicineInStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                    return false;

                if (medicineInStore.MedicineInStoreDetails == null)
                    return false;
                
                foreach(var tempDetail in medicineInStore.MedicineInStoreDetails)
                {
                    if (tempDetail == null)
                        continue;
                    DAL.StoreRoomMedicineNum storeRoomMedicineNum = new DAL.StoreRoomMedicineNum();
                    storeRoomMedicineNum.Batch = tempDetail.Batch;
                    storeRoomMedicineNum.MedicineID = tempDetail.MedicineID;
                    storeRoomMedicineNum.StoreRoomID = medicineInStore.ToStoreID;
                    storeRoomMedicineNum.Num = tempDetail.Num;
                    storeRoomMedicineNum.SellPrice = tempDetail.SellPrice;
                    storeRoomMedicineNum.StorePrice = tempDetail.StorePrice;
                    storeRoomMedicineNum.ExpirationDate = tempDetail.ExpirationDate;
                    ctx.StoreRoomMedicineNums.Add(storeRoomMedicineNum);
                }

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
