using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreRoomMaterialNum
    {
        public bool ReCheckMaterialInStore(CommContracts.MaterialInStore MaterialInStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if (MaterialInStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                    return false;

                if (MaterialInStore.MaterialInStoreDetails == null)
                    return false;

                foreach (var tempDetail in MaterialInStore.MaterialInStoreDetails)
                {
                    if (tempDetail == null)
                        continue;

                    var query = from s in ctx.StoreRoomMaterialNums
                                where s.Batch == tempDetail.Batch &&
                                s.MaterialItemID == tempDetail.MaterialID &&
                                s.StoreRoomID == MaterialInStore.ToStoreID &&
                                s.StorePrice == tempDetail.StorePrice &&
                                s.SupplierID == MaterialInStore.FromSupplierID &&
                                s.ExpirationDate == tempDetail.ExpirationDate
                                select s;


                    if (query.Count() == 0)
                    {
                        DAL.StoreRoomMaterialNum storeRoomMaterialNum = new DAL.StoreRoomMaterialNum();
                        storeRoomMaterialNum.Batch = tempDetail.Batch;
                        storeRoomMaterialNum.SupplierID = MaterialInStore.FromSupplierID;
                        storeRoomMaterialNum.MaterialItemID = tempDetail.MaterialID;
                        storeRoomMaterialNum.StoreRoomID = MaterialInStore.ToStoreID;
                        storeRoomMaterialNum.Num = tempDetail.Num;
                        storeRoomMaterialNum.StorePrice = tempDetail.StorePrice;
                        storeRoomMaterialNum.ExpirationDate = tempDetail.ExpirationDate;
                        ctx.StoreRoomMaterialNums.Add(storeRoomMaterialNum);
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

        public bool RecheckMaterialOutStore(CommContracts.MaterialOutStore MaterialOutStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if (MaterialOutStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                    return false;

                if (MaterialOutStore.MaterialOutStoreDetails == null)
                    return false;

                foreach (var tempDetail in MaterialOutStore.MaterialOutStoreDetails)
                {
                    if (tempDetail == null)
                        continue;

                    var query = from s in ctx.StoreRoomMaterialNums
                                where s.ID == tempDetail.StoreRoomMaterialNumID &&
                                s.StoreRoomID == MaterialOutStore.ToStoreID &&
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

        public bool ReCheckMaterialCheckStore(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if (MaterialCheckStore == null)
                    return false;
                if (MaterialCheckStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                    return false;

                if (MaterialCheckStore.MaterialCheckStoreDetails == null)
                    return false;

                foreach (var tempDetail in MaterialCheckStore.MaterialCheckStoreDetails)
                {
                    if (tempDetail == null)
                        continue;

                    var query = from s in ctx.StoreRoomMaterialNums
                                where s.ID == tempDetail.StoreRoomMaterialNumID &&
                                s.StoreRoomID == MaterialCheckStore.CheckStoreID &&
                                s.StorePrice == tempDetail.StorePrice
                                select s;


                    if (query.Count() == 1)
                    {
                        var temp = query.First();
                        temp.Num = tempDetail.Num;
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

        public List<CommContracts.StoreRoomMaterialNum> getAllMaterialItemNum(int StoreID,
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            List<CommContracts.StoreRoomMaterialNum> list = new List<CommContracts.StoreRoomMaterialNum>();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from x in ctx.StoreRoomMaterialNums
                            where x.StoreRoomID == StoreID &&
                            (x.MaterialItem.Name.StartsWith(ItemName) ||
                            x.MaterialItem.AbbrPY.StartsWith(ItemName) ||
                            x.MaterialItem.AbbrWB.StartsWith(ItemName)
                            ) &&
                            (SupplierID == 0 || x.SupplierID == SupplierID) &&
                            (IsHasNum || x.Num <= 0) &&
                            (!IsHasNum || x.Num > 0) &&
                            (!IsOverDate || x.ExpirationDate < DateTime.Now) &&
                            (!IsNoEnough || x.Num < x.MaterialItem.MinNum)
                            orderby x.MaterialItem.Name
                            select x;


                foreach (DAL.StoreRoomMaterialNum ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.StoreRoomMaterialNum, CommContracts.StoreRoomMaterialNum>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.StoreRoomMaterialNum temp = mapper.Map<CommContracts.StoreRoomMaterialNum>(ass);
                    list.Add(temp);
                }

            }
            return list;
        }


        // 得到当前药品的合理库存
        public List<CommContracts.StoreRoomMaterialNum> GetStoreFromMaterial(int nMaterialID, int nNum)
        {
            List<CommContracts.StoreRoomMaterialNum> list = new List<CommContracts.StoreRoomMaterialNum>();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from x in ctx.StoreRoomMaterialNums
                            where
                             x.MaterialItemID == nMaterialID &&
                             x.ExpirationDate > DateTime.Now &&
                             //x.StoreRoom.StoreRoomEnum == DAL.StoreRoomEnum.三级库 &&
                             x.Num > 0
                            orderby x.ExpirationDate, x.Num
                            select x;

                int nSum = nNum;

                foreach (DAL.StoreRoomMaterialNum ass in query)
                {
                    if (nSum <= 0)
                        break;

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.StoreRoomMaterialNum, CommContracts.StoreRoomMaterialNum>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.StoreRoomMaterialNum temp = mapper.Map<CommContracts.StoreRoomMaterialNum>(ass);
                    nSum -= temp.Num;

                    list.Add(temp);
                }

            }
            return list;
        }

        // 根据物资材料收费单更新库存
        public bool SubdMaterialStoreNum(CommContracts.MaterialCharge recipeChargeBill)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if (recipeChargeBill == null)
                    return false;

                // 如果已执行，则不能操作
                //if (recipeChargeBill.zhixingstatus == CommContracts.ReCheckStatusEnum.已审核)
                //    return false;

                if (recipeChargeBill.MaterialChargeDetails == null)
                    return false;

                foreach (var tempDetail in recipeChargeBill.MaterialChargeDetails)
                {
                    if (tempDetail == null)
                        continue;

                    var query = from s in ctx.StoreRoomMaterialNums
                                where s.ID == tempDetail.StoreRoomMaterialNumID
                                select s;


                    if (query.Count() == 1)
                    {
                        var temp = query.First();
                        if (temp.Num >= tempDetail.AllNum)
                            temp.Num -= tempDetail.AllNum;
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
    }
}
