using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialItem
    {
        public List<CommContracts.MaterialItem> GetAllMaterialItems(string strName)
        {
            List<CommContracts.MaterialItem> list = new List<CommContracts.MaterialItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.MaterialItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MaterialItem, CommContracts.MaterialItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.MaterialItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.MaterialItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }
    }
}
