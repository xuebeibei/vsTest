using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicineInStore
    {
        public bool SaveMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MedicineInStore, DAL.MedicineInStore>().ForMember(x => x.MedicineInStoreDetails, opt => opt.Ignore())
                    .ForMember(x => x.FromSupplier, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MedicineInStore temp = new DAL.MedicineInStore();
                temp = mapper.Map<DAL.MedicineInStore>(medicineInStore);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MedicineInStoreDetail, DAL.MedicineInStoreDetail>().ForMember(x => x.MedicineInStore, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MedicineInStoreDetail> list1 = medicineInStore.MedicineInStoreDetails;
                List<DAL.MedicineInStoreDetail> res = mapperDetail.Map<List<DAL.MedicineInStoreDetail>>(list1);

                temp.MedicineInStoreDetails = res;
                ctx.MedicineInStores.Add(temp);
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

        public bool RecheckMedicineInStock(CommContracts.MedicineInStore medicineInStore)
        {
            using (DAL.HisContext db = new DAL.HisContext())
            {  
                var tem = new DAL.MedicineInStore
                {
                    ID = medicineInStore.ID,
                    ReCheckUserID = medicineInStore.ReCheckUserID,
                    ReCheckStatusEnum = (DAL.ReCheckStatusEnum)medicineInStore.ReCheckStatusEnum
                };
                //将实体附加到对象管理器中
                db.MedicineInStores.Attach(tem);

                //获取到user的状态实体，可以修改其状态
                var setEntry = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.GetObjectStateEntry(tem);
                //只修改实体的ReCheckUserID属性和ReCheckStatusEnum属性
                setEntry.SetModifiedProperty("ReCheckUserID");
                setEntry.SetModifiedProperty("ReCheckStatusEnum");

                db.SaveChanges();
            }

            return true;
        }

        public CommContracts.MedicineInStore GetMedicineInStore(int Id)
        {
            CommContracts.MedicineInStore assay = new CommContracts.MedicineInStore();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.MedicineInStores
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicineInStore, CommContracts.MedicineInStore>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    assay = mapper.Map<CommContracts.MedicineInStore>(tem);
                    break;
                }
            }
            return assay;
        }

        public List<CommContracts.MedicineInStore> getAllMedicineInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            List<CommContracts.MedicineInStore> list = new List<CommContracts.MedicineInStore>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MedicineInStores
                                where a.ToStoreID == StoreID &&
                                a.InStoreEnum == (DAL.InStoreEnum)inStoreEnum &&
                                a.OperateTime > StartInStoreTime &&
                                a.OperateTime < EndInStoreTime &&
                                a.NO.StartsWith(InStoreNo) 
                                orderby a.OperateTime descending
                                select a;
                
                foreach (DAL.MedicineInStore ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MedicineInStore, CommContracts.MedicineInStore>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MedicineInStore temp = mapper.Map<CommContracts.MedicineInStore>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
