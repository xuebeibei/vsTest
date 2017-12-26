using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Assay
    {
        public CommContracts.Assay GetAssay(int Id)
        {
            CommContracts.Assay assay = new CommContracts.Assay();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Assays
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Assay, CommContracts.Assay>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    assay = mapper.Map<CommContracts.Assay>(tem);
                    break;
                }
            }
            return assay;
        }

        public bool SaveAssay(CommContracts.Assay assay)
        {
            DAL.Assay temp = new DAL.Assay();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Assay, DAL.Assay>();
                });
                var mapper = config.CreateMapper();

                temp = mapper.Map<DAL.Assay>(assay);

                ctx.Assays.Add(temp);

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
