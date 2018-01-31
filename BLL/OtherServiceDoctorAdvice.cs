using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OtherServiceDoctorAdvice : DoctorAdviceBase
    {
        public CommContracts.OtherServiceDoctorAdvice GetOtherService(int Id)
        {
            CommContracts.OtherServiceDoctorAdvice otherService = new CommContracts.OtherServiceDoctorAdvice();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.OtherServiceDoctorAdvices
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.OtherServiceDoctorAdvice, CommContracts.OtherServiceDoctorAdvice>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    otherService = mapper.Map<CommContracts.OtherServiceDoctorAdvice>(tem);
                    break;
                }
            }
            return otherService;
        }

        public bool SaveOtherService(CommContracts.OtherServiceDoctorAdvice otherService)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.OtherServiceDoctorAdvice, DAL.OtherServiceDoctorAdvice>().ForMember(x => x.OtherServiceDoctorAdviceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.OtherServiceDoctorAdvice temp = new DAL.OtherServiceDoctorAdvice();
                temp = mapper.Map<DAL.OtherServiceDoctorAdvice>(otherService);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.OtherServiceDoctorAdviceDetail, DAL.OtherServiceDoctorAdviceDetail>().ForMember(x => x.OtherService, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.OtherServiceDoctorAdviceDetail> list1 = otherService.OtherServiceDoctorAdviceDetails;
                List<DAL.OtherServiceDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.OtherServiceDoctorAdviceDetail>>(list1); ;

                temp.OtherServiceDoctorAdviceDetails = res;
                ctx.OtherServiceDoctorAdvices.Add(temp);
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

        public List<CommContracts.OtherServiceDoctorAdvice> getAllOtherService(int RegistrationID)
        {
            List<CommContracts.OtherServiceDoctorAdvice> list = new List<CommContracts.OtherServiceDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.OtherServiceDoctorAdvices
                            where a.RegistrationID == RegistrationID
                            select a;
                foreach (DAL.OtherServiceDoctorAdvice ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.OtherServiceDoctorAdvice, CommContracts.OtherServiceDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.OtherServiceDoctorAdvice temp = mapper.Map<CommContracts.OtherServiceDoctorAdvice>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.OtherServiceDoctorAdvice> getAllInHospitalOtherService(int InpatientID)
        {
            List<CommContracts.OtherServiceDoctorAdvice> list = new List<CommContracts.OtherServiceDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.OtherServiceDoctorAdvices
                            where a.InpatientID == InpatientID
                            select a;
                foreach (DAL.OtherServiceDoctorAdvice ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.OtherServiceDoctorAdvice, CommContracts.OtherServiceDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.OtherServiceDoctorAdvice temp = mapper.Map<CommContracts.OtherServiceDoctorAdvice>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
