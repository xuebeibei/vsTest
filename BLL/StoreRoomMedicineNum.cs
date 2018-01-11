using AutoMapper;
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

                foreach (var tempDetail in medicineInStore.MedicineInStoreDetails)
                {
                    if (tempDetail == null)
                        continue;

                    var query = from s in ctx.StoreRoomMedicineNums
                                where s.Batch == tempDetail.Batch &&
                                s.MedicineID == tempDetail.MedicineID &&
                                s.StoreRoomID == medicineInStore.ToStoreID &&
                                s.StorePrice == tempDetail.StorePrice &&
                                s.SupplierID == medicineInStore.FromSupplierID &&
                                s.ExpirationDate == tempDetail.ExpirationDate
                                select s;


                    if (query.Count() == 0)
                    {
                        DAL.StoreRoomMedicineNum storeRoomMedicineNum = new DAL.StoreRoomMedicineNum();
                        storeRoomMedicineNum.Batch = tempDetail.Batch;
                        storeRoomMedicineNum.SupplierID = medicineInStore.FromSupplierID;
                        storeRoomMedicineNum.MedicineID = tempDetail.MedicineID;
                        storeRoomMedicineNum.StoreRoomID = medicineInStore.ToStoreID;
                        storeRoomMedicineNum.Num = tempDetail.Num;
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

        public bool RecheckMedicineOutStore(CommContracts.MedicineOutStore medicineOutStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if (medicineOutStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                    return false;

                if (medicineOutStore.MedicineOutStoreDetails == null)
                    return false;

                foreach (var tempDetail in medicineOutStore.MedicineOutStoreDetails)
                {
                    if (tempDetail == null)
                        continue;

                    var query = from s in ctx.StoreRoomMedicineNums
                                where s.ID == tempDetail.StoreRoomMedicineNumID &&
                                s.StoreRoomID == medicineOutStore.ToStoreID &&
                                s.StorePrice == tempDetail.StorePrice
                                select s;


                    if (query.Count() == 1)
                    {
                        var temp = query.First();
                        if (temp.Num >= tempDetail.Num)
                            temp.Num -= tempDetail.Num;
                        else
                            return false;
                    }
                    else
                        return false;
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

        public List<CommContracts.StoreRoomMedicineNum> getAllMedicineItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            List<CommContracts.StoreRoomMedicineNum> list = new List<CommContracts.StoreRoomMedicineNum>();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from x in ctx.StoreRoomMedicineNums
                            where x.StoreRoomID == StoreID &&
                            (x.Medicine.Name.StartsWith(ItemName) ||
                            x.Medicine.Abbr1.StartsWith(ItemName) ||
                            x.Medicine.Abbr2.StartsWith(ItemName) ||
                            x.Medicine.Abbr3.StartsWith(ItemName)
                            ) &&
                            (SupplierID == 0 || x.SupplierID == SupplierID) &&
                            (ItemType == -1 || x.Medicine.MedicineTypeEnum == (DAL.MedicineTypeEnum)ItemType) &&
                            (IsHasNum || x.Num <= 0) &&
                            (!IsOverDate || x.ExpirationDate < DateTime.Now) &&
                            (!IsNoEnough || x.Num < x.Medicine.MinNum)
                            orderby x.Medicine.Name
                            select x;


                foreach (DAL.StoreRoomMedicineNum ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.StoreRoomMedicineNum, CommContracts.StoreRoomMedicineNum>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.StoreRoomMedicineNum temp = mapper.Map<CommContracts.StoreRoomMedicineNum>(ass);
                    list.Add(temp);
                }

            }
            return list;
        }


        // 得到当前药品的合理库存
        public List<CommContracts.StoreRoomMedicineNum> GetStoreFromMedicine(int nMedicineID, int nNum)
        {
            List<CommContracts.StoreRoomMedicineNum> list = new List<CommContracts.StoreRoomMedicineNum>();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from x in ctx.StoreRoomMedicineNums
                            where
                             x.MedicineID == nMedicineID &&
                             x.ExpirationDate > DateTime.Now &&
                             //x.StoreRoom.StoreRoomEnum == DAL.StoreRoomEnum.三级库 &&
                             x.Num > 0
                            orderby x.ExpirationDate, x.Num
                            select x;

                int nSum = nNum;

                foreach (DAL.StoreRoomMedicineNum ass in query)
                {
                    if (nSum <= 0)
                        break;

                    var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.StoreRoomMedicineNum, CommContracts.StoreRoomMedicineNum>();
                });
                    var mapper = config.CreateMapper();

                    CommContracts.StoreRoomMedicineNum temp = mapper.Map<CommContracts.StoreRoomMedicineNum>(ass);
                    nSum -= temp.Num;

                    list.Add(temp);
                }

            }
            return list;
        }
    }
}
