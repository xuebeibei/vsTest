using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InspectItem
    {
        public List<CommContracts.InspectItem> GetAllInspectItems(string strName)
        {
            List<CommContracts.InspectItem> list = new List<CommContracts.InspectItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.InspectItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AssayItem, CommContracts.AssayItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.InspectItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.InspectItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }
    }
}
