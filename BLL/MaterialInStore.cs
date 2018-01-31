using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialInStore
    {
        public bool SaveMaterialInStock(CommContracts.MaterialInStore MaterialInStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialInStore, DAL.MaterialInStore>().ForMember(x => x.MaterialInStoreDetails, opt => opt.Ignore())
                    .ForMember(x => x.FromSupplier, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MaterialInStore temp = new DAL.MaterialInStore();
                temp = mapper.Map<DAL.MaterialInStore>(MaterialInStore);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MaterialInStoreDetail, DAL.MaterialInStoreDetail>().ForMember(x => x.MaterialInStore, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MaterialInStoreDetail> list1 = MaterialInStore.MaterialInStoreDetails;
                List<DAL.MaterialInStoreDetail> res = mapperDetail.Map<List<DAL.MaterialInStoreDetail>>(list1);

                temp.MaterialInStoreDetails = res;
                ctx.MaterialInStores.Add(temp);
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

        public bool RecheckMaterialInStock(CommContracts.MaterialInStore MaterialInStore)
        {
            using (DAL.HisContext db = new DAL.HisContext())
            {
                var tem = new DAL.MaterialInStore
                {
                    ID = MaterialInStore.ID,
                    ReCheckUserID = MaterialInStore.ReCheckUserID,
                    ReCheckStatusEnum = (DAL.ReCheckStatusEnum)MaterialInStore.ReCheckStatusEnum
                };
                //将实体附加到对象管理器中
                db.MaterialInStores.Attach(tem);

                //获取到user的状态实体，可以修改其状态
                var setEntry = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.GetObjectStateEntry(tem);
                //只修改实体的ReCheckUserID属性和ReCheckStatusEnum属性
                setEntry.SetModifiedProperty("ReCheckUserID");
                setEntry.SetModifiedProperty("ReCheckStatusEnum");

                db.SaveChanges();
            }

            return true;
        }

        public CommContracts.MaterialInStore GetMaterialInStore(int Id)
        {
            CommContracts.MaterialInStore assay = new CommContracts.MaterialInStore();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.MaterialInStores
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MaterialInStore, CommContracts.MaterialInStore>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    assay = mapper.Map<CommContracts.MaterialInStore>(tem);
                    break;
                }
            }
            return assay;
        }

        public List<CommContracts.MaterialInStore> getAllMaterialInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            List<CommContracts.MaterialInStore> list = new List<CommContracts.MaterialInStore>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialInStores
                            where a.ToStoreID == StoreID &&
                            a.InStoreEnum == (DAL.InStoreEnum)inStoreEnum &&
                            a.OperateTime > StartInStoreTime &&
                            a.OperateTime < EndInStoreTime &&
                            a.NO.StartsWith(InStoreNo)
                            orderby a.OperateTime descending
                            select a;

                foreach (DAL.MaterialInStore ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialInStore, CommContracts.MaterialInStore>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialInStore temp = mapper.Map<CommContracts.MaterialInStore>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
