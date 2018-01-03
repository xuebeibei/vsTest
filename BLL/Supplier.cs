using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Supplier
    {

        public List<CommContracts.Supplier> GetAllSuppliers(string strFindName)
        {
            List<CommContracts.Supplier> list = new List<CommContracts.Supplier>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Suppliers
                            where a.Name.StartsWith(strFindName) ||
                            a.Abbr1.StartsWith(strFindName) ||
                            a.Abbr2.StartsWith(strFindName) ||
                            a.Abbr3.StartsWith(strFindName) 
                            select a;
                foreach (DAL.Supplier ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Supplier, CommContracts.Supplier>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Supplier temp = mapper.Map<CommContracts.Supplier>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
