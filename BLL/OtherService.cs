using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OtherService
    {
        public CommContracts.OtherService GetOtherService(int Id)
        {
            CommContracts.OtherService otherService = new CommContracts.OtherService();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.OtherServices
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.OtherService, CommContracts.OtherService>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    otherService = mapper.Map<CommContracts.OtherService>(tem);
                    break;
                }
            }
            return otherService;
        }

        public bool SaveOtherService(CommContracts.OtherService otherService)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.OtherService, DAL.OtherService>().ForMember(x => x.OtherServiceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.OtherService temp = new DAL.OtherService();
                temp = mapper.Map<DAL.OtherService>(otherService);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.OtherServiceDetail, DAL.OtherServiceDetail>().ForMember(x => x.OtherService, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.OtherServiceDetail> list1 = otherService.OtherServiceDetails;
                List<DAL.OtherServiceDetail> res = mapperDetail.Map<List<DAL.OtherServiceDetail>>(list1); ;

                temp.OtherServiceDetails = res;
                ctx.OtherServices.Add(temp);
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

        public List<CommContracts.OtherService> getAllOtherService(int RegistrationID)
        {
            List<CommContracts.OtherService> list = new List<CommContracts.OtherService>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.OtherServices
                            where a.RegistrationID == RegistrationID
                            select a;
                foreach (DAL.OtherService ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.OtherService, CommContracts.OtherService>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.OtherService temp = mapper.Map<CommContracts.OtherService>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.OtherService> getAllInHospitalOtherService(int InpatientID)
        {
            List<CommContracts.OtherService> list = new List<CommContracts.OtherService>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.OtherServices
                            where a.InpatientID == InpatientID
                            select a;
                foreach (DAL.OtherService ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.OtherService, CommContracts.OtherService>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.OtherService temp = mapper.Map<CommContracts.OtherService>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
