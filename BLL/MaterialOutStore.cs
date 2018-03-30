using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialOutStore
    {
        public List<CommContracts.MaterialOutStore> getAllMaterialOutStore(int StoreID, CommContracts.
               OutStoreEnum outStoreEnum,
               DateTime StartInStoreTime,
               DateTime EndInStoreTime,
               string OutStoreNo = "")
        {
            List<CommContracts.MaterialOutStore> list = new List<CommContracts.MaterialOutStore>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialOutStores
                            where a.ToStoreID == StoreID &&
                            a.OutStoreEnum == (DAL.OutStoreEnum)outStoreEnum &&
                            a.OperateTime > StartInStoreTime &&
                            a.OperateTime < EndInStoreTime &&
                            a.NO.StartsWith(OutStoreNo)
                            orderby a.OperateTime descending
                            select a;

                foreach (DAL.MaterialOutStore ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialOutStore, CommContracts.MaterialOutStore>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialOutStore temp = mapper.Map<CommContracts.MaterialOutStore>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialOutStore, DAL.MaterialOutStore>().ForMember(x => x.MaterialOutStoreDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MaterialOutStore temp = new DAL.MaterialOutStore();
                temp = mapper.Map<DAL.MaterialOutStore>(MaterialOutStore);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MaterialOutStoreDetail, DAL.MaterialOutStoreDetail>().ForMember(x => x.MaterialOutStore, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MaterialOutStoreDetail> list1 = MaterialOutStore.MaterialOutStoreDetails;
                List<DAL.MaterialOutStoreDetail> res = mapperDetail.Map<List<DAL.MaterialOutStoreDetail>>(list1);

                temp.MaterialOutStoreDetails = res;
                ctx.MaterialOutStores.Add(temp);
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

        public bool RecheckMaterialOutStock(CommContracts.MaterialOutStore MaterialOutStore)
        {
            using (DAL.HisContext db = new DAL.HisContext())
            {
                var tem = new DAL.MaterialOutStore
                {
                    ID = MaterialOutStore.ID,
                    ReCheckUserID = MaterialOutStore.ReCheckUserID,
                    ReCheckStatusEnum = (DAL.ReCheckStatusEnum)MaterialOutStore.ReCheckStatusEnum
                };
                //将实体附加到对象管理器中
                db.MaterialOutStores.Attach(tem);

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
