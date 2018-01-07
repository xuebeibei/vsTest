using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicineCheckStore
    {
        public bool SaveMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MedicineCheckStore, DAL.MedicineCheckStore>().ForMember(x => x.MedicineCheckStoreDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MedicineCheckStore temp = new DAL.MedicineCheckStore();
                temp = mapper.Map<DAL.MedicineCheckStore>(medicineCheckStore);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MedicineCheckStoreDetail, DAL.MedicineCheckStoreDetail>().ForMember(x => x.MedicineCheckStore, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MedicineCheckStoreDetail> list1 = medicineCheckStore.MedicineCheckStoreDetails;
                List<DAL.MedicineCheckStoreDetail> res = mapperDetail.Map<List<DAL.MedicineCheckStoreDetail>>(list1);

                temp.MedicineCheckStoreDetails = res;
                ctx.MedicineCheckStores.Add(temp);
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

        public bool RecheckMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore)
        {
            using (DAL.HisContext db = new DAL.HisContext())
            {
                var tem = new DAL.MedicineCheckStore
                {
                    ID = medicineCheckStore.ID,
                    ReCheckUserID = medicineCheckStore.ReCheckUserID,
                    ReCheckStatusEnum = (DAL.ReCheckStatusEnum)medicineCheckStore.ReCheckStatusEnum
                };
                //将实体附加到对象管理器中
                db.MedicineCheckStores.Attach(tem);

                //获取到user的状态实体，可以修改其状态
                var setEntry = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.GetObjectStateEntry(tem);
                //只修改实体的ReCheckUserID属性和ReCheckStatusEnum属性
                setEntry.SetModifiedProperty("ReCheckUserID");
                setEntry.SetModifiedProperty("ReCheckStatusEnum");

                db.SaveChanges();
            }

            return true;
        }

        public List<CommContracts.MedicineCheckStore> getAllMedicineCheckStore(int StoreID,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            List<CommContracts.MedicineCheckStore> list = new List<CommContracts.MedicineCheckStore>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MedicineCheckStores
                            where a.CheckStoreID == StoreID &&
                            a.OperateTime > StartInStoreTime &&
                            a.OperateTime < EndInStoreTime &&
                            a.NO.StartsWith(InStoreNo)
                            orderby a.OperateTime descending
                            select a;

                foreach (DAL.MedicineCheckStore ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MedicineCheckStore, CommContracts.MedicineCheckStore>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MedicineCheckStore temp = mapper.Map<CommContracts.MedicineCheckStore>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
