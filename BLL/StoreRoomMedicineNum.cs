using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

                    var query = from s in ctx.StoreRoomMedicineNums
                                where s.Batch == tempDetail.Batch &&
                                s.MedicineID == tempDetail.MedicineID &&
                                s.StoreRoomID == medicineInStore.ToStoreID &&
                                s.StorePrice == tempDetail.StorePrice &&
                                s.ExpirationDate == tempDetail.ExpirationDate
                                select s;

                    
                    if (query.Count() == 0)
                    {
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
                    else
                    {
                        var temp = query.First();
                        temp.Num += tempDetail.Num;
                    }
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
