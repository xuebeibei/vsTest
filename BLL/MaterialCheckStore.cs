using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialCheckStore
    {
        public bool SaveMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialCheckStore, DAL.MaterialCheckStore>().ForMember(x => x.MaterialCheckStoreDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MaterialCheckStore temp = new DAL.MaterialCheckStore();
                temp = mapper.Map<DAL.MaterialCheckStore>(MaterialCheckStore);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MaterialCheckStoreDetail, DAL.MaterialCheckStoreDetail>().ForMember(x => x.MaterialCheckStore, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MaterialCheckStoreDetail> list1 = MaterialCheckStore.MaterialCheckStoreDetails;
                List<DAL.MaterialCheckStoreDetail> res = mapperDetail.Map<List<DAL.MaterialCheckStoreDetail>>(list1);

                temp.MaterialCheckStoreDetails = res;
                ctx.MaterialCheckStores.Add(temp);
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

        public bool RecheckMaterialCheckStock(CommContracts.MaterialCheckStore MaterialCheckStore)
        {
            using (DAL.HisContext db = new DAL.HisContext())
            {
                var tem = new DAL.MaterialCheckStore
                {
                    ID = MaterialCheckStore.ID,
                    ReCheckUserID = MaterialCheckStore.ReCheckUserID,
                    ReCheckStatusEnum = (DAL.ReCheckStatusEnum)MaterialCheckStore.ReCheckStatusEnum
                };
                //将实体附加到对象管理器中
                db.MaterialCheckStores.Attach(tem);

                //获取到user的状态实体，可以修改其状态
                var setEntry = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.GetObjectStateEntry(tem);
                //只修改实体的ReCheckUserID属性和ReCheckStatusEnum属性
                setEntry.SetModifiedProperty("ReCheckUserID");
                setEntry.SetModifiedProperty("ReCheckStatusEnum");

                db.SaveChanges();
            }

            return true;
        }

        public List<CommContracts.MaterialCheckStore> getAllMaterialCheckStore(int StoreID,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            List<CommContracts.MaterialCheckStore> list = new List<CommContracts.MaterialCheckStore>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialCheckStores
                            where a.CheckStoreID == StoreID &&
                            a.OperateTime > StartInStoreTime &&
                            a.OperateTime < EndInStoreTime &&
                            a.NO.StartsWith(InStoreNo)
                            orderby a.OperateTime descending
                            select a;

                foreach (DAL.MaterialCheckStore ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialCheckStore, CommContracts.MaterialCheckStore>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialCheckStore temp = mapper.Map<CommContracts.MaterialCheckStore>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
