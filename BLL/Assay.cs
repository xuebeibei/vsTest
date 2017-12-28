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

        public List<CommContracts.Assay> getAllAssay(int RegistrationID)
        {
            List<CommContracts.Assay> list = new List<CommContracts.Assay>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Assays
                            where a.RegistrationID == RegistrationID
                            select a;
                foreach (DAL.Assay ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Assay, CommContracts.Assay>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Assay temp = mapper.Map<CommContracts.Assay>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}