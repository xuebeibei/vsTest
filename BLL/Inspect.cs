using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Inspect
    {
        public CommContracts.Inspect GetInspect(int Id)
        {
            CommContracts.Inspect inspect = new CommContracts.Inspect();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Inspects
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Inspect, CommContracts.Inspect>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    inspect = mapper.Map<CommContracts.Inspect>(tem);
                    break;
                }
            }
            return inspect;
        }

        public bool SaveInspect(CommContracts.Inspect inspect)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Inspect, DAL.Inspect>().ForMember(x => x.InspectDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.Inspect temp = new DAL.Inspect();
                temp = mapper.Map<DAL.Inspect>(inspect);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.InspectDetail, DAL.InspectDetail>().ForMember(x => x.Inspect, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.InspectDetail> list1 = inspect.InspectDetails;
                List<DAL.InspectDetail> res = mapperDetail.Map<List<DAL.InspectDetail>>(list1); ;

                temp.InspectDetails = res;
                ctx.Inspects.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                }

            }
            return true;
        }

        public List<CommContracts.Inspect> getAllInspect(int RegistrationID)
        {
            List<CommContracts.Inspect> list = new List<CommContracts.Inspect>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.Inspects
                            where i.RegistrationID == RegistrationID
                            select i;
                foreach (DAL.Inspect ins in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Inspect, CommContracts.Inspect>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Inspect temp = mapper.Map<CommContracts.Inspect>(ins);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.Inspect> getAllInHospitalInspect(int InpatientID)
        {
            List<CommContracts.Inspect> list = new List<CommContracts.Inspect>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.Inspects
                            where i.InpatientID == InpatientID
                            select i;
                foreach (DAL.Inspect ins in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Inspect, CommContracts.Inspect>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Inspect temp = mapper.Map<CommContracts.Inspect>(ins);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
