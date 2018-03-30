using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicineOutStore
    {
        public List<CommContracts.MedicineOutStore> getAllMedicineOutStore(int StoreID, CommContracts.
               OutStoreEnum outStoreEnum,
               DateTime StartInStoreTime,
               DateTime EndInStoreTime,
               string OutStoreNo = "")
        {
            List<CommContracts.MedicineOutStore> list = new List<CommContracts.MedicineOutStore>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MedicineOutStores
                            where a.ToStoreID == StoreID &&
                            a.OutStoreEnum == (DAL.OutStoreEnum)outStoreEnum &&
                            a.OperateTime > StartInStoreTime &&
                            a.OperateTime < EndInStoreTime &&
                            a.NO.StartsWith(OutStoreNo)
                            orderby a.OperateTime descending
                            select a;

                foreach (DAL.MedicineOutStore ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MedicineOutStore, CommContracts.MedicineOutStore>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MedicineOutStore temp = mapper.Map<CommContracts.MedicineOutStore>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MedicineOutStore, DAL.MedicineOutStore>().ForMember(x => x.MedicineOutStoreDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MedicineOutStore temp = new DAL.MedicineOutStore();
                temp = mapper.Map<DAL.MedicineOutStore>(medicineOutStore);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MedicineOutStoreDetail, DAL.MedicineOutStoreDetail>().ForMember(x => x.MedicineOutStore, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MedicineOutStoreDetail> list1 = medicineOutStore.MedicineOutStoreDetails;
                List<DAL.MedicineOutStoreDetail> res = mapperDetail.Map<List<DAL.MedicineOutStoreDetail>>(list1);

                temp.MedicineOutStoreDetails = res;
                ctx.MedicineOutStores.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool RecheckMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore)
        {
            using (DAL.HisContext db = new DAL.HisContext())
            {
                var tem = new DAL.MedicineOutStore
                {
                    ID = medicineOutStore.ID,
                    ReCheckUserID = medicineOutStore.ReCheckUserID,
                    ReCheckStatusEnum = (DAL.ReCheckStatusEnum)medicineOutStore.ReCheckStatusEnum
                };
                //将实体附加到对象管理器中
                db.MedicineOutStores.Attach(tem);

                //获取到user的状态实体，可以修改其状态
                var setEntry = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.GetObjectStateEntry(tem);
                //只修改实体的ReCheckUserID属性和ReCheckStatusEnum属性
                setEntry.SetModifiedProperty("ReCheckUserID");
                setEntry.SetModifiedProperty("ReCheckStatusEnum");

                db.SaveChanges();
            }

            return true;

        }
    }
}
