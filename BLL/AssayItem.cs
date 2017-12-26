using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AssayItem
    {
        public List<CommContracts.AssayItem> GetAllAssayItems(string strName)
        {
            List<CommContracts.AssayItem> list = new List<CommContracts.AssayItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.AssayItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AssayItem, CommContracts.AssayItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.AssayItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.AssayItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }
    }
}
