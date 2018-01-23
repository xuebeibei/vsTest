using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InspectDoctorAdvice
    {
        public CommContracts.InspectDoctorAdvice GetInspectDoctorAdvice(int Id)
        {
            CommContracts.InspectDoctorAdvice inspectDoctorAdvice = new CommContracts.InspectDoctorAdvice();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.InspectDoctorAdvices
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InspectDoctorAdvice, CommContracts.InspectDoctorAdvice>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    inspectDoctorAdvice = mapper.Map<CommContracts.InspectDoctorAdvice>(tem);
                    break;
                }
            }
            return inspectDoctorAdvice;
        }

        public bool SaveInspectDoctorAdvice(CommContracts.InspectDoctorAdvice inspectDoctorAdvice)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.InspectDoctorAdvice, DAL.InspectDoctorAdvice>().ForMember(x => x.InspectDoctorAdviceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.InspectDoctorAdvice temp = new DAL.InspectDoctorAdvice();
                temp = mapper.Map<DAL.InspectDoctorAdvice>(inspectDoctorAdvice);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.InspectDoctorAdviceDetail, DAL.InspectDoctorAdviceDetail>().ForMember(x => x.Inspect, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.InspectDoctorAdviceDetail> list1 = inspectDoctorAdvice.InspectDoctorAdviceDetails;
                List<DAL.InspectDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.InspectDoctorAdviceDetail>>(list1); ;

                temp.InspectDoctorAdviceDetails = res;
                ctx.InspectDoctorAdvices.Add(temp);
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

        public List<CommContracts.InspectDoctorAdvice> getAllInspectDoctorAdvice(int RegistrationID)
        {
            List<CommContracts.InspectDoctorAdvice> list = new List<CommContracts.InspectDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.InspectDoctorAdvices
                            where i.RegistrationID == RegistrationID
                            select i;
                foreach (DAL.InspectDoctorAdvice ins in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InspectDoctorAdvice, CommContracts.InspectDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InspectDoctorAdvice temp = mapper.Map<CommContracts.InspectDoctorAdvice>(ins);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.InspectDoctorAdvice> getAllInHospitalInspectDoctorAdvice(int InpatientID)
        {
            List<CommContracts.InspectDoctorAdvice> list = new List<CommContracts.InspectDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.InspectDoctorAdvices
                            where i.InpatientID == InpatientID
                            select i;
                foreach (DAL.InspectDoctorAdvice ins in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InspectDoctorAdvice, CommContracts.InspectDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InspectDoctorAdvice temp = mapper.Map<CommContracts.InspectDoctorAdvice>(ins);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
