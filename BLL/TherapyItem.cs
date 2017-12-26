using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TherapyItem
    {
        public List<CommContracts.TherapyItem> GetAllTherapyItems(string strName)
        {
            List<CommContracts.TherapyItem> list = new List<CommContracts.TherapyItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.TherapyItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) || 
                            t.AbbrWB.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.TherapyItem, CommContracts.TherapyItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.TherapyItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.TherapyItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }
    }
}
