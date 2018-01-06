using AutoMapper;
using System;
using System.Collections.Generic;
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
    }
}
