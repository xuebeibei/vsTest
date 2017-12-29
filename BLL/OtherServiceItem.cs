using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OtherServiceItem
    {
        public List<CommContracts.OtherServiceItem> GetAllOtherServiceItems(string strName)
        {
            List<CommContracts.OtherServiceItem> list = new List<CommContracts.OtherServiceItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.OtherServiceItem
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.OtherServiceItem, CommContracts.OtherServiceItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.OtherServiceItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.OtherServiceItem>(tem);
                    list.Add(dto);
                }
            }
            return list;
        }
    }
}
